using System;
using System.Collections.Generic;
using System.Linq;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Entities.DTO;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Services.Interface.Validate;
using ATMTECH.Web.Services.Base;

namespace ATMTECH.FishingAtWork.Services
{
    public class CatchService : BaseService, ICatchService
    {
        public IRandomService RandomService { get; set; }
        // public IDAOPlayer DAOPlayer { get; set; }
        public IDAOSpeciesCatch DAOSpeciesCatch { get; set; }
        public IDAOSiteSpecies DAOSiteSpecies { get; set; }
        public IDAOCoordinateTry DAOCoordinateTry { get; set; }
        public IValidateCatchService ValidateCatchService { get; set; }
        public IPlayerService PlayerService { get; set; }

        public IList<SpeciesCatch> Catch(Site site)
        {
            IList<SpeciesCatch> speciesCatches = new List<SpeciesCatch>();

            if (site.SiteSpecies == null)
            {
                return null;
            }

            foreach (SiteSpecies siteSpeciese in site.SiteSpecies)
            {

                SpeciesCatch speciesCatch = new SpeciesCatch
                                                {
                                                    Species = siteSpeciese.Species,
                                                    Site = site
                                                };

                Coordinate coordinate = PickCoordinateInSiteSpecies(siteSpeciese);
                speciesCatch.X = coordinate.X;
                speciesCatch.Y = coordinate.Y;


                CoordinateTry coordinateTry = new CoordinateTry();
                coordinateTry.Site = site;
                coordinateTry.X = coordinate.X;
                coordinateTry.Y = coordinate.Y;
                coordinateTry.ColorName = speciesCatch.Species.ColorName;
                coordinateTry.Species = speciesCatch.Species;
                DAOCoordinateTry.CreateCoordinateTry(coordinateTry);

                if (site.Waypoints != null)
                {
                    foreach (Waypoint waypoint in site.Waypoints)
                    {
                        // Il faut gérer le temps du Waypoint comparé au pool voir si ca fait du sens d'etre la l'heure prévu.
                        if (WaypointIsInTime(waypoint))
                        {
                            if (IsCoordinateInsideArea(coordinate, waypoint.Area))
                            {
                                speciesCatch.IsSuccessArea = true;
                                speciesCatch.Player = waypoint.Player;
                                speciesCatch.Lure = waypoint.Lure;
                                if (ValidateCatchService.Validate(speciesCatch))
                                {
                                    SetSuccessfulCatch(speciesCatch);
                                    DAOSpeciesCatch.AddCatch(speciesCatch);
                                    UpdatePlayer(speciesCatch);
                                }
                                else
                                {
                                    speciesCatch.IsSuccessfulCatch = false;
                                }
                            }
                        }
                    }
                }
                speciesCatches.Add(speciesCatch);
            }
            return speciesCatches;
        }

        private bool WaypointIsInTime(Waypoint waypoint)
        {
            if (waypoint.DateStart <= DateTime.Now && waypoint.DateEnd >= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetCountCatch(Site site)
        {
            return DAOSpeciesCatch.GetCountCatch(site);
        }


        private void UpdatePlayer(SpeciesCatch speciesCatch)
        {
            speciesCatch.Player.Experience += speciesCatch.Experience;
            speciesCatch.Player.Money += speciesCatch.Money;
            PlayerService.SavePlayer(speciesCatch.Player);
            PlayerService.UpdatePlayerCatch(speciesCatch);
            PlayerService.UpdateRecord(speciesCatch);
        }
        private void SetSuccessfulCatch(SpeciesCatch speciesCatch)
        {
            speciesCatch.IsSuccessfulCatch = true;

            IList<SiteSpecies> siteSpecieses = DAOSiteSpecies.GetSiteSpecies(speciesCatch.Site);
            SiteSpecies siteSpecies = siteSpecieses.SingleOrDefault(site => site.Species.Id == speciesCatch.Species.Id);
            int weightModifier = 0;

            if (siteSpecies != null)
            {
                weightModifier = siteSpecies.WeightModifier;
            }

            speciesCatch.Weight = RandomService.RandomSpeciesWeight(speciesCatch.Species.MinimumWeight, speciesCatch.Species.MaximumWeight - weightModifier);
            speciesCatch.Experience = RandomService.RandomSpeciesExperience(speciesCatch.Species.MaximumExperience, speciesCatch.Weight);
            if (speciesCatch.Site.IsTournament)
            {
                speciesCatch.Money = speciesCatch.Species.MoneyValueInTournament * speciesCatch.Experience;
            }
        }
        private Coordinate PickCoordinateInSiteSpecies(SiteSpecies siteSpecies)
        {
            double maximumX = 0;
            double minimumX = int.MaxValue;
            double maximumY = 0;
            double minimumY = int.MaxValue;

            foreach (SiteSpeciesCoordinate siteSpeciesCoordinate in siteSpecies.Area)
            {
                if (siteSpeciesCoordinate.X > maximumX)
                {
                    maximumX = siteSpeciesCoordinate.X;
                }
                if (siteSpeciesCoordinate.Y > maximumY)
                {
                    maximumY = siteSpeciesCoordinate.Y;
                }
                if (siteSpeciesCoordinate.X < minimumX)
                {
                    minimumX = siteSpeciesCoordinate.X;
                }
                if (siteSpeciesCoordinate.Y < minimumY)
                {
                    minimumY = siteSpeciesCoordinate.Y;
                }
            }


            return RandomService.RandomCoordinate(minimumX, maximumX, minimumY, maximumY);
        }
        private bool IsCoordinateInsideArea(Coordinate coordinate, IList<Coordinate> area)
        {
            bool inside = false;
            if (area.Count < 3)
            {
                return false;
            }

            Coordinate oldPoint = new Coordinate(area[area.Count - 1].X, area[area.Count - 1].Y);

            foreach (Coordinate t in area)
            {
                Coordinate newPoint = new Coordinate(t.X, t.Y);
                Coordinate p1;
                Coordinate p2;
                if (newPoint.X > oldPoint.X)
                {
                    p1 = oldPoint;
                    p2 = newPoint;
                }
                else
                {
                    p1 = newPoint;
                    p2 = oldPoint;
                }

                if ((newPoint.X < coordinate.X) == (coordinate.X <= oldPoint.X) && ((long)coordinate.Y - (long)p1.Y)
                    * (long)(p2.X - p1.X) < ((long)p2.Y - (long)p1.Y) * (long)(coordinate.X - p1.X))
                {
                    inside = !inside;
                }


                if (coordinate.X == t.X && coordinate.Y == t.Y)
                {
                    inside = true;
                }
                oldPoint = newPoint;
            }

            return inside;
        }
    }
}

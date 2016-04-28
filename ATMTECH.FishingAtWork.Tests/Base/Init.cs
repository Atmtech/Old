using System.Collections.Generic;
using ATMTECH.Common;
using ATMTECH.Common.Utilities;
using ATMTECH.DAO;
using ATMTECH.DAO.SessionManager;
using ATMTECH.Entities;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Tests.Builder;

namespace ATMTECH.FishingAtWork.Tests.Base
{
    public class Init
    {
        private void CreateDatabase()
        {
            DatabaseSessionManager.ConnectionString = @"data source=C:\dev\Atmtech\ATMTECH.FishingAtWork.Tests\Database\FishingAtWork.db3";
            string sqlDropTable = string.Empty;
            string sql = string.Empty;
            ManageClass manageClass = new ManageClass();

            const string nameSpaceAtmtech = "ATMTECH.Entities";
            IList<string> listAtmtech = manageClass.GetAllClassesFromNameSpace(nameSpaceAtmtech);
            foreach (string s in listAtmtech)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpaceAtmtech, s);
            }

            const string nameSpace = "ATMTECH.FishingAtWork.Entities";
            IList<string> list = manageClass.GetAllClassesFromNameSpace(nameSpace);
            foreach (string s in list)
            {
                sqlDropTable += string.Format("DROP TABLE IF EXISTS [{0}];", s);
                sql += manageClass.GenerateCreateTableSqlFromClass(nameSpace, s);
            }

            BaseDao<Player, int> dao = new BaseDao<Player, int>();
            dao.ExecuteSql(sqlDropTable);
            dao.ExecuteSql(sql);
        }
        private static void CreateErrorMessage()
        {
            BaseDao<Message, int> dao = new BaseDao<Message, int>();
            Message message1 = new Message { InnerId = ErrorCode.ADM_BAD_LOGIN, Language = "fr", Description = "Vos informations d'identification ne sont pas valide." };
            Message message2 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.SC_USER_NOT_EXIST_ON_CONFIRM, Language = "fr", Description = "Vous ne pouvez pas confirmer cet utilisateur" };
            Message message3 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.SC_CAPTCHA_INVALID, Language = "fr", Description = "Veuillez saisir les chiffres dans l'image." };
            Message message4 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.SC_SEND_MAIL_FAILED, Language = "fr", Description = "L'envoi de courriel n'a pas fonctionné." };
            Message message5 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.SC_PASSWORD_DONT_EQUAL_PASSWORD_CONFIRM, Language = "fr", Description = "Le mot de passe saisi ne correspond pas à la confirmation." };
            Message message6 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.SC_INVALID_EMAIL, Language = "fr", Description = "Le courriel que vous avez saisie est invalide." };
            Message message7 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.SC_THIS_USER_ALREADY_EXIST, Language = "fr", Description = "Cet utilisateur existe déjà." };
            Message message8 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.SC_NO_USER_AUTHENTICATED, Language = "fr", Description = "Vous ne pouvez pas exécuter cette action si vous n'êtes pas préalablement authentifié par le système." };
            Message message9 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.FW_TRIP_EXIST_FOR_THIS_DATE, Language = "fr", Description = "Vous avez déjà planifié une journée de pêche pour cette date, recommencé." };
            Message message10 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.FW_NOT_ENOUGH_MONEY_TO_BUY, Language = "fr", Description = "Vous n'avez pas assez d'argent pour acheter cet item." };
            Message message11 = new Message { InnerId = FishingAtWork.Services.ErrorCode.ErrorCode.FW_CANT_BUY_QUANTITY_0, Language = "fr", Description = "Vous devez acheter une quantité supérieur à 0." };
            dao.Save(message1);
            dao.Save(message2);
            dao.Save(message3);
            dao.Save(message4);
            dao.Save(message5);
            dao.Save(message6);
            dao.Save(message7);
            dao.Save(message8);
            dao.Save(message9);
            dao.Save(message10);
            dao.Save(message11);
        }

        private static void CreateParameter()
        {
            BaseDao<Parameter, int> daoParameter = new BaseDao<Parameter, int>();
            Parameter parameter1 = new Parameter() { Code = Constant.ADMIN_MAIL, Description = "admin@admin.com" };
            daoParameter.Save(parameter1);
            Parameter parameter2 = new Parameter() { Code = Constant.MAIL_BODY_CONFIRM_CREATE, Description = @"Cliquer ici pour confirmer la création de votre compte:<br><br><a href='http:\\www.fishingatwork.com\ConfirmCreate.aspx?ConfirmCreate={0}'>Confirmer la création de mon compte</a>" };
            daoParameter.Save(parameter2);
            Parameter parameter3 = new Parameter() { Code = Constant.MAIL_SUBJECT_CONFIRM_CREATE, Description = "Nouvelle demande de création de compte" };
            daoParameter.Save(parameter3);
            Parameter parameter4 = new Parameter() { Code = Constant.MAIL_SUBJECT_FORGET_PASSWORD, Description = "Une demande d'oubli de mot de passe a été demandé." };
            daoParameter.Save(parameter4);
            Parameter parameter5 = new Parameter() { Code = Constant.MAIL_BODY_FORGET_PASSWORD, Description = "Voici votre mot de passe: {0}" };
            daoParameter.Save(parameter5);
            Parameter parameter7 = new Parameter() { Code = Constant.MAIL_SUBJECT_ORDER_FINALIZED, Description = "La commande a été passé avec succès: {0}" };
            daoParameter.Save(parameter7);
            Parameter parameter8 = new Parameter() { Code = Constant.MAIL_BODY_ORDER_FINALIZED, Description = "Voici le détail de la commande: <br>{0}" };
            daoParameter.Save(parameter8);
            Parameter parameter10 = new Parameter() { Code = "Environment", Description = "DEV" };
            daoParameter.Save(parameter10);
            Parameter parameter11 = new Parameter() { Code = "SmtpServer", Description = "smtp.gmail.com" };
            daoParameter.Save(parameter11);
            Parameter parameter12 = new Parameter() { Code = "SmtpServerLogin", Description = "sagacemarketing@gmail.com" };
            daoParameter.Save(parameter12);
            Parameter parameter13 = new Parameter() { Code = "SmtpServerPassword", Description = "10sagace01" };
            daoParameter.Save(parameter13);
            Parameter parameter14 = new Parameter() { Code = "SmtpServerPort", Description = "587" };
            daoParameter.Save(parameter14);
            Parameter parameter15 = new Parameter() { Code = "DevFromEmail", Description = "sagacemarketing@gmail.com" };
            daoParameter.Save(parameter15);
            Parameter parameter16 = new Parameter() { Code = "DevToEmail", Description = "sagacemarketing@gmail.com" };
            daoParameter.Save(parameter16);

            Parameter parameter17 = new Parameter() { Code = Constant.STATISTIC_SERVER_ONLINE, Description = "1" };
            daoParameter.Save(parameter17);
            Parameter parameter18 = new Parameter() { Code = Constant.STATISTIC_SERVER_SUCCESS_RATE, Description = "0" };
            daoParameter.Save(parameter18);
            Parameter parameter19 = new Parameter() { Code = Constant.STATISTIC_SERVER_TOTAL_SUCCESS_TODAY, Description = "0" };
            daoParameter.Save(parameter19);
            Parameter parameter20 = new Parameter() { Code = Constant.STATISTIC_SERVER_TOTAL_SUCCESS, Description = "0" };
            daoParameter.Save(parameter20);
        }
        private static void FillData()
        {
            CreateParameter();

            Lure lure1 = CreateLure("Rapala", 10);
            Lure lure2 = CreateLure("Toronto Wobbler", 10);

            Player player1 = CreatePlayer("riov01", "test", "Vincent", "Rioux", 1000, lure1, 1);
            Player player2 = CreatePlayer("tair01", "test", "Roger", "Taillefer", 2000, lure1, 1);
            Player player3 = CreatePlayer("gigl01", "test", "Lucien", "Giguere", 3000, lure1, 1);
            Player player4 = CreatePlayer("tacl01", "test", "Léon", "Taclon", 1000, lure1, 10);

            CreatePlayerLure(player1, lure2, 10);
            CreatePlayerLure(player2, lure2, 10);
            CreatePlayerLure(player3, lure2, 10);

            Site site1 = CreateSite("St-Laurent", "C'est un fleuve majestueux", 46.844767, -71.027452);
            Site site2 = CreateSite("Lac tahoe", "La rempli de poisson", 39.116477, -120.032158);

            EnumWaypointTechniqueType enumWaypointTechniqueType1 = CreateEnumWaypointTechniqueType("TRAI", "À la traine");
            EnumWaypointTechniqueType enumWaypointTechniqueType2 = CreateEnumWaypointTechniqueType("CAST", "Lancer");
            EnumWaypointTechniqueType enumWaypointTechniqueType3 = CreateEnumWaypointTechniqueType("DOWN", "Downrigger");

            Waypoint waypoint1 = CreateTrip(TripBuilder.CreateValid(), player1, site1, WaypointBuilder.CreateValid(), enumWaypointTechniqueType1, lure1);
            CreateWaypointCoordinate(waypoint1, 300, 200);
            CreateWaypointCoordinate(waypoint1, 300, 300);
            CreateWaypointCoordinate(waypoint1, 400, 300);
            CreateWaypointCoordinate(waypoint1, 400, 200);

            Waypoint waypoint2 = CreateTrip(TripBuilder.CreateValid(), player2, site2, WaypointBuilder.CreateValid(), enumWaypointTechniqueType1, lure2);
            CreateWaypointCoordinate(waypoint2, 300, 200);
            CreateWaypointCoordinate(waypoint2, 300, 300);
            CreateWaypointCoordinate(waypoint2, 400, 300);
            CreateWaypointCoordinate(waypoint2, 400, 200);


            Waypoint waypoint3 = CreateTrip(TripBuilder.CreateValid(), player3, site2, WaypointBuilder.CreateValid(), enumWaypointTechniqueType1, lure1);
            CreateWaypointCoordinate(waypoint3, 300, 200);
            CreateWaypointCoordinate(waypoint3, 300, 300);
            CreateWaypointCoordinate(waypoint3, 400, 300);
            CreateWaypointCoordinate(waypoint3, 400, 200);


            Species species1 = CreateSpeciesAndLure(SpeciesBuilder.CreateValid().WithColorName("DarkGoldenrod"), SpeciesLureBuilder.CreateValid(), lure1);
            CreateSiteSpecies(site1, species1);
            CreateSiteSpeciesCoordinate(species1, site1, 100, 100);
            CreateSiteSpeciesCoordinate(species1, site1, 100, 400);
            CreateSiteSpeciesCoordinate(species1, site1, 500, 100);
            CreateSiteSpeciesCoordinate(species1, site1, 500, 500);
            CreateSiteSpecies(site2, species1);
            CreateSiteSpeciesCoordinate(species1, site2, 100, 100);
            CreateSiteSpeciesCoordinate(species1, site2, 100, 400);
            CreateSiteSpeciesCoordinate(species1, site2, 500, 100);
            CreateSiteSpeciesCoordinate(species1, site2, 500, 500);

            Species species2 = CreateSpeciesAndLure(SpeciesBuilder.CreateValid().WithName("Truite").WithColorName("Blue"), SpeciesLureBuilder.CreateValid().WithSpecies(SpeciesBuilder.CreateValid().WithName("Truite")), lure2);
            CreateSiteSpecies(site2, species2);
            CreateSiteSpeciesCoordinate(species2, site2, 100, 100);
            CreateSiteSpeciesCoordinate(species2, site2, 100, 400);
            CreateSiteSpeciesCoordinate(species2, site2, 500, 100);
            CreateSiteSpeciesCoordinate(species2, site2, 500, 500);

            Species species3 = CreateSpeciesAndLure(SpeciesBuilder.CreateValid().WithName("Barbotte").WithColorName("Brown"), SpeciesLureBuilder.CreateValid().WithSpecies(SpeciesBuilder.CreateValid().WithName("Barbotte")), lure2);
            CreateSiteSpecies(site2, species3);
            CreateSiteSpeciesCoordinate(species3, site2, 100, 100);
            CreateSiteSpeciesCoordinate(species3, site2, 100, 200);
            CreateSiteSpeciesCoordinate(species3, site2, 200, 100);
            CreateSiteSpeciesCoordinate(species3, site2, 200, 200);

            Species species4 = CreateSpeciesAndLure(SpeciesBuilder.CreateValid().WithName("Barbue").WithColorName("SaddleBrown"), SpeciesLureBuilder.CreateValid().WithSpecies(SpeciesBuilder.CreateValid().WithName("SaddleBrown")), lure2);
            CreateSiteSpecies(site1, species4);
            CreateSiteSpeciesCoordinate(species4, site1, 100, 100);
            CreateSiteSpeciesCoordinate(species4, site1, 100, 200);
            CreateSiteSpeciesCoordinate(species4, site1, 200, 100);
            CreateSiteSpeciesCoordinate(species4, site1, 200, 200);






            CreateWallPost("Allo ça va ? ", player1);
            CreateWallPost("oui ça va toi ?... ça ne mord pas beaucoup", player2);

        }


        private static void CreateWallPost(string post, Player player)
        {
            BaseDao<WallPost, int> daoWallPost = new BaseDao<WallPost, int>();
            daoWallPost.Save(WallPostBuilder.CreateValid().WithPost(post).WithPlayer(player));
        }
        private static EnumWaypointTechniqueType CreateEnumWaypointTechniqueType(string code, string description)
        {
            BaseDao<EnumWaypointTechniqueType, int> daoEnumWaypointTechniqueType = new BaseDao<EnumWaypointTechniqueType, int>();
            EnumWaypointTechniqueType enumWaypointTechniqueType = EnumWaypointTechniqueTypeBuilder.Create().WithCode(code).WithDescription(description);
            enumWaypointTechniqueType.Id = daoEnumWaypointTechniqueType.Save(enumWaypointTechniqueType);
            return enumWaypointTechniqueType;
        }
        private static Site CreateSite(string name, string description, double lat, double lng)
        {
            BaseDao<Site, int> daoSite = new BaseDao<Site, int>();
            Site site = SiteBuilder.Create().WithName(name).WithLatitude(lat).WithLongitude(lng).WithZoom(12).WithDescription(description).WithMaxDeep(50);
            site.Id = daoSite.Save(site);
            return site;
        }
        private static Lure CreateLure(string name, double price)
        {
            BaseDao<Lure, int> daoLure = new BaseDao<Lure, int>();
            Lure lure = LureBuilder.Create().WithName(name).WithPrice(price);
            lure.Id = daoLure.Save(lure);
            return lure;
        }
        private static Player CreatePlayer(string login, string password, string firstName, string lastName, int experience, Lure lure, int lureQuantity)
        {
            BaseDao<Player, int> daoPlayer = new BaseDao<Player, int>();
            BaseDao<User, int> daoUser = new BaseDao<User, int>();
            BaseDao<PlayerLure, int> daoPlayerLure = new BaseDao<PlayerLure, int>();

            User user = UserBuilder.Create().WithLogin(login).WithPassword(password).WithFirstName(firstName).WithLastName(lastName).WithIsAdministrator(true).WithEmail("sagaan@hotmail.com");
            user.Id = daoUser.Save(user);

            Player player = PlayerBuilder.Create().WithUser(user).WithMaximumWaypoint(1).WithMoney(100).WithExperience(experience).WithImage("default.png");
            player.Id = daoPlayer.Save(player);

            PlayerLure playerLure = PlayerLureBuilder.Create().WithPlayer(player).WithLure(lure).WithQuantity(lureQuantity);
            daoPlayerLure.Save(playerLure);

            return player;
        }
        private static void CreatePlayerLure(Player player, Lure lure, int lureQuantity)
        {
            BaseDao<PlayerLure, int> daoPlayerLure = new BaseDao<PlayerLure, int>();

            PlayerLure playerLure = PlayerLureBuilder.Create().WithPlayer(player).WithLure(lure).WithQuantity(lureQuantity);
            daoPlayerLure.Save(playerLure);
        }
        private static void CreateWaypointCoordinate(Waypoint waypoint, int x, int y)
        {
            BaseDao<WaypointCoordinate, int> daoWaypointCoordinate = new BaseDao<WaypointCoordinate, int>();
            daoWaypointCoordinate.Save(WaypointCoordinateBuilder.Create().WithX(x).WithY(y).WithWaypoint(waypoint));
        }
        private static Waypoint CreateTrip(Trip trip, Player player, Site site, Waypoint waypoint, EnumWaypointTechniqueType enumWaypointTechniqueType, Lure lure)
        {
            BaseDao<Waypoint, int> daoWaypoint = new BaseDao<Waypoint, int>();
            BaseDao<Trip, int> daoTrip = new BaseDao<Trip, int>();

            trip.WithPlayer(player);
            trip.WithSite(site);

            waypoint.WithPlayer(player);
            waypoint.WithLure(lure);
            waypoint.WithTechnique(enumWaypointTechniqueType);
            waypoint.Trip = trip;
            trip.AddWayPoint(waypoint);

            trip.Id = daoTrip.Save(trip);
            waypoint.DateStart = trip.DateStart;
            waypoint.DateEnd = trip.DateEnd;
            waypoint.Id = daoWaypoint.Save(waypoint);

            return waypoint;
        }
        private static Species CreateSpeciesAndLure(Species species, SpeciesLure speciesLure, Lure lure)
        {
            BaseDao<Species, int> daoSpecies = new BaseDao<Species, int>();
            BaseDao<SpeciesLure, int> daoSpeciesLure = new BaseDao<SpeciesLure, int>();
            species.Id = daoSpecies.Save(species);
            speciesLure.WithSpecies(species);
            speciesLure.WithLure(lure);
            daoSpeciesLure.Save(speciesLure);
            return species;
        }
        private static void CreateSiteSpecies(Site site, Species species)
        {
            SiteSpecies siteSpecies = SiteSpeciesBuilder.CreateValid();
            siteSpecies.WithSite(site);
            siteSpecies.WithSpecies(species);
            BaseDao<SiteSpecies, int> daoSiteSpecies = new BaseDao<SiteSpecies, int>();
            daoSiteSpecies.Save(siteSpecies);
        }
        private static void CreateSiteSpeciesCoordinate(Species species, Site site, double x, double y)
        {
            BaseDao<SiteSpeciesCoordinate, int> daoSiteSpeciesCoordinate = new BaseDao<SiteSpeciesCoordinate, int>();
            SiteSpeciesCoordinate siteSpeciesCoordinate1 = SiteSpeciesCoordinateBuilder.Create().WithCoordinate(CoordinateBuilder.Create().WithX(x).WithY(y));
            siteSpeciesCoordinate1.WithSpecies(species).WithSite(site);
            daoSiteSpeciesCoordinate.Save(siteSpeciesCoordinate1);
        }

        public void InitDatabaseForTest()
        {
            CreateDatabase();
            CreateErrorMessage();
            FillData();
        }

    }
}

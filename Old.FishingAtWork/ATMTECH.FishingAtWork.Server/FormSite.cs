using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
//using ATMTECH.ApplicationConfiguration;
using ATMTECH.FishingAtWork.DAO.Interface;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using Autofac;
using IContainer = Autofac.IContainer;
namespace ATMTECH.FishingAtWork.Server
{
    public partial class FormSite : Form
    {
        public static IContainer ServiceContainer { get; set; }

        public static ISiteService SiteService
        {
            get { return ServiceContainer.Resolve<ISiteService>(); }
        }

        public static IDAOCoordinateTry DAOCoordinateTry
        {
            get { return ServiceContainer.Resolve<IDAOCoordinateTry>(); }
        }


        public int IdSite { get; set; }

        public FormSite()
        {
            InitializeComponent();
        }

        public Site SiteForm { get; set; }

        private void FormDisplayMap_Load(object sender, EventArgs e)
        {
            //ServiceConfiguration serviceConfiguration = new ServiceConfiguration();
            //serviceConfiguration.Configure();
            //ServiceContainer = serviceConfiguration.ContainerProvider.ApplicationContainer;
            //SiteForm = SiteService.GetSite(IdSite);
            
            //lblSite.Text = SiteForm.Name;

            //if (File.Exists(FileNameScreenShot))
            //{
            //    pnlCoordinate.BackgroundImage = new Bitmap(FileNameScreenShot);
            //}

        }

        public string FileNameScreenShot { get { return SiteForm.Name + ".png"; } }

        private Color GetColor(string color)
        {
            if (!string.IsNullOrEmpty(color))
            {
                return Color.FromName(color);
            }
            else
            {
                return Color.Red;
            }
        }



        private void btnShowCoordinate_Click(object sender, EventArgs e)
        {
            pnlCoordinate.Invalidate();
        }

        private void DrawPolygonSpecies(IList<SiteSpeciesCoordinate> siteSpeciesCoordinates, Color color)
        {

            Point[] pp = new Point[siteSpeciesCoordinates.Count];

            int i = 0;
            foreach (SiteSpeciesCoordinate siteSpeciesCoordinate in siteSpeciesCoordinates)
            {
                pp[i] = new Point((int)siteSpeciesCoordinate.X, (int)siteSpeciesCoordinate.Y);
                i++;
            }

            Graphics G = pnlCoordinate.CreateGraphics();
            Pen pen1 = new Pen(color, 2F);

            G.DrawPolygon(pen1, pp);
        }

        private void pnlCoordinate_Paint(object sender, PaintEventArgs e)
        {
            foreach (SiteSpecies siteSpeciese in SiteForm.SiteSpecies)
            {
                DrawPolygonSpecies(siteSpeciese.Area, Color.FromName(siteSpeciese.Species.ColorName));
            }

            IList<CoordinateTry> coordinateTries = DAOCoordinateTry.GetAllCoordinate(SiteForm);
            foreach (CoordinateTry coordinateTry in coordinateTries)
            {
                SolidBrush hb = new SolidBrush(GetColor(coordinateTry.ColorName));
                e.Graphics.FillRectangle(hb, Convert.ToInt32(coordinateTry.X), Convert.ToInt32(coordinateTry.Y), 5, 5);
            }
        }

    }
}

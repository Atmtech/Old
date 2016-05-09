using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using ATMTECH.ApplicationConfiguration;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Base;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.Web.Services.Interface;
using Autofac;
using IContainer = Autofac.IContainer;

namespace ATMTECH.FishingAtWork.Server
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public static IContainer ServiceContainer { get; set; }
        public static ISiteService SiteService { get { return ServiceContainer.Resolve<ISiteService>(); } }
        public static ITripService TripService { get { return ServiceContainer.Resolve<ITripService>(); } }
        public static ICatchService CatchService { get { return ServiceContainer.Resolve<ICatchService>(); } }
        public static IParameterService ParameterService { get { return ServiceContainer.Resolve<IParameterService>(); } }

        private decimal _totalTest = 0;
        private decimal _totalSuccess = 0;
        private int _totalSuccessInitial;
        private readonly DateTime _startTime = DateTime.Now;

        private void timerTrip_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
            try
            {
                ParameterService.SetValue(Constant.STATISTIC_SERVER_ONLINE, "1");

                IList<Trip> trips = TripService.GetAllCurrentTrip();

                foreach (Trip trip in trips)
                {
                    IList<SpeciesCatch> speciesCatches = CatchService.Catch(trip.Site);
                    AddStatus(trip, speciesCatches);
                    _totalTest++;
                }
                UpdateListSite();

                TimeSpan span = DateTime.Now.Subtract(_startTime);

                if (_totalTest == 0)
                {
                    lblStatusTotalCount.Text = "Évaluation des réussite: Aucune journée de pêche";
                }
                else
                {

                    int totalToSave = _totalSuccessInitial + Convert.ToInt32(_totalSuccess);
                    ParameterService.SetValue(Constant.STATISTIC_SERVER_TOTAL_SUCCESS, totalToSave.ToString());
                    ParameterService.SetValue(Constant.STATISTIC_SERVER_TOTAL_SUCCESS_TODAY, _totalSuccess.ToString());
                    ParameterService.SetValue(Constant.STATISTIC_SERVER_SUCCESS_RATE, Math.Round(((_totalSuccess / _totalTest) * 100), 2).ToString());

                    lblStatusTotalCount.Text = "Évaluation des réussite: " + _totalSuccess.ToString() + " Succès / " + _totalTest.ToString() + " Tentative = Taux de réussite: " + Math.Round(((_totalSuccess / _totalTest) * 100), 2).ToString() + " % pendant " + span.Hours + "H :" + span.Minutes + "M :" + span.Seconds + "S";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void AddStatus(Trip trip, IList<SpeciesCatch> speciesCatches)
        {
            foreach (SpeciesCatch speciesCatch in speciesCatches)
            {
                if (speciesCatch.IsSuccessfulCatch)
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.Text = trip.Name;
                    listViewItem.SubItems.Add(trip.Site.Name);
                    listViewItem.SubItems.Add(speciesCatch.Player.User.FirstNameLastName);
                    listViewItem.SubItems.Add(speciesCatch.Lure.Name);
                    listViewItem.SubItems.Add(speciesCatch.Species.Name);
                    listViewItem.SubItems.Add(speciesCatch.Weight.ToString());
                    lstStatus.Items.Add(listViewItem);
                    _totalSuccess++;



                }
            }
        }

        private void UpdateListSite()
        {
            lstSite.Items.Clear();
            IList<Site> sites = SiteService.GetSiteList();

            foreach (Site site in sites)
            {
                int i = 0;

                IList<Trip> trips = TripService.GetAllCurrentTrip();
                foreach (Trip trip in trips)
                {
                    if (trip.Site.Id == site.Id)
                    {
                        i++;
                    }
                }
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Tag = site.Id;
                listViewItem.Text = site.Name;
                listViewItem.SubItems.Add(i.ToString());
                listViewItem.SubItems.Add(CatchService.GetCountCatch(site).ToString());
                listViewItem.SubItems.Add(site.SiteSpecies.Count.ToString());

                lstSite.Items.Add(listViewItem);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //ServiceConfiguration serviceConfiguration = new ServiceConfiguration();
            //serviceConfiguration.Configure();
            //ServiceContainer = serviceConfiguration.ContainerProvider.ApplicationContainer;
            //_totalSuccessInitial = Convert.ToInt32(ParameterService.GetValue(Constant.STATISTIC_SERVER_TOTAL_SUCCESS));
        }


        private void btnSetTimer_Click(object sender, EventArgs e)
        {
            timerTrip.Enabled = false;
            timerTrip.Interval = Convert.ToInt32(cmbTimer.Text);
            timerTrip.Enabled = true;
        }

        private void lstSite_MouseClick(object sender, MouseEventArgs e)
        {
            //FormSite formDisplayMap = new FormSite();

            //if ((sender as ListView).FocusedItem != null)
            //{
            //    formDisplayMap.IdSite = Convert.ToInt32((sender as ListView).FocusedItem.Tag);
            //    formDisplayMap.ShowDialog();
            //}
        }

        private void timerOnline_Tick(object sender, EventArgs e)
        {
            ParameterService.SetValue(Constant.STATISTIC_SERVER_ONLINE, "1");
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ParameterService.SetValue(Constant.STATISTIC_SERVER_ONLINE, "0");
        }


    }
}

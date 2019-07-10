using System;
using System.Collections.Generic;
using System.Threading;

namespace ATMTECH.Expeditn.Services
{
    public class CeduleurService
    {
        private static CeduleurService _instance;
        public List<Timer> liteTimer = new List<Timer>();

        private CeduleurService() { }

        public static CeduleurService Instance => _instance ?? (_instance = new CeduleurService());

        public void ResetSchedule()
        {
            liteTimer.Clear();
        }
        public void CeduleTache(int heure, int minute, double intervaleEnHeure, Action tache)
        {
            DateTime now = DateTime.Now;
            DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, heure, minute, 0, 0);
            if (now > firstRun)
            {
                firstRun = firstRun.AddDays(1);
            }

            TimeSpan timeToGo = firstRun - now;
            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }

            if (tache != null)
            {

                var timer = new Timer(x =>
                {
                    
                    tache.Invoke();
                }, null, timeToGo, TimeSpan.FromHours(intervaleEnHeure));

                
                liteTimer.Add(timer);
            }
        }
    }
}

using System.Collections.Generic;
using ATMTECH.FishingAtWork.Entities;
using ATMTECH.FishingAtWork.Services.Interface;
using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class AdminLurePresenter : BaseFishingAtWorkPresenter<IAdminLurePresenter>
    {
        public ILureService LureService { get; set; }
        public AdminLurePresenter(IAdminLurePresenter view)
            : base(view)
        {
        }

        public IList<Lure> GetLure(string parametreTrie, int nbEnreg, int indexDebutRangee)
        {
            return LureService.GetLureList();
        }

        public int GetLureCount()
        {
            return LureService.GetLureList().Count;
        }

        public void OpenLure(int idLure)
        {
            Lure lure = LureService.GetLure(idLure);
            View.Id = idLure;
            View.Name = lure.Name;
            View.Price = lure.Price;
            View.IsInEditMode = true;
        }

        public void Save()
        {
            Lure lure = LureService.GetLure(View.Id) ?? new Lure();
            lure.Name = View.Name;
            lure.Price = View.Price;
            lure.IsActive = true;
            
        }
    }
}

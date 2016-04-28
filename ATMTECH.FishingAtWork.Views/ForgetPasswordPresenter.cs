using ATMTECH.FishingAtWork.Views.Interface;

namespace ATMTECH.FishingAtWork.Views
{
    public class ForgetPasswordPresenter : BaseFishingAtWorkPresenter<IForgetPasswordPresenter>
    {
     //   public ICustomerService CustomerService { get; set; }

        public ForgetPasswordPresenter(IForgetPasswordPresenter view)
            : base(view)
        {
        }

        public void SendMail()
        {
          //  CustomerService.SendForgetPassword(View.Email);
        }
    }
}

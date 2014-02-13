namespace ATMTECH.Web.Services.Interface
{
    public interface IParameterService
    {
        string GetValue(string code);
        void SetValue(string code, string value);
    }
}

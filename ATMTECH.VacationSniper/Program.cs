using ATMTECH.VacationSniper.Services;

namespace ATMTECH.VacationSniper
{
    class Program
    {
        static void Main(string[] args)
        {

            string version = System.Reflection.Assembly.GetExecutingAssembly()
              .GetName()
              .Version
              .ToString();


            new VacationSniperService().Snipe();
            new VacationSniperService().ConstruireHtml(version);
        }
    }


}

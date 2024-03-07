using Microsoft.Extensions.Configuration;

namespace Platform.Persistence.Services
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "C:\\inetpub\\wwwroot\\Platform\\Platform.Api"));
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..\\Platform.Api"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}

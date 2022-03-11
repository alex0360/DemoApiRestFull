using Microsoft.Extensions.Configuration;

namespace Persistence.Local
{
    public class Settings
    {
        public class Parameterize
        {
            private IConfiguration Configuration { get; }

            public Parameterize(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public string Path => Configuration.GetValue<string>("Connection:sqlite:path");
            public  int Version => Configuration.GetValue<int>("Connection:sqlite:version");
            public  string Cache => Configuration.GetValue<string>("Connection:sqlite:cache");
            public string PasswordLite => Configuration.GetValue<string>("Connection:sqlite:password");
            public string DataSource => Configuration.GetValue<string>("Connection:sqlserver:dataSource");
            public string DataBase => Configuration.GetValue<string>("Connection:sqlserver:dataBase");
            public string UserId => Configuration.GetValue<string>("Connection:sqlserver:userId");
            public string PasswordServer => Configuration.GetValue<string>("Connection:sqlserver:password");

        }
    }
}
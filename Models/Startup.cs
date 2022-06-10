using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace APILab.Models
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;       
        }

        public Startup()
        {
        }

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");

        }
    }
}

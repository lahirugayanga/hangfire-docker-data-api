using data_api.Filters;
using Hangfire;
using Hangfire.Dashboard;

namespace data_api.ServiceExtensions
{
    public static class HangfireExtension
    {
        public static IServiceCollection RegisterHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHangfire((ProviderAliasAttribute, options) =>
            {
                options.UseSqlServerStorage(configuration.GetConnectionString("DataApiConnectionString"), new Hangfire.SqlServer.SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true
                });
            });
            services.AddHangfireServer(options => { });
            return services;
        }

        public static WebApplication UseHangfireService(this WebApplication app)
        {
            var options = new DashboardOptions
            {
                Authorization = new[]
                {
                    new DashboardAuthorization(new[]
                    {
                        new HangfireUserCredentials
                        {
                            UserName="admin",
                            Password="abc@123"
                        }
                    })
                }
            };
            app.UseHangfireDashboard("/hangfire", options);
            return app;
        }
    }
}

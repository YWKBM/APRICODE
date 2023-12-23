using Games.Persistence;
using Games.Application.Common.Mappings;
using System.Reflection;
using Games.Application.Interfaces;
using Games.Application;
using App.Metrics.Formatters.Prometheus;

namespace Games.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IGamesDbContext).Assembly));
            });
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);

            builder.Host
                .UseMetricsWebTracking(options =>
                {
                    options.OAuth2TrackingEnabled = true;
                })
                .UseMetricsEndpoints(options =>
                {
                    options.EnvironmentInfoEndpointEnabled = false;
                    options.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                    options.MetricsEndpointOutputFormatter = new MetricsPrometheusProtobufOutputFormatter();
                });

            builder.Services.AddControllers();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<GamesDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    //TODO: exception message
                }
            }

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            

            app.Run();
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GraphService {
    public class Startup {
        public Startup (IWebHostEnvironment env) { }

        public void ConfigureServices (IServiceCollection services) {

            // Cors
            services.AddCors (options => {
                options.AddPolicy ("allowAll",
                    builder => builder
                    .SetIsOriginAllowed (host => true)
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ());
            });

            services.AddControllers ();
        }

        public void Configure (IApplicationBuilder app) {

            var options = new DefaultFilesOptions ();
            options.DefaultFileNames.Clear ();
            options.DefaultFileNames.Add ("app.html");
            app.UseDefaultFiles (options);
            app.UseStaticFiles ();

            app.UseCors ("AllowAll");

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}
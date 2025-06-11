using Figura.SpeedwayNetwork.Api.Extensions;

namespace Figura.SpeedwayNetwork.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //enalbe cors
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();

            services.AddEndpointsApiExplorer().AddSwaggerGen();

            services.IncludeNetworkDb(Configuration)
                    .IncludeNetworkService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //enable cors
            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), "dll_files")),
            //    RequestPath = "/dll_files"
            //});

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

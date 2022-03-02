using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VectoInterview.Services;
using VectoInterview.Services.Interfaces;

namespace VectoInterview
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IImageService, ImageService>();
            services.AddSingleton<ISimpleEffectCorrector, SimpleEffect1CorrectorFake>();
            services.AddSingleton<ISimpleEffectCorrector, SimpleEffect2CorrectorFake>();
            services.AddSingleton<ISimpleEffectCorrector, SimpleEffect3CorrectorFake>();
            services.AddSingleton<IParameterizedEffectCorrector, ParameterizedEffect1CorrectorFake>();
            services.AddSingleton<IParameterizedEffectCorrector, ParameterizedEffect2CorrectorFake>();
            services.AddSingleton<IParameterizedEffectCorrector, ParameterizedEffect3CorrectorFake>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VectoInterview", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VectoInterview v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
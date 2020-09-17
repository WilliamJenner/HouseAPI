namespace House
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using House.BLL;
    using House.BLL.Interfaces;
    using House.DAL;
    using House.DAL.Interfaces;
    using Scrutor;
    using System.CodeDom.Compiler;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton(provider => new ConnectionStrings
            {
                WeeklyDigest = Configuration.GetConnectionString("WeeklyDigest")
            });
            services.AddSwaggerGen(c =>
            {
                c.GeneratePolymorphicSchemas();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "House API",
                    Version = "1.0",
                    Description =
                        "An api for the house.",
                    Contact = new OpenApiContact
                    {
                        Name = "The boys",
                        Email = "house@theroad.uk"
                    },


                });

            });

            ScanForAllRemainingRegistrations(services);
        }

        public static void ScanForAllRemainingRegistrations(IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(Startup), typeof(Hello), typeof(BaseRepository))
                .AddClasses(x => x.WithoutAttribute(typeof(GeneratedCodeAttribute)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "House API");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

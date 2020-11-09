namespace House.API
{
    using System.CodeDom.Compiler;
    using DAL;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;
    using Scrutor;
    using HLL.Dashboard.Bindicator;
    using HLL.Dashboard.Bindicator.Models;
    using HLL.Dashboard.WeatherFeed.Models;
    using ConnectionStrings = HLL.ConnectionStrings;
    using House.HLL.Alert.Models;
    using House.DAL.Repositories;
    using House.API.CronJobs;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.UseOneOfForPolymorphism();

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

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .WithMethods("GET", "POST", "PUT", "DELETE")
                        .WithOrigins("http://localhost", "https://localhost", "https://localhost:44359", "https://localhost:44370", "http://192.168.0.69:420");
                });
            });

            services.Configure<Lookup>(option => Configuration.GetSection("Lookup").Bind(option));
            services.Configure<ConnectionStrings>(option => Configuration.GetSection("ConnectionStrings").Bind(option));
            services.Configure<OpenWeatherApi>(option => Configuration.GetSection("OpenWeatherApi").Bind(option));
            services.Configure<NewsApi>(option => Configuration.GetSection("NewsApi").Bind(option));
            services.Configure<DbConnections>(option => Configuration.GetSection("DbConnections").Bind(option));
            services.AddHostedService<AutoConsumeNews>();
            ScanForAllRemainingRegistrations(services);
        }

        public static void ScanForAllRemainingRegistrations(IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(Startup), typeof(BindicatorProvider), typeof(BaseRepository))
                .AddClasses(x => x.WithoutAttribute(typeof(GeneratedCodeAttribute)))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithTransientLifetime()); 
            //To stop the hosted service crying register services as transient by default, not scoped. This API is stateless so shouldn't cause issues
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
                app.UseHsts();
            }

            app.UseCors("SiteCorsPolicy");

            app.UseHttpsRedirection();

            app.UseMvc();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "House API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

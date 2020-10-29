using System.IO;
using System.Text;
using AutoMapper;
using dms_api.Data;
using dms_api.Services.CatalogService;
using dms_api.Services.DepartmentService;
using dms_api.Services.DivisionService;
using dms_api.Services.DocumentService;
using dms_api.Services.DriveService;
using dms_api.Services.FileDirectoryService;
using dms_api.Services.LocationService;
using dms_api.Services.RootDirectoryService;
using dms_api.Services.SectionService;
using dms_api.Services.UserCatalogService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace dms_api
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
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddScoped<IAuthRepository, AuthRepository>(); //authentication repository
            services.AddScoped<ICatalogService, CatalogService>();
            services.AddScoped<IDepartmentService, DepartmentService>(); //department service
            services.AddScoped<IDivisionService, DivisionService>(); //division service
            services.AddScoped<IDriveService, DriveService>(); // logical drive service
            services.AddScoped<IDocumentService, DocumentService>(); // document service
            services.AddScoped<IFileDirectoryService, FileDirectoryService>(); // file directory service
            services.AddScoped<ILocationService, LocationService>(); //location service
            services.AddScoped<IRootDirectoryService, RootDirectoryService>();
            services.AddScoped<ISectionService, SectionService>(); //section service
            services.AddScoped<IUserCatalogService, UserCatalogService>(); //userCatalog service.

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //HttpAccessor

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                        .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using ArtIsPain.Server.Data;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Data.Repositories;
using ArtIsPain.Server.Data.Seed;
using ArtIsPain.Shared.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

namespace ArtIsPain.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISeedDataBuilder, BandBuilder>();
            services.AddScoped<ISeedDataBuilder, BandLogoBuilder>();
            services.AddScoped<ISeedDataBuilder, WriterBuilder>();
            services.AddScoped<ISeedDataBuilder, SongBuilder>();

            services.AddScoped<IRepository<Band>, BandRepository>();

            services.AddAutoMapper(typeof(BandRepository));

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<DataContext>(
                db => db.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
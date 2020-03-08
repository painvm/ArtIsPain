using ArtIsPain.Server.Data;
using ArtIsPain.Server.Data.Interfaces;
using ArtIsPain.Server.Data.Repositories;
using ArtIsPain.Server.Data.Seed;
using ArtIsPain.Server.Filters;
using ArtIsPain.Shared.Models;
using AutoMapper;
using FluentValidation.AspNetCore;
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
            #region Data Builders

            services.AddScoped<ISeedDataBuilder, BandBuilder>();
            services.AddScoped<ISeedDataBuilder, BandLogoBuilder>();
            services.AddScoped<ISeedDataBuilder, WriterBuilder>();
            services.AddScoped<ISeedDataBuilder, SongBuilder>();

            #endregion Data Builders

            #region Repositories

            services.AddScoped<IRepository<Band>, BandRepository>();
            services.AddScoped<IRepository<Writer>, WriterRepository>();
            services.AddScoped<IRepository<MusicalAlbum>, AlbumRepository>();
            services.AddScoped<IRepository<PoetryVolume>, PoetryVolumeRepository>();

            services.AddScoped<IMultiAuthorizedRepository<PoetryVolumeAuthorship>, PoetryVolumeAuthorshipRepository>();

            services.AddScoped<IAuthorizedRepository<MusicalAlbum>, AlbumRepository>();

            #endregion Repositories

            #region AutoMapper

            services.AddAutoMapper(typeof(BandRepository));
            services.AddAutoMapper(typeof(PoetryVolumeRepository));
            services.AddAutoMapper(typeof(WriterRepository));
            services.AddAutoMapper(typeof(AlbumRepository));

            #endregion AutoMapper

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<DataContext>(
                db => db.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(RequestValidationFilter));
                options.Filters.Add(typeof(UpsertBandCommandFilter));
            })
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddNewtonsoftJson();

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
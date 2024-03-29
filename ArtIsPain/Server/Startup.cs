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
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Server.Filters;
using System.Linq;
using System.Reflection;
using Microsoft.OpenApi.Models;
using System.IO;
using System;
using Swashbuckle.AspNetCore.Filters;
using ArtIsPain.Server.RequestExamples;

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
            services.AddScoped<IRepository<Song>, SongRepository>();
            services.AddScoped<IRepository<PoetryVolume>, PoetryVolumeRepository>();

            services.AddScoped<IMultiAuthorizedRepository<PoetryVolumeAuthorship>, PoetryVolumeAuthorshipRepository>();

            services.AddScoped<IAuthorizedRepository<MusicalAlbum>, AlbumRepository>();

            #endregion Repositories

            #region AutoMapper

            services.AddAutoMapper(typeof(BandRepository));
            services.AddAutoMapper(typeof(PoetryVolumeRepository));
            services.AddAutoMapper(typeof(WriterRepository));
            services.AddAutoMapper(typeof(AlbumRepository));
            services.AddAutoMapper(typeof(SongRepository));

            #endregion AutoMapper

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<DataContext>(
                db => db.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(RequestValidationFilter));
                options.Filters.Add(typeof(UpsertBandCommandFilter));
                options.Filters.Add(typeof(UpsertAlbumCommandFilter));
            })
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddCors();

            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                     Title = "ArtisAPI",
                     Version = "v1",
                     Description = "Pre-Alpha API library build of upcoming platform for all the people involved in art related areas" 
                });

                c.OperationFilter<AddResponseHeadersFilter>();

                c.ExampleFilters();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseResponseCompression();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger";
            });

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
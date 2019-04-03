using AdvocacyPro.Models.Constants;
using AdvocacyPro.Models.DTO;
using AdvocacyPro.Services;
using AdvocacyPro.Services.Auth;
using AdvocacyPro.Services.Extensions;
using AdvocacyPro.Services.Utility;
using AdvocacyPro.Services.Values;
using AdvocacyPro.Web.Server.Attributes;
using AdvocacyPro.Web.Server.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AdvocacyPro.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment _hostingEnvironment { get; set; }
        public ILoggerFactory _loggerFactory { get; set; }

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddCSPIdentity();

            services.AddCSPDbContext(Configuration);

            services.AddTransient<AuthLogic>();
            services.AddTransient<AgeGroupingLogic>();
            services.AddTransient<ApplicationStatusLogic>();
            services.AddTransient<BondTypeLogic>();
            services.AddTransient<CaseLogic>();
            services.AddTransient<CaseIncidentLogic>();
            services.AddTransient<CaseEmergencyContactLogic>();
            services.AddTransient<CaseCourtDateLogic>();
            services.AddTransient<CaseCVCApplicationLogic>();
            services.AddTransient<CaseInterviewLogic>();
            services.AddTransient<CaseLetterLogic>();
            services.AddTransient<CasePaymentLogic>();
            services.AddTransient<CaseProtectiveOrderLogic>();
            services.AddTransient<CaseVictimizationLogic>();
            services.AddTransient<CaseReferralLogic>();
            services.AddTransient<ContactTypeLogic>();
            services.AddTransient<DocumentTypeLogic>();
            services.AddTransient<ReferralTypeLogic>();
            services.AddTransient<CaseServiceLogic>();
            services.AddTransient<CaseNoteLogic>();
            services.AddTransient<CaseContactLogic>();
            services.AddTransient<CaseDocumentLogic>();
            services.AddTransient<CaseWitnessLogic>();
            services.AddTransient<CasePoliceLogic>();
            services.AddTransient<CaseOffenderLogic>();
            services.AddTransient<ServiceCategoryLogic>();
            services.AddTransient<ServicePopulationLogic>();
            services.AddTransient<ServiceProgramLogic>();
            services.AddTransient<CountryLogic>();
            services.AddTransient<DocketTypeLogic>();
            services.AddTransient<EthnicityLogic>();
            services.AddTransient<FireCauseLogic>();
            services.AddTransient<FireLogic>();
            services.AddTransient<GenderLogic>();
            services.AddTransient<InterviewDocumentationTypeLogic>();
            services.AddTransient<InterviewerPositionLogic>();
            services.AddTransient<LanguageLogic>();
            services.AddTransient<LetterTypeLogic>();
            services.AddTransient<LocationTypeLogic>();
            services.AddTransient<OffenseLogic>();
            services.AddTransient<OffenseTypeLogic>();
            services.AddTransient<OrderStatusLogic>();
            services.AddTransient<OrderTypeLogic>();
            services.AddTransient<OrganizationLogic>();
            services.AddTransient<OrganizationTypeLogic>();
            services.AddTransient<PaymentCategoryLogic>();
            services.AddTransient<PayorLogic>();
            services.AddTransient<RaceLogic>();
            services.AddTransient<RelationshipTypeLogic>();
            services.AddTransient<ReportLogic>();
            services.AddTransient<StateLogic>();
            services.AddTransient<StatusLogic>();
            services.AddTransient<UserLogic>();
            services.AddTransient<VictimTypeLogic>();
            services.AddTransient<ZipCodeLogic>();
            services.AddTransient<LocationsLogic>();
            services.AddTransient<ObjectLogic>();
            services.AddSingleton<FeatureLogic>();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                if (_hostingEnvironment.IsDevelopment())
                    loggingBuilder.AddDebug();
                loggingBuilder.AddDBLogger(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddMvc(config => {
                config.Filters.Add(new ExceptionHandlingAttribute(_loggerFactory));
                config.CacheProfiles.Add(CacheProfiles.Never, new CacheProfile()
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                });
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAuthorization(options =>
            {
                foreach (Feature f in new FeatureLogic().GetAll())
                {
                    options.AddPolicy(f.Value, policy => policy.RequireAssertion(ctx => {
                        return ctx.User.HasClaim(ProductFeaturesClaimType.Value, f.Value);
                    }));
                }
            });

            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
                      {
                          cfg.RequireHttpsMetadata = _hostingEnvironment.IsDevelopment() ? false : true;
                          //cfg.SaveToken = true;

                          cfg.TokenValidationParameters = new TokenValidationParameters()
                          {
                              ValidateIssuer = true,
                              ValidateAudience = true,
                              ValidateLifetime = true,
                              ValidateIssuerSigningKey = true,
                              ValidIssuer = Configuration["TokenAuthentication:Issuer"],
                              ValidAudience = Configuration["TokenAuthentication:Audience"],
                              IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["TokenAuthentication:SecretKey"])),
                              RequireExpirationTime = true
                          };

                          cfg.Events = new JwtBearerEvents
                          {
                              OnAuthenticationFailed = context =>
                              {
                                  Console.WriteLine("OnAuthenticationFailed: " +
                                      context.Exception.Message);
                                  return Task.CompletedTask;
                              },
                              OnTokenValidated = context =>
                              {
                                  Console.WriteLine("OnTokenValidated: " +
                                      context.SecurityToken);
                                  return Task.CompletedTask;
                              }
                          };

                      });

            if (_hostingEnvironment.IsDevelopment())
            {
                // Register the Swagger generator, defining 1 or more Swagger documents
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<HeadersMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

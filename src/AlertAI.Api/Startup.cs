using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AlertAI.Core.Services;
using AlertAI.Infrastructure.Data;
using AlertAI.Infrastructure.Repositories;
using AlertAI.Infrastructure.Services;
using AlertAI.Authentication.OAuth;

namespace AlertAI.Api
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
            services.AddControllers();

            // Configure database context
            services.AddDbContext<NotificationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configure services
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPushNotificationService, PushNotificationService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            services.AddScoped<IAppleAuthService, AppleAuthService>();
            services.AddScoped<IFacebookAuthService, FacebookAuthService>();

            // Add authentication services here

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AlertAI API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlertAI API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Add authentication middleware here

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
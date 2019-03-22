using CloseTalk.Persistence;
using CloseTalk.Persistence.Repositories.Implementations;
using CloseTalk.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi
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
            services.AddMvc();
            services.AddDbContextPool<AppDbContext>(options => options
                .UseSqlServer(Configuration["Data:Work:ConnectionString"]));
            
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

           app.UseMvc(routes =>
           {
               routes.MapRoute(
                   name: null,
                   template: "{controller=Home}/{action=index}/{id?}");
           });
        }
    }
}

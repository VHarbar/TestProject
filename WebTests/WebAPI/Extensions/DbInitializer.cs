
using DataAcessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class DbInitializer
    {
        public static WebApplication DbInitialize(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
                try
                {
                    var scopedContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
                    DbInitializer.Initializer(scopedContext);
                }
                catch
                {
                    throw;
                }

            return app;
        }
        public static void Initializer(
           DataBaseContext context)
        {
            context.Database.EnsureCreated();
       
            
        }
    }
}

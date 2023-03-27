using BusinessLogicLayer.Mapping;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllersWithViews();
    builder.Services.AddAutoMapper(config =>
    {
        config.AddProfile(typeof(AppMappingProfile));
    });
    builder.Services.AddCors(option =>  // adding acess to other web-pages
    {
        option.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    });

    builder.Services.AddEndpointsApiExplorer();
    

    builder.Services
        .AddSQL(builder.Configuration)
        .AddService(builder.Configuration);

}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
       
       
    }


    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseCors("AllowAll");

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.DbInitialize();

    app.Run();
}
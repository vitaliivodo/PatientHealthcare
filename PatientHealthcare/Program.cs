using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using PatientHealthcare.DataAccessCore;
using PatientHealthcare.DataAccessCore.Repository;
using PatientHealthcare.DataAccessCore.Repository.Interfaces;
using PatientHealthcare.DataAccessCore.Services;
using PatientHealthcare.DataAccessCore.Services.Interfaces;
using PatientHealthcare.Infrastructure.Initialize;
using PatientHealthcare.Infrastructure.Initialize.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("PatientHealthcare")));

builder.Services.AddScoped<IGlobalRepository, GlobalRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddTransient<IApplicationInitializer, ApplicationInitializer>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "PatientHealthcareApp/dist";
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatientHealthcare API V1");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSpaStaticFiles();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(routes =>
{
    routes.MapDefaultControllerRoute();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "PatientHealthcareApp";

    if (app.Environment.IsDevelopment())
    {
        spa.UseAngularCliServer(npmScript: "start");
    }
});

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    using (var context = serviceScope.ServiceProvider.GetService<DataContext>())
    {
        try
        {
            context.Database.Migrate();

            IApplicationInitializer applicationInitializer = serviceScope.ServiceProvider.GetService<IApplicationInitializer>();

            int appresult = applicationInitializer.Initialize().Result;

            int result = context.Initialize().Result;
        }
        catch
        {
            throw;
        }
    }
}

app.Run();

using Microsoft.EntityFrameworkCore;
using PatientHealthcare.DataAccessCore;
using PatientHealthcare.DataAccessCore.Repository;
using PatientHealthcare.DataAccessCore.Repository.Interfaces;
using PatientHealthcare.Infrastructure.Initialize;
using PatientHealthcare.Infrastructure.Initialize.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DataContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.MigrationsAssembly("PatientHealthcare")));

builder.Services.AddScoped<IGlobalRepository, GlobalRepository>();
builder.Services.AddScoped<IApplicationInitializer, ApplicationInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

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

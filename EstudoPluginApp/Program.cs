
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(cb =>
{
    foreach (var file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*plugin*.dll", SearchOption.TopDirectoryOnly))
    {
        var assembly = Assembly.LoadFrom(file);
        cb.RegisterAssemblyModules(assembly);
    }
}))
    .ConfigureServices(services => services.AddAutofac());
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

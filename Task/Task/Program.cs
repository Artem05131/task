using Task.Infrastructure.Business;
using Task.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IWordCounter, WordCounter>();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints=> endpoints.MapControllerRoute("default", "{controller=Home}/{action=Home}"));

app.Run();

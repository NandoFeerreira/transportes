using Microsoft.EntityFrameworkCore;
using TRANSPORTES.REPOSITORY;
using TRANSPORTES.WEB.Context;
using TRANSPORTES.WEB.Factorys;
using TRANSPORTES.WEB.Factorys.Interfaces;
using TRANSPORTES.WEB.Repositories;
using TRANSPORTES.WEB.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var mySqlConnection = builder.Configuration.GetConnectionString("Conection");

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


#region [ INJEÇÃO DE DEPENDÊNCIA ] 

#region [ REPOSITORIES ] 

builder.Services.AddScoped<IEntidadeClienteRepository, EntidadeClienteRepository>();
builder.Services.AddScoped<IConteinerRepository, ConteinerRepository>();
builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();

#endregion

#region [ FACTORIES ]

builder.Services.AddScoped<IEntidadeClienteFactory, EntidadeClienteFactory>();

#endregion

#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var hangfireConnectionString = "Server=NB317493; Database=DbCronJobHangfire; Trusted_Connection=True";
builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(hangfireConnectionString);
    RecurringJob.AddOrUpdate<TransferData.Controllers.HomeController>(j => j.DbToDb(), cronExpression: "*/5 * * * *");


});
builder.Services.AddHangfireServer();

//IOC
builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal, DpProductDal>();

builder.Services.AddSingleton<IUrunService, UrunManager>();
builder.Services.AddSingleton<IUrunDal, DpUrunDal>();

builder.Services.AddSingleton<IDataTransferService, DataTransferManager>();
builder.Services.AddSingleton<IDataTransferDal, DpDataTransferDal>();

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

app.UseAuthorization();

app.UseHangfireDashboard(pathMatch: "/hangfire");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

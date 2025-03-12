var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Uygulama baþlatýldýðýnda varsayýlan olarak açýlacak sayfayý belirler.
// "{controller=Home}/{action=Index}/{id?}" formatý þu anlama gelir:
// - Eðer bir özel yönlendirme yapýlmazsa, "Home" controller'ýnýn "Index" action'ý çalýþtýrýlýr.
// - Opsiyonel "id" parametresi kullanýlabilir.
// Bu yapý, ASP.NET Core MVC uygulamalarýnda URL yönlendirmesini yönetmek için kullanýlýr.


app.Run();

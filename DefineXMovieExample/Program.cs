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
// Uygulama ba�lat�ld���nda varsay�lan olarak a��lacak sayfay� belirler.
// "{controller=Home}/{action=Index}/{id?}" format� �u anlama gelir:
// - E�er bir �zel y�nlendirme yap�lmazsa, "Home" controller'�n�n "Index" action'� �al��t�r�l�r.
// - Opsiyonel "id" parametresi kullan�labilir.
// Bu yap�, ASP.NET Core MVC uygulamalar�nda URL y�nlendirmesini y�netmek i�in kullan�l�r.


app.Run();

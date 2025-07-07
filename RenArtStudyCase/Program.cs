using RenArtStudyCase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ProductService servisini ekledik
builder.Services.AddScoped<ProductService>();
builder.Services.AddHttpClient<GoldService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// Statik dosyalar (CSS, JS, img) için
app.MapStaticAssets();

// Authorization (şu anda gerekmiyor ama bırakabiliriz)
app.UseAuthorization();

// 🌟 API route'larını ekliyoruz
app.MapControllers();

// MVC route'ları
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=ProductsPage}/{id?}")
    .WithStaticAssets();

app.Run();

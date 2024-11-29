using Microsoft.EntityFrameworkCore;
using RazorPageHW.Context;
using RazorPageHW.Services;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình chuỗi kết nối và DbContext
var connection = builder.Configuration.GetConnectionString("connectionString");
builder.Services.AddDbContext<DBContext>(option => option.UseSqlServer(connection));

// Cấu hình dịch vụ UserService và ProductService
builder.Services.AddScoped<UserService>();


// Cấu hình session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn cho session
    options.Cookie.HttpOnly = true;  // Cấu hình cookie cho session
    options.Cookie.IsEssential = true; // Đảm bảo session được sử dụng
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware khác
app.UseSession(); // Đảm bảo sử dụng session trước khi các middleware khác

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

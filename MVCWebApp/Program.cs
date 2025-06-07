using MVCWebApp.DataAccess.Data;
using MVCWebApp.DataAccess.Repository;
using MVCWebApp.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using MVCWebApp.Utility;
using Stripe;
using MVCWebApp.DataAccess.DbInitializer;
using MVCWebApp.Utility.Emails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DBContext class here
// Connexion string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DB connect
DbConnectionMVCSarl dbConnection = new DbConnectionMVCSarl(new MySQLConnection(connectionString));
builder = dbConnection.Connect(builder);

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// identity user
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DbContextMVCSarl>().AddDefaultTokenProviders();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<DbContextMVCSarl>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});


// facebook authentication
builder.Services.AddAuthentication().AddFacebook(option => {
    option.AppId = "put your facebook api here";
    option.AppSecret = "put your facebook secret here";
});

// session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddScoped<IDbInitializer, DbInitializer>();

// razor page
builder.Services.AddRazorPages();

// unit of work service
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// for email
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IEmailSender, EmailServiceMailKit>();

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

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.UseSession();
SeedDatabase();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}

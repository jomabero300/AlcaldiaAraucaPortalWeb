using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Alar;
using AlcaldiaAraucaPortalWeb.Helpers.Cont;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Helpers.Pdf;
using AlcaldiaAraucaPortalWeb.Helpers.Subs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(cfg =>
{
    cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
    cfg.SignIn.RequireConfirmedEmail = true;
    cfg.SignIn.RequireConfirmedAccount = true;

    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequireDigit = false;
    cfg.Password.RequiredUniqueChars = 0;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
    cfg.Password.RequireUppercase = false;

    //cfg.Password.RequiredLength = 6;

    cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
    cfg.Lockout.MaxFailedAccessAttempts = 3;
    cfg.Lockout.AllowedForNewUsers = true;

    cfg.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABDCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";


})
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.LoginPath = "/Home/NotAuthorized";
    options.AccessDeniedPath = "/Home/NotAuthorized";
});

//builder.Services.AddDatabaseDeveloperPageExceptionfFilter();

builder.Services.AddScoped<IAffiliateGroupCommunityHelper, AffiliateGroupCommunityHelper>();
builder.Services.AddScoped<IAffiliateGroupProductiveHelper, AffiliateGroupProductiveHelper>();
builder.Services.AddScoped<IAffiliateHelper, AffiliateHelper>();
builder.Services.AddScoped<IAffiliateProfessionHelper, AffiliateProfessionHelper>();
builder.Services.AddScoped<IAffiliateSocialNetworkHelper, AffiliateSocialNetworkHelper>();
builder.Services.AddScoped<IGroupCommunityHelper, GroupCommunityHelper>();
builder.Services.AddScoped<IGroupProductiveHelper, GroupProductiveHelper>();
builder.Services.AddScoped<IProfessionHelper, ProfessionHelper>();
builder.Services.AddScoped<ISocialNetworkHelper, SocialNetworkHelper>();


builder.Services.AddScoped<IFolderStrategicLineasHelper, FolderStrategicLineasHelper>();
builder.Services.AddScoped<IPqrsStrategicLineHelper, PqrsStrategicLineHelper>();
builder.Services.AddScoped<IPqrsStrategicLineSectorHelper, PqrsStrategicLineSectorHelper>();
builder.Services.AddScoped<IPqrsUserStrategicLineHelper, PqrsUserStrategicLineHelper>();

builder.Services.AddScoped<IContentHelper, ContentHelper>();
builder.Services.AddScoped<IContentOdsHelper, ContentOdsHelper>();

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ICommuneTownshipHelper, CommuneTownshipHelper>();
builder.Services.AddScoped<IDocumentTypeHelper, DocumentTypeHelper>();
builder.Services.AddScoped<IGenderHelper, GenderHelper>();
builder.Services.AddScoped<IImageHelper, ImageHelper>();
builder.Services.AddScoped<IMailHelper, MailHelper>();
builder.Services.AddScoped<INeighborhoodSidewalkHelper, NeighborhoodSidewalkHelper>();
builder.Services.AddScoped<IStateHelper, StateHelper>();
builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddScoped<IZoneHelper, ZoneHelper>();
builder.Services.AddScoped<IUtilitiesHelper, UtilitiesHelper>();

builder.Services.AddScoped<IPdfDocumentHelper, PdfDocumentHelper>();


builder.Services.AddScoped<ISubscriberHelper, SubscriberHelper>();
builder.Services.AddScoped<ISubscriberSectorHelper, SubscriberSectorHelper>();

builder.Services.AddTransient<SeedDb>();


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

//Para solucionar el problema de CORS
//https://www.youtube.com/watch?v=tfumTIhpG_A
builder.Services.AddCors(op =>
{
    op.AddPolicy("MyPolicy", app =>
    {
        app.WithOrigins("https://araucactiva.com");
        //app.AllowAnyOrigin()
        //.AllowAnyHeader()
        //.AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseStatusCodePagesWithReExecute("/error/{0}");

SeedData(app);

void SeedData(WebApplication app)
{
    IServiceScopeFactory scopeFactory = app.Services.GetService<IServiceScopeFactory>();

    using (IServiceScope scope = scopeFactory.CreateScope())
    {
        SeedDb service = scope.ServiceProvider.GetService<SeedDb>();

        service.SeedAsync().Wait();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

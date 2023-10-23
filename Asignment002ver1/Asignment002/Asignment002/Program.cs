using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Asignment002.Data;
using Asignment002.Areas.Identity.Data;
using Asignment002.Policies.Handlers;
using Asignment002.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PizzaStoreContextConnection") ?? throw new InvalidOperationException("Connection string 'PizzaStoreContextConnection' not found.");

builder.Services.AddDbContext<PizzaStoreContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Asignment002User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PizzaStoreContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Staff", policy =>
     policy.Requirements.Add(new TypeRequirememt("Type")));

});
builder.Services.AddScoped<IAuthorizationHandler, TypeHandler>();
// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Categories", "Staff");
    options.Conventions.AuthorizeFolder("/Suppliers", "Staff");
    options.Conventions.AuthorizeFolder("/Products", "Staff");

});

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();

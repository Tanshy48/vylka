using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using vylka.Data;
using vylka.Models;
using vylka.Areas.Entity;
using SendGrid;
using SendGrid.Helpers.Mail;

var apiKey = "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";
var client = new SendGridClient(apiKey);
var msg = new SendGridMessage()
{
    From = new EmailAddress("vasylechko.vlasta@student.uzhnu.edu.ua", "Vlasta"),
    Subject = "Sending with Twilio SendGrid is Fun",
    PlainTextContent = "and easy to do anywhere, especially with C#"
};
msg.AddTo(new EmailAddress("marlboroblue08@gmail.com", "Vlasta"));
var response = await client.SendEmailAsync(msg);

// A success status code means SendGrid received the email request and will process it.
// Errors can still occur when SendGrid tries to send the email. 
// If email is not received, use this URL to debug: https://app.sendgrid.com/email_activity 
Console.WriteLine(response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!");

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("vylkaContextConnection") ?? throw new InvalidOperationException("Connection string 'vylkaContextConnection' not found.");

builder.Services.AddDbContext<vylkaContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<vylkaContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();




// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<vylkaContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapRazorPages();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


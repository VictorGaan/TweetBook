using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TweetBook.Data;
using TweetBook.Installers;
using TweetBook.Options;
using TweetBook.Extensions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.InstallServicesInAssembly(builder.Configuration);
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

//Get options in appsettings (variable enviroment), and map options to object swaggerOptions.
var swaggerOptions = new SwaggerOptions();
builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
app.UseSwaggerUI(option => { option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description); });


app.UseMvc();
app.Run();

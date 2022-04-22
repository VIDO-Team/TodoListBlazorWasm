using ZaloVidoAPI.Data;
using ZaloVidoAPI.Lib;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ZaloVidoAPI.Models;
using Microsoft.Net.Http.Headers;
using System;

Console.WriteLine("CurrentDirectory in Main: {0}", System.IO.Directory.GetCurrentDirectory());
var builder = WebApplication.CreateBuilder(args);
string sConnection = builder.Configuration.GetConnectionString("ZaloVidoConnection");
// if(sConnection==null || string.IsNullOrEmpty(sConnection))
// {
//     sConnection = "Server=zalovido.pmsa.com.vn,2020;Database=Vido;User Id=vido01;Password=Vido@01";
// }
Console.WriteLine("TestConnection" + sConnection);
builder.Services.AddDbContext<ZaloVidoDbContext>(opt => opt.UseSqlServer(sConnection));
builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZaloVido", Version = "v1"});
});
builder.Services.AddHttpClient("ZaloVido", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://zalovido.pmsa.com.vn");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "https://zalovido.pmsa.com.vn");
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<SecretKeyOption>(
    builder.Configuration.GetSection(SecretKeyOption.SecretKey));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZaloVido v1"));
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();

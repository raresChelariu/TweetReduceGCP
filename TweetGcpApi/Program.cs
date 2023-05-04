using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("Gcp", client =>
{
    var authToken = configuration["Gcp:AuthToken"];
    var projectName = configuration["Gcp:ProjectName"];
    
    client.BaseAddress = new Uri("https://language.googleapis.com");
    client.DefaultRequestHeaders.Add("X-Goog-User-Project", projectName);
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
    
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
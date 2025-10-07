using Microsoft.OpenApi.Models; // Must be at the very top

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CSE 4050 Web Application Development Project",
        Version = "v1.0",
        Description = "API for a college shopping cart project developed by students under Dr. Mudassar Ghazi at California State University, San Bernardino.",
        Contact = new OpenApiContact
        {
            //Name = "Team Members: M. Ramos, N. Rangel, G. Sanchez, E. Warren",
            Name = "Team Members",
            Email = "studentteam@csusb.edu",
            Url = new Uri("https://github.com/Lettie-a-code/CSE-4050"),
        },
        License = new OpenApiLicense
        {
            Name = "Educational Use Only"
        }
    });
});

var app = builder.Build();

// Enable Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSE 4050 Project v1");
    c.DocumentTitle = "CSE 4050 Shopping Cart API";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//Console.WriteLine($"Environment: {app.Environment.EnvironmentName}");
app.Run();
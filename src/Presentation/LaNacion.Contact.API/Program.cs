using LaNacion.Application;
using LaNacion.Contact.API.Extensions;
using LaNacion.Contact.API.Filters;
using LaNacion.Persistence;
using LaNacion.Shared;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//ILogger Save to file
builder.Services.AddLogging(loggingBuilder =>
{
    var loggingSection = builder.Configuration.GetSection("Logging");
    loggingBuilder.AddFile(loggingSection);
});


// Add services to the container.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddCoreApplication();
builder.Services.AddInfraestructureShared();
builder.Services.AddInfraestructurePersistence(builder.Configuration);
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<EnumSchemaFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.UseCors("CorsPolicy");
app.MapControllers();

app.Run();

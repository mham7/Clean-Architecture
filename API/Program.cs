using API.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddAPI(builder.Configuration);

Log.Logger = new LoggerConfiguration()
         .WriteTo.Console()
         .WriteTo.Seq("http://localhost:5194")
         .CreateLogger();


var app = builder.Build();

app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Serilog;

namespace TrabajoIntegradorSofttek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().ReadFrom.Configuration(builder.Configuration).CreateLogger();
            builder.Host.UseSerilog(Log.Logger);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

           // app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}
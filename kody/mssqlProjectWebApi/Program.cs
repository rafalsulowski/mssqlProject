using Microsoft.EntityFrameworkCore;
using mssqlProject.DataAccess.Data;
using mssqlProject.DataAccess.Repository;
using mssqlProject.DataAccess.Repository.IRepository;
using mssqlProject.Services;
using mssqlProject.Services.IServices;


namespace mssqlProjectWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myOrigins = "poli1";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("*")
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod()
                                                            .AllowAnyOrigin();
                                  });
            });


            builder.Services.AddRazorPages();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("SqlConnectionString")));

            builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
            builder.Services.AddScoped<IPlaceRepository, PlaceRepository>();
            builder.Services.AddScoped<IHotelRepository, HotelRepository>();
            builder.Services.AddScoped<IPromoterRepository, PromoterRepository>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();

            builder.Services.AddScoped<IParticipantService, ParticipantService>();
            builder.Services.AddScoped<IPlaceService, PlaceService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IPromoterService, PromoterService>();
            builder.Services.AddScoped<IGroupService, GroupService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IBudgetService, BudgetService>();



            var app = builder.Build();
            app.UseCors(myOrigins);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StudentManagementCQRS.Data;
using StudentManagementCQRS.Features.Students.Commands.CreateStudent;
using StudentManagementCQRS.Features.Students.Queries.GetAllStudents;
using System.Reflection;

namespace StudentManagementCQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    );
            });


            //Registering Mediator
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            //Registering Validator
            builder.Services.AddValidatorsFromAssemblyContaining<CreateStudentCommandValidator>();

            //Create Student Command
            builder.Services.AddScoped<CreateStudentCommandHandler>();

            //Get Student Query
            builder.Services.AddScoped<GetAllStudentsQueryHandler>();

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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TaskWebApiAssessment.DataContext;
using TaskWebApiAssessment.ITaskRepository;
using TaskWebApiAssessment.Repo;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TaskDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:Dbcon "]));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITask, TaskRepo>();


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

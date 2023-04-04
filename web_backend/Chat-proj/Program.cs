using Chat_proj.Models.ChatModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConn");
var userId = builder.Configuration.GetValue<string>("DbConn:UserId");
var password = builder.Configuration.GetValue<string>("DbConn:Password");

connectionString = connectionString.Replace("${DbConn:UserId}", userId)
                                     .Replace("${DbConn:Password}", password);

builder.Services.AddDbContext<ChatContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IChatRep, ChatRep>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

PrepChat.PrepPopiltaion(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models;
using NewsRepository;
using NewsRepository.Helpers;
using NewsRepository.Interfaces;
using NewsService;
using NewsService.Dtos;
using NewsService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("AppDB");
    options.UseSqlite(connectionString);
    // options.UseInMemoryDatabase("NewsDB");
});
builder.Services.AddScoped<SeedData>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var mapper = new MapperConfiguration(options =>
{
    // DTO to Entity
    // User
    options.CreateMap<CreateUserDto, User>();
    options.CreateMap<UpdateUserDto, User>();
    
    // Article
    options.CreateMap<CreateArticleDto, Article>();
    options.CreateMap<UpdateArticleDto, Article>();
    
    // Comment
    options.CreateMap<CreateCommentDto, Comment>();
    options.CreateMap<UpdateCommentDto, Comment>();
            
    // Entity to DTO
    // User
    options.CreateMap<User, GetUserDto>();

}).CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddIdentityApiEndpoints<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<SeedData>().PopulateData().Wait();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<User>();

app.Run();

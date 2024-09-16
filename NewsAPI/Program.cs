using AutoMapper;
using Models;
using NewsRepository;
using NewsRepository.Helpers;
using NewsRepository.Interfaces;
using NewsService;
using NewsService.Dtos;
using NewsService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>();

//DI
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

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

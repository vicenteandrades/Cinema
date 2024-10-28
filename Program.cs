using APIFilmeStudy.Context;
using APIFilmeStudy.Model;
using APIFilmeStudy.Profile;
using APIFilmeStudy.Repository;
using APIFilmeStudy.Services;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<FilmeContext>()
    .AddDefaultTokenProviders();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FilmeContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<FilmeRepository>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<CinemaRepository>();
builder.Services.AddScoped<SessaoRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<FilmeProfile>();
builder.Services.AddScoped<EnderecoProfile>();
builder.Services.AddScoped<CinemaProfile>();
builder.Services.AddScoped<SessaoProfile>();
builder.Services.AddScoped<UserProfile>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TokenService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

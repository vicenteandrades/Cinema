using APIFilmeStudy.Context;
using APIFilmeStudy.Profile;
using APIFilmeStudy.Repository;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

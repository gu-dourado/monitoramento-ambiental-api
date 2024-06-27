using Asp.Versioning;
using AutoMapper;
using Fiap.Api.Alunos;
using Fiap.Api.Alunos.Services;
using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Fiap.Web.Alunos.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region Repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepository>();
builder.Services.AddScoped<IPedidoRepository, LocalizacaoRepository>();
#endregion

#region Services
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IRepresentanteService, RepresentanteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion


#region AutoMapper

// Configuração do AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c => {
    // Permite que coleções nulas sejam mapeadas
    c.AllowNullCollections = true;
    // Permite que valores de destino nulos sejam mapeados
    c.AllowNullDestinationValues = true;

    c.CreateMap<AlertaModel, ClienteViewModel>();
    c.CreateMap<FornecedorModel, FornecedorViewModel>();
    c.CreateMap<LojaModel, LojaViewModel>();
    c.CreateMap<LocalizacaoModel, PedidoViewModel>();
    c.CreateMap<PedidoProdutoModel, PedidoProdutoViewModel>();
    c.CreateMap<ProdutoModel, ProdutoViewModel>();
    c.CreateMap<RepresentanteModel, RepresentanteViewModel>();

    c.CreateMap<ClienteViewModel, AlertaModel>();
    c.CreateMap<ClienteCreateViewModel, AlertaModel>();
    c.CreateMap<ClienteUpdateViewModel, AlertaModel>();

    c.CreateMap<FornecedorViewModel, FornecedorModel>();
    c.CreateMap<LojaViewModel, LojaModel>();
    c.CreateMap<LocalizacaoModel, PedidoViewModel>();
    c.CreateMap<PedidoViewModel, LocalizacaoModel>();
    c.CreateMap<PedidoProdutoViewModel, PedidoProdutoModel>();
    c.CreateMap<ProdutoViewModel, ProdutoModel>();
    c.CreateMap<RepresentanteViewModel, RepresentanteModel>();


    c.CreateMap<CreatePedidoViewModel, LocalizacaoModel>()
            .ForMember(dest => dest.PedidoProdutos, opt => opt.MapFrom(src =>
                src.ProdutoIds.Select(id => new PedidoProdutoModel { ProdutoId = id }).ToList()));


});

// Cria o mapper com base na configuração definida
IMapper mapper = mapperConfig.CreateMapper();

// Registra o IMapper como um serviço singleton no container de DI do ASP.NET Core
builder.Services.AddSingleton(mapper);
#endregion

#region autenticacao
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });



builder.Services.AddControllers();

#endregion


#region versionamento
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName);
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using LojaCarrinhos.Repository;

// Cria o builder para configurar a aplicação web.
var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers e views (MVC).
builder.Services.AddControllersWithViews();

// Adiciona cache em memória para sessões.
builder.Services.AddDistributedMemoryCache();

// Configura as opções de sessão, como tempo de expiração e propriedades do cookie.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de inatividade antes de expirar a sessão.
    options.Cookie.HttpOnly = true; // Cookie não acessível via JavaScript.
    options.Cookie.IsEssential = true; // Cookie essencial para funcionamento da aplicação.
});

// Registra a connection string como serviço singleton para injeção de dependência.
builder.Services.AddSingleton<string>(builder.Configuration.GetConnectionString("DefaultConnection")!);

// Registra os repositórios para injeção de dependência com escopo por requisição.
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<CarrinhoRepository>();

// Constrói a aplicação.
var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (!app.Environment.IsDevelopment())
{
    // Define página de erro padrão para ambiente de produção.
    app.UseExceptionHandler("/Home/Error");
}

// Permite servir arquivos estáticos (CSS, JS, imagens, etc.).
app.UseStaticFiles();

// Habilita o roteamento de URLs.
app.UseRouting();

// Habilita o uso de sessões.
app.UseSession();

// Habilita autorização (caso haja autenticação configurada).
app.UseAuthorization();

// Define a rota padrão para controllers.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplicação.
app.Run();

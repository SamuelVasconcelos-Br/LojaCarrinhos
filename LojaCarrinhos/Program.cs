using LojaCarrinhos.Repository;

// Cria o builder para configurar a aplica��o web.
var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers e views (MVC).
builder.Services.AddControllersWithViews();

// Adiciona cache em mem�ria para sess�es.
builder.Services.AddDistributedMemoryCache();

// Configura as op��es de sess�o, como tempo de expira��o e propriedades do cookie.
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de inatividade antes de expirar a sess�o.
    options.Cookie.HttpOnly = true; // Cookie n�o acess�vel via JavaScript.
    options.Cookie.IsEssential = true; // Cookie essencial para funcionamento da aplica��o.
});

// Registra a connection string como servi�o singleton para inje��o de depend�ncia.
builder.Services.AddSingleton<string>(builder.Configuration.GetConnectionString("DefaultConnection")!);

// Registra os reposit�rios para inje��o de depend�ncia com escopo por requisi��o.
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<CarrinhoRepository>();

// Constr�i a aplica��o.
var app = builder.Build();

// Configura o pipeline de requisi��es HTTP.
if (!app.Environment.IsDevelopment())
{
    // Define p�gina de erro padr�o para ambiente de produ��o.
    app.UseExceptionHandler("/Home/Error");
}

// Permite servir arquivos est�ticos (CSS, JS, imagens, etc.).
app.UseStaticFiles();

// Habilita o roteamento de URLs.
app.UseRouting();

// Habilita o uso de sess�es.
app.UseSession();

// Habilita autoriza��o (caso haja autentica��o configurada).
app.UseAuthorization();

// Define a rota padr�o para controllers.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplica��o.
app.Run();

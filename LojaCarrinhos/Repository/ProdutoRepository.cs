using MySql.Data.MySqlClient;
using LojaCarrinhos.Models;
using Dapper;

namespace LojaCarrinhos.Repository
{
    // Repositório para acesso aos dados de produtos no banco de dados.
    public class ProdutoRepository
    {
        // String de conexão utilizada para acessar o banco de dados.
        private readonly string _connectionString;

        // Construtor que recebe a string de conexão.
        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Retorna todos os produtos cadastrados no banco.
        public async Task<IEnumerable<Produto>> TodosProdutos()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM Produtos";
            return await connection.QueryAsync<Produto>(sql);
        }

        // Busca um produto pelo seu Id.
        public async Task<Produto?> ProdutosPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "select Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM produtos WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
        }
    }
}
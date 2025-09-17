using Dapper;
using LojaCarrinhos.Models;
using MySql.Data.MySqlClient;

namespace LojaCarrinhos.Repository
{
    // Responsável por operações relacionadas a pedidos no sistema.
    public class PedidoRepository
    {
        // String de conexão utilizada para acessar o banco de dados.
        private readonly string _connectionString;

        // Construtor que recebe a string de conexão.
        public PedidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Produto?> ProdutosPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "select Id, Nome, Descricao, Preco, ImageUrl, Estoque FROM produtos WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id });
        }
    }
}

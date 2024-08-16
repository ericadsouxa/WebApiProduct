using Day1Part1.DAO;
using Day1Part1.Models;
//using Day1Part1.Models;
using Npgsql;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using 
namespace Final.DAO
{
    public class ProductDaoImplementation : IProductDao
    {

        NpgsqlConnection _connection;
        public ProductDaoImplementation(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertProduct()
        {
            //Create a connection object using connection string
            //2. Open the connection
            //3. Create a command object, pass the connection
            //4. Specify the command type
            //5. Create the query, call the command objects execute method. If you have parameter then add the parameters
            //6. Close the reader if you have open reader
            //7. Close the connection

        }

        //public async Task<int> DeleteProductById(int id)
        //{
        //    int rowsAffected = 0 ;

        //    string query = $"delete from practice.product where product_id = @pid";


        //    return rowsAffected;
        //}



        public async Task<int> DeleteProductById(int id)
        {
            int rowsAffected = 0;

            string query = $"delete from practice.product where product_id = @pid";
            using (_connection)
            {
                NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@pid", NgpsqlDbType.Integer).Value = id ;
                rowsAffected = await command.ExecuteNonQueryAsync();
            }

            return rowsAffected;
        }

        public async Task<List<Product>> GetProductsByPriceRange(double minPrice, double maxPrice)
        {
            var products = new List<Product>();

            const string query = "SELECT product_id, name, price FROM practice.product WHERE price >= @minPrice AND price <= @maxPrice";

            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@minPrice", NpgsqlTypes.NpgsqlDbType.Double, minPrice);
                command.Parameters.AddWithValue("@maxPrice", NpgsqlTypes.NpgsqlDbType.Double, maxPrice);

                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Product
                        {
                            
                            id = reader.GetInt32(reader.GetOrdinal("product_id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                            Price = reader.GetDouble(reader.GetOrdinal("price"))
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }




        public async Task<Product> GetProductById(int id) {

            Product product = new Product();
            string errorMessage = string.Empty;
            string query = @"select * from products where id = @pid";

            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand command = new NpgsqlCommand(query, _connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@pid", id);
                    NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        //int pdtId(int)reader.GetInt32(0);
                        product = new Product();
                        product.ProductName = reader.GetString(1);
                        product.Price = (double)reader.GetDecimal(2);
                        product.Category = reader["category"].ToString();
                        product.StarRating = Convert.ToInt32(reader["star_rating"]);
                        product.Description = reader["description"].ToString();
                        product.ProductCode = (string)reader["product_code"]

                    }
                }



            }
                reader? Close;
        }   


            int rowsInserted = 0;
            string insertQuery = @$"insert into practice.products(product_name, price, category, star_rating, description, product_code, imageurl) values ('{p.ProductName}', {p.Price}, '{p.Category}', {p.StarRating}, '{p.Description}', '{p.ProductCode}', '{p.ImageUrl}')";
        
            try
            {
                using (_connection)
                {
                    await _connection.OpenAsync();
                    NpgsqlCommand insertCommand = new NpgsqlCommand(insertQuery, connection);
                    insertCommand.CommandType.CommandType.Text;
                    rowsInserted = await insertCommand.ExecuteNonQueryAsync();
                }

    internal class reader
    {
    }
}
            catch (NpgsqlExtension e)

            {
                message = e.Message;
                Console.WriteLine("-----E-----");

            }
}

        

    }
}
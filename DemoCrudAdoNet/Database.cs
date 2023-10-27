using System.Data.SqlClient;
using System.Linq.Expressions;

namespace DemoCrudAdoNet;

/*
 Database database = new Database();
        //database.GetById("Fruits", "WHERE Id = 1", "DemoDb");

        //database.GetById("Fruits", item => item.id == 2);

        //database.Create("Fruits", new Fruits
        //{
        //    id = 23,
        //    name = "tyty",
        //    count = 100,
        //    price = 100,
        //});

        database.Delete("Fruits", 5);
 */

public class Database
{
    public void GetById(string tableName, string expression, string database)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection($"Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database={database};Trusted_Connection=True;"))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} {expression}";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString());
                        Console.WriteLine(reader[1].ToString());
                        Console.WriteLine(reader[2].ToString());
                        Console.WriteLine(reader[3].ToString());
                    }
                }
                connection.Close();
            }
        }
        catch
        {
            throw;
        }
    }

    public void GetById(string tableName, Expression<Func<Fruits, bool>> expression)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection($"Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database=DemoDb;Trusted_Connection=True;"))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} WHERE {GetSqlWhereClause(expression)}";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["Id"].ToString());
                        Console.WriteLine(reader["Name"].ToString());
                        Console.WriteLine(reader["count"].ToString());
                        Console.WriteLine(reader["Price"].ToString());
                    }
                }
                connection.Close();
            }
        }
        catch
        {
            throw;
        }
    }

    private string GetSqlWhereClause(Expression<Func<Fruits, bool>> expression)
    {
        if (expression == null)
        {
            return string.Empty;
        }

        BinaryExpression binaryExpression = (BinaryExpression)expression.Body;
        MemberExpression leftExpression = (MemberExpression)binaryExpression.Left;
        ConstantExpression rightExpression = (ConstantExpression)binaryExpression.Right;

        string leftSide = leftExpression.Member.Name;
        string rightSide = rightExpression.Value.ToString();

        string whereClause = $"{leftSide} = '{rightSide}'";

        return whereClause;
    }

    public void GetById(string tableName, Expression expression)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection($"Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database=DemoDb;Trusted_Connection=True;"))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName} {expression}";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0].ToString());
                        Console.WriteLine(reader[1].ToString());
                        Console.WriteLine(reader[2].ToString());
                        Console.WriteLine(reader[3].ToString());
                    }
                }
            }
        }
        catch
        {
            throw;
        }
    }

    public void Create(string tableName, Fruits fruit)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection($"Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database=DemoDb;Trusted_Connection=True;"))
            {
                connection.Open();

                string query = $"INSERT INTO {tableName} (id, name, count, price) VALUES (@id, @name, @count, @price)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", fruit.id);
                command.Parameters.AddWithValue("@name", fruit.name);
                command.Parameters.AddWithValue("@count", fruit.count);
                command.Parameters.AddWithValue("@price", fruit.price);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Successfully");
                else
                    Console.WriteLine("Error");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void Delete(string tableName, int fruitId)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection($"Server=LAPTOP-UVN5MKL6\\SQLEXPRESS;Database=DemoDb;Trusted_Connection=True;"))
            {
                connection.Open();

                string query = $"DELETE FROM {tableName} WHERE Id = @FruitId";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FruitId", fruitId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Successfully.");
                else
                    Console.WriteLine("Error");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

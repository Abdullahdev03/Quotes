using Dapper;
using Npgsql;

public class CategoryService
{
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotes;User Id=postgres;Password=22385564;";

  public List<CategoryDto> GetCategories()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "SELECT * FROM categories order by id";
      var result = connection.Query<CategoryDto>(sql);
      return result.ToList();
    }
  }
  public bool AddCategory(CategoryDto category)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO categories (Id,Category)" +
      $" VALUES ('{category.Id}','{category.Category}')";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
  public bool UpdateCategory(CategoryDto category)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update categories set Category ='{category.Category}'  where id = '{category.Id}'";
      var update = connection.Execute(sql);
      if (update > 0) return true;
      else return false;
    }
  }
  public bool DeleteCategory(int Id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from categories where id = {Id}";
      var delete = connection.Execute(sql);
      if (delete > 0) return true;
      else return false;
    }
  }


}
using Dapper;
using Npgsql;

public class QuoteService
{
  private string _connectionString = "Server=127.0.0.1;Port=5432;Database=Quotes;User Id=postgres;Password=22385564;";

  public List<QuoteDto> GetQuotes()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "SELECT * FROM quotes order by id";
      var result = connection.Query<QuoteDto>(sql);
      return result.ToList();
    }
  }

  public bool AddQuote(QuoteDto quote)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"INSERT INTO quotes (Id,Quotetext,autor, Categoryid)" +
      $" VALUES ({quote.Id},'{quote.Quotetext}','{quote.Autor}',{quote.Categoryid})";
      var insert = connection.Execute(sql);
      if (insert > 0) return true;
      else return false;
    }
  }
  public bool UpdateQuote(QuoteDto quote)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"update quotes set Quotetext = '{quote.Quotetext}',autor ='{quote.Autor}', Categoryid = {quote.Categoryid}  where id = {quote.Id}";
      var update = connection.Execute(sql);
      if (update > 0) return true;
      else return false;
    }
  }
  public bool DeleteQuote(int Id)
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = $"delete from quotes where id = {Id}";
      var delete = connection.Execute(sql);
      if (delete > 0) return true;
      else return false;
    }
  }
  /*5654465*/


    public List<QuoteDto> GetAllQuote()
  {
    using (var connection = new NpgsqlConnection(_connectionString))
    {
      string sql = "SELECT * FROM quotes q join categories c on q.CategoryId = c.id";
      var result = connection.Query<QuoteDto>(sql);
      return result.ToList();
    }
  }
    public List<QuoteDto> GetBycategory(int id)
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        string sql = $"SELECT q.id, q.quotetext, q.autor, q.categoryid, c.category FROM quotes q join categories c on c.id = q.CategoryId where q.categoryid = {id};";
        var result = connection.Query<QuoteDto>(sql);
        return result.ToList();
      }
    }
    public List<QuoteDto> GetRandom()
    {
      using (var connection = new NpgsqlConnection(_connectionString))
      {
        connection.Open();
        string sql = $"select * from quotes order by random() limit 1;";
        var result = connection.Query<QuoteDto>(sql);
        return result.ToList();
      }
    }


}

using Microsoft.AspNetCore.Mvc;


namespace webapi.Controllers;


  [ApiController]
  [Route("[controller]")]
  public class QuoteController : ControllerBase
  {
    private QuoteService _quoteService;
    public QuoteController()
    {
      _quoteService = new QuoteService();
    }
    [HttpGet("Quote")]
    public List<QuoteDto> Categories()
    {
      return _quoteService.GetQuotes();
    }

    [HttpGet("GetBycategory")]
    public List<QuoteDto> GetBycategory(int id)
    {
      return _quoteService.GetBycategory(id);
    }
    [HttpGet("GetRandom")]
    public List<QuoteDto> GetRandom()
    {
      return _quoteService.GetRandom();
    }
    [HttpGet("GetAllQuote")]
    public List<QuoteDto> GetAllQuote()
    {
      return _quoteService.GetAllQuote();
    }
    [HttpPost("Add")]
    
    public bool Add(QuoteDto quote)
    {
      return _quoteService.AddQuote(quote);
    }

    [HttpPut("Update")]
    public bool Update(QuoteDto quote)
    {
      return _quoteService.UpdateQuote(quote);
    }
    [HttpDelete("Delete")]
    public bool Delete(int id)
    {
      return _quoteService.DeleteQuote(id);
    }

  }

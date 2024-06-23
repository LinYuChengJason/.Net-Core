using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjTest.Dtos;
using prjTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly WebContext _webContext;

        public NewsController(WebContext webContext)
        {
            _webContext = webContext;
        }

        // GET: api/<NewsController>
        [HttpGet]
        public IEnumerable<News> Get()
        {
            return _webContext.News;
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public NewsDto Get(Guid id)
        {
            var result = (from a in _webContext.News
                         where a.newsId == id
                         select new NewsDto
                         {
                             title = a.title,
                             content = a.content,
                             newsId = id,
                             startDateTime = a.startDateTime,
                             endDateTime = a.endDateTime,
                             click = a.click
                         }).SingleOrDefault();
            return result;
        }

        // POST api/<NewsController>
        [HttpPost]
        public IActionResult Post([FromBody] News news)
        {
            _webContext.News.Add(news);
            _webContext.SaveChanges();

            return CreatedAtAction(nameof(Get), news);
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] NewsDtoPut news)
        {
            var update = (from a in _webContext.News
                          where a.newsId == id
                          select a).SingleOrDefault();

            update.title = news.title;
            _webContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var delete = (from a in _webContext.News
                          where a.newsId == id
                          select a).SingleOrDefault();

            _webContext.News.Remove(delete);
            _webContext.SaveChanges();
        }
    }
}


using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevBlog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly ApplicationDbContext _database;

        public ArticleController(ILogger<ArticleController> logger, ApplicationDbContext database)
        {
            this._logger = logger;
            this._database = database;
        }


        [HttpGet]
        public async Task<IActionResult> ShowArticle(string articleName)
        {
            return (articleName == default ||
                    articleName == string.Empty ||
                    await _database.Articles.FirstOrDefaultAsync(x => x.Title == articleName) == null) ?
                    NotFound() : (IActionResult)View(articleName.Replace(" ",string.Empty));


        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using DevBlog.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DevBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _database;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpPost]
        public async Task<string> SubscribeAsync(string email, CancellationToken cancellationToken)
        {
            string message = default;

            if (email != null && email != string.Empty)
            {

                email = email.ToLower();

                if (await _database.Subscribers.AsNoTracking()
                                               .FirstOrDefaultAsync(x => x.Email == email, cancellationToken) == null)
                {
                    await _database.Subscribers.AddAsync(new SubscriberModel(email), cancellationToken);
                    await _database.SaveChangesAsync(cancellationToken);
                    message = "Congratulation ! Thank you for your subscription 😊.";
                }
                else
                    message = "Oups! You're already registered 🔥.";
            }
            else
                message = "Are you serious ? It seems you trying to bypass client-side checking 🤔";

            return message;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int pointer, CancellationToken cancellationToken)
        {

            ArticleModel[] articles = await _database.Articles
                                                      .AsNoTracking()
                                                      .ToArrayAsync(cancellationToken);

            if (pointer >= articles.Length - 1)
                pointer = default;

            IEnumerable<ArticleModel> articlesToShow = articles[(pointer + 3 > articles.Length) ?
                                                         pointer..^0 :
                                                         pointer..(pointer + 3)];

            ViewBag.Pointer = pointer;

            return View((articles: articlesToShow, email: " "));
        }

        [HttpGet]
        public IActionResult Archive()
        { return View(); }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

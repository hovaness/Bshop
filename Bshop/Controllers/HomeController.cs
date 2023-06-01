using Bshop.Entity;
using Bshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Bshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceContext _contextService;
        private readonly ClientContext _contextClient;

        public HomeController(ServiceContext contextS, ClientContext contextC)
        {
            _contextService = contextS;
            _contextClient = contextC;
        }

        // GET: ServiceModels
        public async Task<IActionResult> Index(ClientModel client)
        {
            return _contextService.Service != null ?
                        View(await _contextService.Service.ToListAsync()) :
                        Problem("Entity set 'ServiceContext.Service'  is null.");
        }
        private readonly ILogger<HomeController> _logger;



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Authorize() => View();


        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("id,name,number,isRegular,visitings,password")] ClientModel client)
        {
            if(ModelState.IsValid)
            {
                client.visitings = 0;
                _contextClient.Add(client);
                await _contextClient.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }
    }
}
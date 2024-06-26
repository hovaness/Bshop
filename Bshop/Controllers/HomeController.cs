﻿using Bshop.Entity;
using Bshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.Diagnostics;

namespace Bshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceContext _contextService;
        private readonly ClientContext _contextClient;
        private readonly EntryContext _contextEntry;

        public HomeController(ServiceContext contextS, ClientContext contextC, EntryContext contextEntry)
        {
            _contextService = contextS;
            _contextClient = contextC;
            _contextEntry = contextEntry;   
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authorize(AuthView client)
        {
            if (ModelState.IsValid)
            {
                var user = _contextClient.Client.First(m => m.number == client.Phone);
                if (user == null) return RedirectToAction(nameof(Register), user);
                else if (user.password != client.Password) return NotFound("пароль не верный");
                return RedirectToAction(nameof(Profile), user);
            }
            return View(client);
        }

        [HttpGet]
        public IActionResult Profile(ClientModel user)
        {
			var entrys = _contextEntry.Entrys.Where(m => user.id == m.clientid).ToList();
            var profile = new ProfileModel()
            {
                me = user,
                myEntrys = entrys,
            };
			return View(profile);
        }

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AwesomeDotNetCore.Controllers
{
    public class PlayController : Controller
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IRepository<Player> _playerRepository;
        private readonly IConfiguration _configuration;

        public PlayController(IConfiguration config,
            IRepository<Team> teamRepository,
            IRepository<Player> playRepository)
        {
            _configuration = config;
            _teamRepository = teamRepository;
            _playerRepository = playRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insert()
        {
            var all = _teamRepository.Get();

            Team team = new Team { Name = "Test Team" };
            _teamRepository.Insert(team);

            Player player = new Player { Name = "Test Player 1", Team = team };
            _playerRepository.Insert(player);

            return View("~/Views/Play/Index.cshtml");
        }

        public IActionResult InsertUow()
        {
            return View("~/Views/Play/Index.cshtml");
        }
    }
}
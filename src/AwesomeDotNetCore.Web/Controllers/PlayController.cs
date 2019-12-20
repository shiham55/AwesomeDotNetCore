using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDotNetCore.Data;
using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AwesomeDotNetCore.Controllers
{
    public class PlayController : Controller
    {
        private readonly IAdventureWorksUnit _unitOfWork;

        public PlayController(IAdventureWorksUnit unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IRepository<Team> _teamRepo = _unitOfWork.GetRepository<Team>();
            IRepository<Player> _playerRepo = _unitOfWork.GetRepository<Player>();

            var allTeam = _teamRepo.Get();

            Team team = new Team { Name = "Team 2" };
            _teamRepo.Insert(team);

            //_unitOfWork.Save();

            allTeam = _teamRepo.Get();

            List<Player> players = new List<Player>
                {
                    new Player { Name = "Team 2 Member 1", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 2", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 3", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 4", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 5", Team = allTeam.Last() }
                };

            _playerRepo.InsertRange(players);

            _unitOfWork.Save();

            allTeam = _teamRepo.Get();
            var allplayers = _playerRepo.Get();

            return View();
        }
    }
}
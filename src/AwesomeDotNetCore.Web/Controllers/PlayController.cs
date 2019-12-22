using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDotNetCore.Common.Base;
using AwesomeDotNetCore.Data;
using AwesomeDotNetCore.Data.Models;
using AwesomeDotNetCore.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AwesomeDotNetCore.Controllers
{
    public class PlayController : BaseController
    {
        public PlayController(IAdventureWorksUnit unitOfWork) : base(unitOfWork) { }

        public IActionResult Index()
        {
            var teamRepo = _unitOfWork.GetRepository<Team>();
            var playerRepo = _unitOfWork.GetRepository<Player>();

            var allTeam = teamRepo.Get();

            Team team = new Team { Name = "Team 2" };
            teamRepo.Insert(team);

            _unitOfWork.Save();

            allTeam = teamRepo.Get();

            List<Player> players = new List<Player>
                {
                    new Player { Name = "Team 2 Member 1", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 2", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 3", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 4", Team = allTeam.Last() },
                    new Player { Name = "Team 2 Member 5", Team = allTeam.Last() }
                };

            playerRepo.InsertRange(players);

            _unitOfWork.Save();

            allTeam = teamRepo.Get();
            var allplayers = playerRepo.Get();

            return View();
        }
    }
}
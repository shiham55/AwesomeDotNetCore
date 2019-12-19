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

            try
            {
                var all = _teamRepo.Get();

                Team team = new Team { Name = "Test Team" };
                _teamRepo.Insert(team);

                _unitOfWork.Save();

                all = _teamRepo.Get();

                List<Team> teams = new List<Team>
                {
                    new Team { Name = "Test Team 2" },
                    new Team { Name = "Test Team 3" },
                    new Team { Name = "Test Team 4" },
                    new Team { Name = "Test Team 5" },
                    new Team { Name = "Test Team 6" }
                };
                
                _teamRepo.InsertRange(teams);

                _unitOfWork.Save();

                all = _teamRepo.Get();
            }
            catch (Exception ex)
            {
                //_unitOfWork.rollback();
                throw;
            }

            return View();
        }
    }
}
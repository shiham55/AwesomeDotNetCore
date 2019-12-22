using AwesomeDotNetCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDotNetCore.Common.Base
{
    public class BaseController : Controller
    {
        protected readonly IAdventureWorksUnit _unitOfWork;

        public BaseController(IAdventureWorksUnit unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}

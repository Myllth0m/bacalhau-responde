using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BacalhauResponde.Controllers
{
    public class RespostaController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

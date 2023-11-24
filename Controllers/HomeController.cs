using ClimeiMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClimeiMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly climei_mvcContext _context;

        public HomeController(climei_mvcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Users = _context.Usuario.Count();
            var NiveisUmidade = _context.NivelUmidade.Count();
            var NiveisTemperatura = _context.NivelTemperatura.Count();

            ViewData["QntdUsers"] = Users;
            ViewData["QntdUmidade"] = NiveisUmidade;
            ViewData["QntdTemp"] = NiveisTemperatura;
                
            return View();
        }
    }
}

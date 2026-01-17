using cadastroClientes.Data;
using cadastroClientes.Models;
using cadastroClientes.Services;
using Microsoft.AspNetCore.Mvc;


namespace cadastroClientes.Controllers
{
    public class CadastroClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly AppDbContext _context;

        public CadastroClienteController(AppDbContext context)
        {
            _context = context;
        }
        
        public ActionResult CadastrarCliente(Cliente cliente)
        {
            try
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return Content("1");
            }
            catch (Exception ex)
            {
                string excecao = ex.Message;
                return Content("0");
            }   
        }
    }
}

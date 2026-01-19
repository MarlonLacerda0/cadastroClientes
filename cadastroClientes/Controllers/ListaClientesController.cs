using cadastroClientes.Models;
using cadastroClientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace cadastroClientes.Controllers
{
    public class ListaClientesController : Controller
    {
        private readonly IConfiguration _configuration;

        public ListaClientesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _PartialListaClientes()
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");
            var clientes = ListaClientesDao.PartialListaClientes(connection);

            return PartialView("_PartialListaClientes", clientes);
        }

        public IActionResult ExcluirCliente(string cpf)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");

            bool retornoExclusao = ListaClientesDao.DeleteCliente(cpf, connection);
            if (!retornoExclusao)
                return Content("0");

            return Content("1");
        }

        public IActionResult ModalEdicao(int id)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");

            Cliente cliente = ListaClientesDao._PartialDadosClienteModal(id, connection);

            return PartialView("_PartialModalCliente", cliente);
        }

        public IActionResult EditarCliente(Cliente cliente)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");

            bool clienteEditado = ListaClientesDao.UpdateCliente(cliente, connection);
            if (!clienteEditado)
                return Content("0");

            return Content("1");
        }
    }
}

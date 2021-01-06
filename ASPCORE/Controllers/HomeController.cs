using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPCORE.Models;
using ASPCORE.Database;
using Microsoft.EntityFrameworkCore;

namespace ASPCORE.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDBContext database;
        public HomeController(ApplicationDBContext database){
            this.database = database;
        }
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste(){
            /*
            Categoria c1 = new Categoria();
            c1.Nome = "Victor";
            Categoria c2 = new Categoria();
            c2.Nome = "Victor";
            Categoria c3 = new Categoria();
            c3.Nome = "Erick";
            Categoria c4 = new Categoria();
            c4.Nome = "Wes";

            List<Categoria> catList = new List<Categoria>();
            catList.Add(c1);
            catList.Add(c2);
            catList.Add(c3);
            catList.Add(c4);

            database.AddRange(catList);

            database.SaveChanges();
            */
            
            var listaDeCategorias = database.Categorias.Where(cat => cat.Nome.Equals("Victor")).ToList();

            Console.WriteLine("++++++++  Cabeçalho  ++++++++++");

            listaDeCategorias.ForEach(categoria => {
                Console.WriteLine(categoria.ToString()); 
            });
            
            return Content("Dados Salvo");
        }

        public IActionResult Relacionamento(){
            /*
            Produto p = new Produto();
            p.Nome = "Doritos";
            p.Categoria = database.Categorias.First(c => c.Id == 1);

            Produto p2 = new Produto();
            p2.Nome = "Frango";
            p2.Categoria = database.Categorias.First(c => c.Id == 1);
                
            Produto p3 = new Produto();
            p3.Nome = "Bolo";
            p3.Categoria = database.Categorias.First(c => c.Id == 2);

            database.Add(p);
            database.Add(p2);
            database.Add(p3);
            
            database.SaveChanges();   
            */
            /*
            var listaDeProdutos = database.Produtos.Include(p => p.Categoria).ToList();

            listaDeProdutos.ForEach(produto => {
                Console.WriteLine(produto.ToString());
            });
            */

            var listaDeProdutosDeUmaCategoria = database.Produtos.Where(p => p.Categoria.Id == 1).ToList();

                listaDeProdutosDeUmaCategoria.ForEach(produto => {
                Console.WriteLine(produto.ToString());
            });
            return Content("Relacionamento");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

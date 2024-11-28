using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Data.SqlClient;
using PracticaSemana2.Models;

namespace PracticaSemana2.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductosController(IConfiguration configuration)
        {
            _configuration = configuration;
        }




        IEnumerable<Productos> Productos()
        {

            List<Productos> products = new List<Productos>();
            using (SqlConnection cadena = new SqlConnection(_configuration["ConnectionStrings:cadena"]))
            {
                cadena.Open();

                SqlCommand cmd = new SqlCommand("exec dbo.sp_list_products", cadena);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    products.Add(new Productos()
                    {
                        Id = reader.GetInt32(0),
                        descripcion = reader.GetString(1),
                        stock = reader.GetInt16(2),
                        precio = reader.GetDecimal(3),
                        unidadmedida = reader.GetString(4),

                    });
                }
                reader.Close();
            }

            return products;
        }
        /*   */
        public async Task<IActionResult> Inicio()
        {
            return View(await Task.Run(() => Productos()));
        }

        IEnumerable<Productos> FiltrarProductos(string nombre)
        {
            List<Productos> tmp = new List<Productos>();

            using (SqlConnection cadena = new SqlConnection(_configuration["ConnectionStrings:cadena"]))
            {
                cadena.Open();
                SqlCommand cmd = new SqlCommand("sp_filter_Products", cadena);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Inicial", nombre);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    tmp.Add(new Productos()
                    {
                        Id = reader.GetInt32(0),
                        descripcion = reader.GetString(1),
                        unidadmedida = reader.GetString(2),
                        precio = reader.GetDecimal(3),
                        stock = reader.GetInt16(4),
                    });
                }
                reader.Close();
            }
            return tmp;
        }
        public async Task<IActionResult> Filtrado(string? nombre = "")
        {
            return View(await Task.Run(() => string.IsNullOrEmpty(nombre) ? new List<Productos>() : FiltrarProductos(nombre)));
        }

    }

}

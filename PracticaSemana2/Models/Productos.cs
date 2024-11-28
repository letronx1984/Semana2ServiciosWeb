using System.ComponentModel.DataAnnotations;

namespace PracticaSemana2.Models
{
    public class Productos
    {

        [Display(Name = "Id de Productos")]
        public int Id { get; set; }

        [Display(Name = "Descripcion")]

        public string descripcion { get; set; }

        [Display(Name = "Medidas")]
        public string unidadmedida { get; set; }

        [Display(Name = "Precio")]
        public decimal precio { get; set; }

        [Display(Name = "Stock")]
        public int stock;

        
       

       

        

    }
}

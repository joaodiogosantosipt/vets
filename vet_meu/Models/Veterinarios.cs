using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Vets.Models
{
    public class Veterinarios
    {

        public Veterinarios()
        {
            ListaConsultas = new HashSet<Consultas>();
        }

        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public string NumCedulaProf { get; set; }

        public string Fotografia { get; set; }


        public ICollection<Consultas> ListaConsultas { get; set; }
    }
}
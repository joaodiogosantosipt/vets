using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Vets.Models
{
    public class Animais
    {

        public Animais()
        {
            ListaConsultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public string Raca { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public string Especie { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public double Peso { get; set; }

        public string Fotografia { get; set; }


        [ForeignKey(nameof(Dono))]  //   [ForeignKey("Dono")]
        public int DonoFK { get; set; }
        public Donos Dono { get; set; }


        public ICollection<Consultas> ListaConsultas { get; set; }

    }
}

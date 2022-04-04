using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vets.Models
{
    public class Consultas
    {
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public DateTime Data { get; set; }
        
        public string Observacoes { get; set; }
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public decimal ValorConsulta { get; set; }


        [ForeignKey(nameof(Animal))]
        public int AnimalFK { get; set; }
        public Animais Animal { get; set; }


        [ForeignKey(nameof(Veterinario))]
        public int VeterinarioFK { get; set; }
        public Veterinarios Veterinario { get; set; }

    }
}

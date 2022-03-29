using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vets.Models
{
    public class Consultas
    {

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string Observacoes { get; set; }

        public decimal ValorConsulta { get; set; }


        [ForeignKey(nameof(Animal))]
        public int AnimalFK { get; set; }
        public Animais Animal { get; set; }


        [ForeignKey(nameof(Veterinario))]
        public int VeterinarioFK { get; set; }
        public Veterinarios Veterinario { get; set; }

    }
}

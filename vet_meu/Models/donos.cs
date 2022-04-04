using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Vets.Models
{
    /// <summary>
    /// representa os dados do Dono do animal
    /// </summary>
    public class Donos
    {
       
        public Donos()
        {
            ListaAnimais = new HashSet<Animais>();
        }
        /// <summary>
        /// PK para a tabela dos donos
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// nome dos donos
        /// </summary>
        [Required(ErrorMessage= "o {0} é de preenchimento obrigatorio!")]
        [StringLength(30, ErrorMessage = "o {0} Não pode ter mais do que {1} charateres!")]
        public string Nome { get; set; }

        /// <summary>
        /// Nif dos donos
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem que ter exatamente {1} numeros")]
        public string NIF { get; set; }

        /// <summary>
        /// sexo dos donos
        /// F ou f - feminino; M ou m - masculino
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter")]
        public string Sexo { get; set; }

        /// <summary>
        /// lista dos animais de que o dono é dono
        /// </summary>

        public ICollection<Animais> ListaAnimais { get; set; }

    }
}
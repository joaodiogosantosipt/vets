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
        public string Nome { get; set; }

        /// <summary>
        /// Nif dos donos
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public string NIF { get; set; }

        /// <summary>
        /// sexo dos donos
        /// F ou f - feminino; M ou m - masculino
        /// </summary>
       
        public string Sexo { get; set; }

        /// <summary>
        /// lista dos animais de que o dono é dono
        /// </summary>

        public ICollection<Animais> ListaAnimais { get; set; }

    }
}
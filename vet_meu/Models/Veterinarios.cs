using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Vets.Models
{   
    /// <summary>
    /// Modelo que interage com os dados dos Veterinarios 
    /// </summary>
    public class Veterinarios
    {

        public Veterinarios()
        {
            ListaConsultas = new HashSet<Consultas>();
        }

        /// <summary>
        /// PK para cada um dos registos da tabela
        /// </summary>

        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public int Id { get; set; }

        /// <summary>
        /// Nome de veterinario
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        public string Nome { get; set; }

        /// <summary>
        /// Numero da cedula do vet
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        [Display(Name ="nº cedula profissional")]
        public string NumCedulaProf { get; set; }
       
        /// <summary>
        /// nome do ficheiro que contem a fotografia do vet
        /// </summary>
        public string Fotografia { get; set; }


        public ICollection<Consultas> ListaConsultas { get; set; }
    }
}
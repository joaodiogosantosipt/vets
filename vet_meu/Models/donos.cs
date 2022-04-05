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
        [RegularExpression("[A-ZÂÊÎÔÛÁÉÍÓÚÀÈÌÒÙÇÄËÏÖÜa-zçãõáéíóúàèìòùâêîòùäëïöüñ '-]+", ErrorMessage = "No campo {0} só se aceita Letras.")]
        public string Nome { get; set; }

        /// <summary>
        /// Nif dos donos
        /// </summary>
        [Required(ErrorMessage = "o {0} é de preenchimento obrigatorio!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} tem que ter exatamente {1} numeros")]
        [RegularExpression("[123578]+[0-9]{8}", ErrorMessage = "No campo {0} só se aceita numeros e deve comerar por 1, 2, 3, 5, 7, 8.")]
        public string NIF { get; set; }

        /// <summary>
        /// sexo dos donos
        /// F ou f - feminino; M ou m - masculino
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter")]
        [RegularExpression("[fFmM]", ErrorMessage = "No campo {0} só se aceita as letras F ou M.")]
        public string Sexo { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [EmailAddress(ErrorMessage = "introduza um Email correto, por favor")]
        public string Email { get; set; }

        /// <summary>
        /// lista dos animais de que o dono é dono
        /// </summary>


        public ICollection<Animais> ListaAnimais { get; set; }

    }
}
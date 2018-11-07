using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ITS.Models
{
    public class Tipo_usuario
    {
        [Key]
        public long id_tipo { get; set; }

        [Required(ErrorMessage = " campo requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = " El nombre debe tener de 3 a 50 caracteres")]
        public string nombre_tipo_usuario { get; set; }

    }
}

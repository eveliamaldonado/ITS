using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ITS.Models
{
    public class Datos_personales
    {
        [Key]
        public long Id_datos { get; set; }

        [Required(ErrorMessage = " campo requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = " El nombre debe tener de 3 a 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = " campo requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = " El apellido paterno debe tener de 3 a 50 caracteres")]
        public string A_paterno { get; set; }

        [Required(ErrorMessage = " campo requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = " El apellido materno debe tener de 3 a 50 caracteres")]
        public string A_materno { get; set; }

        public int Edad { get; set; }
    }
}

namespace WebProjectAPI_Prog3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_ADMIN
    {
        public int ID { get; set; }

        [Required]
        [StringLength(90)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(90)]
        public string Contraseña { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }

        [StringLength(90)]
        public string Email { get; set; }
    }
}

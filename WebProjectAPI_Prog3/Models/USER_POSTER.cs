namespace WebProjectAPI_Prog3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_POSTER
    {
        public int ID { get; set; }

        [Required]
        [StringLength(120)]
        public string Nombre_Empresa { get; set; }

        [Required]
        [StringLength(90)]
        public string Email { get; set; }

        [Required]
        [StringLength(90)]
        public string Contra { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        [StringLength(90)]
        public string Nombre_Calle { get; set; }

        public int Nombre_Ciudad { get; set; }

        public int Nombre_Pais { get; set; }

        public virtual CIUDAD CIUDAD { get; set; }

        public virtual PAIS PAIS { get; set; }
    }
}

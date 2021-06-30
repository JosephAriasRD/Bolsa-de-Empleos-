namespace WebProjectAPI_Prog3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("POST")]
    public partial class POST
    {
        public int ID { get; set; }

        public int Nombre_Categoria { get; set; }

        public int Nombre_Tipo_Trabajo { get; set; }

        public int Poster { get; set; }

        public byte[] Logo { get; set; }

        public string Direccion_URL { get; set; }

        [Required]
        [StringLength(90)]
        public string Nombre_Posicion { get; set; }

        [StringLength(90)]
        public string Nombre_Calle { get; set; }

        public int Nombre_Ciudad { get; set; }

        public int Nombre_Pais { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        public virtual CIUDAD CIUDAD { get; set; }

        public virtual PAIS PAIS { get; set; }

        public virtual TIPO_TRABAJO TIPO_TRABAJO { get; set; }
    }
}

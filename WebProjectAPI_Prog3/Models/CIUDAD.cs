namespace WebProjectAPI_Prog3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CIUDAD")]
    public partial class CIUDAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CIUDAD()
        {
            POST = new HashSet<POST>();
            USER_POSTER = new HashSet<USER_POSTER>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre { get; set; }

        public int Nombre_Pais { get; set; }

        public virtual PAIS PAIS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POST> POST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_POSTER> USER_POSTER { get; set; }
    }
}

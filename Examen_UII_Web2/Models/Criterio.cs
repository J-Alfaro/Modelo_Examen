namespace Examen_UII_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Criterio")]
    public partial class Criterio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Criterio()
        {
            DetalleEvidencia = new HashSet<DetalleEvidencia>();
        }

        [Key]
        public int criterio_id { get; set; }

        public int modelo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_criterio { get; set; }

        public virtual Modelo Modelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleEvidencia> DetalleEvidencia { get; set; }
    }
}

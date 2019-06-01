namespace Examen_UII_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evidencia")]
    public partial class Evidencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Evidencia()
        {
            DetalleEvidencia = new HashSet<DetalleEvidencia>();
        }

        [Key]
        public int evidencia_id { get; set; }

        public int semestre_id { get; set; }

        public int modelo_id { get; set; }

        [StringLength(250)]
        public string archivo { get; set; }

        [StringLength(10)]
        public string tamanio { get; set; }

        [StringLength(10)]
        public string tipo { get; set; }

        [StringLength(250)]
        public string url_archivo { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        public int categoria_id { get; set; }

        public bool? estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleEvidencia> DetalleEvidencia { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual Semestre Semestre { get; set; }
    }
}

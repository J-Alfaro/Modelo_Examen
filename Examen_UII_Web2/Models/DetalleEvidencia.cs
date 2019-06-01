namespace Examen_UII_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    [Table("DetalleEvidencia")]
    public partial class DetalleEvidencia
    {
        [Key]
        public int detalleevidencia_id { get; set; }

        public int evidencia_id { get; set; }

        public int modelo_id { get; set; }

        public int criterio_id { get; set; }

        public virtual Criterio Criterio { get; set; }

        public virtual Evidencia Evidencia { get; set; }

        public virtual Modelo Modelo { get; set; }
    }
}

namespace Examen_UII_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Modelo")]
    public partial class Modelo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Modelo()
        {
            Criterio = new HashSet<Criterio>();
            DetalleEvidencia = new HashSet<DetalleEvidencia>();
            Evidencia = new HashSet<Evidencia>();
        }

        [Key]
        public int modelo_id { get; set; }

        [Required]
        [StringLength(255)]
        public string nombre_modelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Criterio> Criterio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleEvidencia> DetalleEvidencia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evidencia> Evidencia { get; set; }



        //metodo listar
        public List<Modelo> Listar()//Retorna una coleccion de registros
        {
            var objModelo = new List<Modelo>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objModelo = db.Modelo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objModelo;
        }

        //metodo obtener
        public Modelo Obtener(int id)//retorna solo un objeto
        {
            var objModelo = new Modelo();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objModelo = db.Modelo
                        .Where(x => x.modelo_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objModelo;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.modelo_id > 0)
                    {
                        //si existe un valor mayor a 0 es porque existe un registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe registro graba(nuevo registro)
                        db.Entry(this).State = EntityState.Added;

                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //metodo Eliminar
        public void Eliminar()
        {

            try
            {
                using (var db = new Model_Sistema())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

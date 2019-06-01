namespace Examen_UII_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    using System.Linq;
    using System.Data.Entity;

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

        public virtual Categoria Categoria { get; set; }


        public List<Evidencia> Listar()//Retorna una coleccion de registros
        {
            var objEvidencia = new List<Evidencia>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objEvidencia = db.Evidencia.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidencia;
        }

        //metodo obtener
        public Evidencia Obtener(int id)//retorna solo un objeto
        {
            var objEvidencia = new Evidencia();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objEvidencia = db.Evidencia
                        .Where(x => x.evidencia_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objEvidencia;
        }

        //metodo guardar
        public void Guardar()//retorna solo un objeto
        {

            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.evidencia_id > 0)
                    {
                        //si existe un valor mayor a 0 es porque existe un registro
                        db.Entry(this).State = System.Data.Entity.EntityState.Modified;

                    }
                    else
                    {
                        //si no existe registro graba(nuevo registro)
                        db.Entry(this).State = System.Data.Entity.EntityState.Added;

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
                    db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
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

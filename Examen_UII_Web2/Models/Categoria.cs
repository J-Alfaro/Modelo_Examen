namespace Examen_UII_Web2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Evidencia = new HashSet<Evidencia>();
        }

        [Key]
        public int categoria_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre_categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evidencia> Evidencia { get; set; }

        //Metodo Listar
        public List<Categoria> Listar()
        {
            var objCategoria = new List<Categoria>();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objCategoria = db.Categoria.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCategoria;
        }

        //Metodo Obtener
        public Categoria Obtener(int id)//retorna solo un objeto
        {
            var objCategoria = new Categoria();
            try
            {
                using (var db = new Model_Sistema())
                {
                    objCategoria = db.Categoria
                                    .Where(x => x.categoria_id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objCategoria;
        }

        //Metodo Guardar

        public void Guardar()
        {
            try
            {
                using (var db = new Model_Sistema())
                {
                    if (this.categoria_id > 0)//sis existe un valor mayor a cero es porque existe registro
                    {
                        db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        //SINO EXISTE EL REGISTRO LO GRABA(nuevo)
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

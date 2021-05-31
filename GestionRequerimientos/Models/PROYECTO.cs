namespace GestionRequerimientos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROYECTO")]
    public partial class PROYECTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROYECTO()
        {
            REQUERIMIENTO = new HashSet<REQUERIMIENTO>();
        }

        [Key]
        [StringLength(10)]
        public string id_proyecto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal tiempo { get; set; }

        [Required]
        [StringLength(10)]
        public string porcentaje { get; set; }

        public decimal costo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_registro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_modificacion { get; set; }

        [StringLength(10)]
        public string nom_estado { get; set; }

        public virtual ESTADO ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUERIMIENTO> REQUERIMIENTO { get; set; }
    }
}

namespace GestionRequerimientos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REQUERIMIENTO")]
    public partial class REQUERIMIENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REQUERIMIENTO()
        {
            ACTIVIDAD = new HashSet<ACTIVIDAD>();
        }

        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id_requerimiento { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string id_proyecto { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal tiempo { get; set; }

        [Required]
        [StringLength(10)]
        public string porcentaje { get; set; }

        public decimal costo { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_registro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_modificacion { get; set; }

        [StringLength(10)]
        public string nom_estado { get; set; }

        [StringLength(10)]
        public string nom_req { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVIDAD> ACTIVIDAD { get; set; }

        public virtual ESTADO ESTADO { get; set; }

        public virtual PROYECTO PROYECTO { get; set; }

        public virtual TIPO_REQUERIMIENTO TIPO_REQUERIMIENTO { get; set; }
    }
}

namespace GestionRequerimientos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USUARIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIOS()
        {
            ACTIVIDAD = new HashSet<ACTIVIDAD>();
        }

        [Key]
        [StringLength(10)]
        public string pk_usuario { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id_usuario { get; set; }

        [Required]
        [StringLength(10)]
        public string contrasena { get; set; }

        [StringLength(20)]
        public string dpi { get; set; }

        [StringLength(10)]
        public string rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVIDAD> ACTIVIDAD { get; set; }

        public virtual PERSONA PERSONA { get; set; }

        public virtual ROL ROL1 { get; set; }
    }
}

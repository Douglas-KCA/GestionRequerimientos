namespace GestionRequerimientos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ESTADO")]
    public partial class ESTADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTADO()
        {
            PROYECTO = new HashSet<PROYECTO>();
            REQUERIMIENTO = new HashSet<REQUERIMIENTO>();
        }

        [Key]
        [StringLength(10)]
        public string nom_estado { get; set; }

        [Required]
        [StringLength(10)]
        public string id_estado { get; set; }

        [Required]
        [StringLength(10)]
        public string descripcion { get; set; }

        [Column("estado", TypeName = "numeric")]
        public decimal estado1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROYECTO> PROYECTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUERIMIENTO> REQUERIMIENTO { get; set; }
    }
}

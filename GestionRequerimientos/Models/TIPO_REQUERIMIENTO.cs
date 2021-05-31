namespace GestionRequerimientos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TIPO_REQUERIMIENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_REQUERIMIENTO()
        {
            REQUERIMIENTO = new HashSet<REQUERIMIENTO>();
        }

        [Key]
        [StringLength(10)]
        public string nom_req { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id_tiporequerimiento { get; set; }

        [Required]
        [StringLength(20)]
        public string descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REQUERIMIENTO> REQUERIMIENTO { get; set; }
    }
}

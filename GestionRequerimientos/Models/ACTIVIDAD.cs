namespace GestionRequerimientos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACTIVIDAD")]
    public partial class ACTIVIDAD
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id_actividad { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal id_requerimiento { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string id_proyecto { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string pk_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal tiempo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal porcentaje { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_registro { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_modificacion { get; set; }

        public virtual REQUERIMIENTO REQUERIMIENTO { get; set; }

        public virtual USUARIOS USUARIOS { get; set; }
    }
}

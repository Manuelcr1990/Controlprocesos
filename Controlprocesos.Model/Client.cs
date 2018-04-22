namespace Controlprocesos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            ODPs = new HashSet<ODP>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODP> ODPs { get; set; }
    }
}

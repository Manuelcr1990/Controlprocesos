namespace Controlprocesos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODP")]
    public partial class ODP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ODP()
        {
            ODPProcesses = new HashSet<ODPProcess>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Número de ODP")]
        public string NODP { get; set; }

        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        [Display(Name = "Fecha de creación")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Fecha límite")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Fecha finalización")]
        public DateTime? FinishedDate { get; set; }

        [Display(Name = "Archivo PDF")]
        public string PDFFile { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODPProcess> ODPProcesses { get; set; }
    }
}

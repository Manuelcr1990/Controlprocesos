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
        [Display(Name = "N�mero de ODP")]
        public string NODP { get; set; }

        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "T�tulo")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        [Display(Name = "Fecha de creaci�n")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Fecha l�mite")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Fecha finalizaci�n")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FinishedDate { get; set; }

        [Display(Name = "Archivo PDF")]
        public string PDFFile { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODPProcess> ODPProcesses { get; set; }
    }
}

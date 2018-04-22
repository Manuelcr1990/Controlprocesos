namespace Controlprocesos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("ODPProcess")]
    public partial class ODPProcess
    {
        public int Id { get; set; }

        [Display(Name = "Orden de producción")]
        public int ODPId { get; set; }

        [Display(Name = "Proceso")]
        public int ProcessId { get; set; }

        [Display(Name = "Empleado")]
        public string UserId { get; set; }

        [NotMapped]
        [Display(Name = "Empleado")]
        public string User {
            get {
                using (CP context = new CP()) {
                    try {
                        return context.vwUsers.Where(U => U.Id == UserId).First().Username;
                    } catch (Exception) {
                        return "El usuario ya no existe";
                    }
                }
            }
        }

        [Display(Name = "Estado")]
        public byte Status { get; set; }

        [Required]
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        [Display(Name = "Fecha de inicio")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Fecha de finalización")]
        public DateTime? EndDate { get; set; }

        public virtual ODP ODP { get; set; }

        public virtual Process Process { get; set; }

    }
}

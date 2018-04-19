namespace Controlprocesos.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ODPProcess")]
    public partial class ODPProcess
    {
        public int Id { get; set; }

        public int ODPId { get; set; }

        public int ProcessId { get; set; }

        public int UserId { get; set; }

        public byte Status { get; set; }

        [Required]
        public string Notes { get; set; }

        public virtual ODP ODP { get; set; }

        public virtual Process Process { get; set; }
    }
}

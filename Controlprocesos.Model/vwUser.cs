namespace Controlprocesos.Model {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vwUser")]
    public partial class vwUser {
        public string Id { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string Username { get; set; }
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Display(Name = "Número de teléfono")]
        public string PhoneNumber { get; set; }
    }
}

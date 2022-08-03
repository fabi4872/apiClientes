using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiAbmClientes.Models
{
    public partial class Cliente
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 caracteres")]
        public string Nombres { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 caracteres")]
        public string Apellidos { get; set; }


        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 caracteres")]
        [RegularExpression(@"^(20|23|27|30|33)([0-9]{9}|-[0-9]{8}-[0-9]{1})+$", ErrorMessage = "El campo tiene un formato inválido")]
        public string Cuit { get; set; }


        [StringLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 caracteres")]
        public string Domicilio { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 caracteres")]
        [Phone(ErrorMessage = "El campo tiene un formato inválido")]
        public string TelefonoCelular { get; set; }


        [Required(ErrorMessage = "El campo es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo debe tener una longitud máxima de 50 caracteres")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "El campo tiene un formato inválido")]
        public string Email { get; set; }
    }
}

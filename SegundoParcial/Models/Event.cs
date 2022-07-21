using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SegundoParcial.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nombre del Evento:")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Fecha:")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Descripcion:")]
        public string Description { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("Capacidad:")]
        public int MaxAssistance { get; set; }
        [Required]
        [DisplayName("Precio:")]
        public int Price { get; set; }

    }
}

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
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [ValidateNever]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [Required]
        [DisplayName("Max Assistance")]
        public int MaxAssistance { get; set; }

        [Required]
        [DisplayName("Price")]
        public int Price { get; set; }

        public int AvailableSpaces { get; set; }

    }
}

using System.ComponentModel.DataAnnotations; // Adding Validation Rules to the model

namespace NorthwindMvc.Models {
    public class Thing {
        [Range(1, 10)] // Adding validation attributes
        public int? ID { get; set; }
        [Required] // Adding validation attributes
        public string Color { get; set; }
    }
}
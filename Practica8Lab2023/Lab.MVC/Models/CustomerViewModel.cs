using System.ComponentModel.DataAnnotations;


namespace Lab.MVC.Models
{
    public class CustomersViewModel
    {
        [Key]
        [StringLength(5)]
        [RegularExpression("^[A-Z]+$", ErrorMessage = "*Ups, El CustomID solo acepta letras.")]
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(40)]
        
        public string companyName { get; set; }

        [Required]
        [StringLength(30)]
        
        public string contactName { get; set; }

        

        

        

    }
}
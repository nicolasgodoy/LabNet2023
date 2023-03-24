using System.ComponentModel.DataAnnotations;


namespace Lab.MVC.Models
{
    public class CustomersViewModel
    {
        [Key]
        [StringLength(5)]
        public string Id { get; set; }

        [Required]
        [StringLength(40)]
        public string companyName { get; set; }

        [StringLength(30)]
        public string contactName { get; set; }

        

        

    }
}
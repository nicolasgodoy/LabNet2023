namespace Lab.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Region
    {
        [Key]
        [Required]
        public int RegionID { get; set; }

        [StringLength(50)]
        [Required]
        public string RegionDescription { get; set; }
    }
}

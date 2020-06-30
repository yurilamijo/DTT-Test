using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTT_Test.Models
{
    public partial class Article
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Summary { get; set; }

        [Required]
        [StringLength(225)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PublishDate { get; set; }
    }
}

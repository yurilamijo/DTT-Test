using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTT_Test.Models
{
    /* Article class
     * Text is getting validated by Regex
     */
    public partial class Article
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        [RegularExpression(@"^[A-Za-z0-9!?:@#$&()*\-`.+,/\ \t\n]*$")]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9!?:@#$&()*\-`.+,/\ \t\n]*$")]
        public string Summary { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9!?:@#$&()*\-`.+,/\ \t\n]*$")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PublishDate { get; set; }
    }
}

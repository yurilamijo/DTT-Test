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
        [RegularExpression(@"^[a-zA-Z 0-9 ]*$")]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        [RegularExpression(@"^[A-Za-z0-9!?:@#$&()*\-`.+,/\ \t\n]*$")]
        public string Summary { get; set; }

        [Required]
        [StringLength(225)]
        [RegularExpression(@"^[A-Za-z0-9!?:@#$&()*\-`.+,/\ \t\n]*$")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PublishDate { get; set; }
    }
}

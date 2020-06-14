using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTT_Test.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PublishDate { get; set; }
        public char IsArchived { get; set; }
    }
}

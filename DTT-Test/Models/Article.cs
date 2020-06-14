using System;
using System.Collections.Generic;

namespace DTT_Test.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IsArchived { get; set; }
    }
}

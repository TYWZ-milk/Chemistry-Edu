namespace Chemistry_Education.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webtestnet.comment")]
    public partial class comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int commentID { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(255)]
        public string date { get; set; }

        public int? StudentID { get; set; }
    }
}

namespace Chemistry_Education.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webtestnet.article")]
    public partial class article
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int articleID { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Brief { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(255)]
        public string Picture { get; set; }
    }
}

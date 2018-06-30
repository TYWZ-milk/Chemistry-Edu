namespace Chemistry_Education.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webtestnet.classes")]
    public partial class classes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassID { get; set; }

        [StringLength(255)]
        public string ClassName { get; set; }

        [StringLength(255)]
        public string Teacher { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string RS { get; set; }

        [StringLength(255)]
        public string TE { get; set; }

        [StringLength(255)]
        public string Textbook { get; set; }

        [StringLength(255)]
        public string Time { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Limit { get; set; }

        public int? Elective { get; set; }
    }
}

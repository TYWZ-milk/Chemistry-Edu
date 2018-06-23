namespace Chemistry_Education.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("webtestnet.student")]
    public partial class student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Head { get; set; }

        [StringLength(255)]
        public string Grade { get; set; }

        [StringLength(255)]
        public string Major { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Password { get; set; }
    }
}

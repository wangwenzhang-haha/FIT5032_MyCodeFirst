namespace FIT5032_MyCodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class units
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? student_id { get; set; }

        public virtual students students { get; set; }
    }
}

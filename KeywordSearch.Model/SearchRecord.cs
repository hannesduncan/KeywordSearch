using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeywordSearch.Model
{
    [Table("SearchRecords")]
    public class SearchRecord
    {
        [Key]
        [Column("ID")]
        public Guid ID { get; set; }

        [Column("DateCreated")]
        [Required]
        public DateTime DateCreated { get; set; }

        [Column("Positions")]
        public string Positions { get; set; }

        [Column("NumberOfResults")]
        [Display(Name = "Number of results")]
        public int NumberOfResult { get; set; }
    }
}

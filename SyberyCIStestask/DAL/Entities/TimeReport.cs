using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SyberyCIStestask.DAL.Entities
{
    class TimeReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EmploeeId { get; set; }
        public Emploee Emploee { get; set; }
        public float Hours { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}

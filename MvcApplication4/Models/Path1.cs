using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    [Table("AutoRoutePart")]
    public class AutoRoutePart
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Number { get; set; }

        public string Place { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
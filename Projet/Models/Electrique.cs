using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class Electrique
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdElectrique { get; set; }
        public string NomOutil { get; set; }
        public long Puissance { get; set; }
        public long IdOutil { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public int Stock { get; set; }
        public byte[] Image { get; set; }
    }
}

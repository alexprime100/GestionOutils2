using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace microServiceRecherche.Models
{
    public class Hydraulique
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdHydraulique { get; set; }
        public string NomOutil { get; set; }
        public long Pression { get; set; }
        public long IdOutil { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public int Stock { get; set; }
        public byte[] Image { get; set; }
    }
}

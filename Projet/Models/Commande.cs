using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class Commande
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdCommande { get; set; }
        public DateTime DateCommande{ get; set; }
        public double Prix{ get; set; }
        public string MoyenPaiement{ get; set; }
        public long IdClient { get; set; }
    }
}

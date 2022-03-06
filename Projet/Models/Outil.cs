using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Models
{
    public class Outil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdOutil { get; set; }
        public string NomOutil { get; set; }
        public double PrixDeVente { get; set; }
        public double PrixDeLocation { get; set; }
        public int Stock { get; set; }
        public int NombreAvis { get; set; }
        public int NombreEtoiles { get; set; }
        public string Description { get; set; }
        public string Commentaires { get; set; }
    }
}

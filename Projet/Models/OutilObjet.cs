namespace Projet.Models
{
    public class OutilObjet
    {
        public string NomOutil { get; set; }
        public long IdOutil { get; set; }
        public long IdElectrique { get; set; }
        public long IdHydraulique { get; set; }
        public long IdManuel { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        public int Stock { get; set; }
        public byte[] Image { get; set; }
    }
}

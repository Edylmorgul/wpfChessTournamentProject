namespace GestionEchec
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JOUEUR")]
    public partial class JOUEUR
    {
        [Key]
        public int idJoueur { get; set; }

        public int idClub { get; set; }

        [StringLength(50)]
        public string nomJoueur { get; set; }

        [StringLength(50)]
        public string prenomJoueur { get; set; }

        public int? nbrVictoire { get; set; }

        public int? nbrDefaite { get; set; }

        public int? nbrMatch { get; set; }

        public virtual CLUB CLUB { get; set; }

        public override string ToString()
        {
            return $"{nomJoueur} {prenomJoueur} {nbrDefaite} {nbrVictoire} {nbrMatch}";
        }
    }
}

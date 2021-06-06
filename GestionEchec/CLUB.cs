namespace GestionEchec
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLUB")]
    public partial class CLUB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLUB()
        {
            JOUEUR = new HashSet<JOUEUR>();
        }

        [Key]
        public int idClub { get; set; }

        public int idVille { get; set; }

        public int? numClub { get; set; }

        [StringLength(50)]
        public string nomClub { get; set; }

        public virtual VILLE VILLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JOUEUR> JOUEUR { get; set; }

        public override string ToString()
        {
            return $"{nomClub} {numClub}";
        }
    }
}

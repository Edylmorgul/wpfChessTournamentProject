namespace GestionEchec
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VILLE")]
    public partial class VILLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VILLE()
        {
            CLUB = new HashSet<CLUB>();
        }

        [Key]
        public int idVille { get; set; }

        public int idPays { get; set; }

        [StringLength(50)]
        public string nomVille { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLUB> CLUB { get; set; }

        public virtual PAYS PAYS { get; set; }

        public override string ToString()
        {
            return $"{nomVille}";
        }
    }
}

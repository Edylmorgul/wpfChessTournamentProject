namespace GestionEchec
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PAYS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAYS()
        {
            VILLE = new HashSet<VILLE>();
        }

        [Key]
        public int idPays { get; set; }

        [StringLength(50)]
        public string nomPays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VILLE> VILLE { get; set; }

        public override string ToString()
        {
            return $"{ nomPays }";
        }
    }
}



namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAIEMENTESPECECLT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAIEMENTESPECECLT()
        {
            this.REGLERESPECE = new HashSet<REGLERESPECE>();
        }
    
        public int IDESPECE_CLT { get; set; }
        public System.DateTime DATE_PAIEMENT { get; set; }
        public decimal MONTANT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGLERESPECE> REGLERESPECE { get; set; }
    }
}



namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAIEMENTESPECEFOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PAIEMENTESPECEFOUR()
        {
            this.COMMANDEFOUR = new HashSet<COMMANDEFOUR>();
        }
    
        public int IDESP_FOUR { get; set; }
        public System.DateTime DATE_PAIEMENT { get; set; }
        public decimal MONTANT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMANDEFOUR> COMMANDEFOUR { get; set; }
    }
}

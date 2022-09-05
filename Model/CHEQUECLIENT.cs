
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHEQUECLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHEQUECLIENT()
        {
            this.REGLERCHQ = new HashSet<REGLERCHQ>();
        }
    
        public int IDCHQ_CLT { get; set; }
        public System.DateTime DATEDONNER { get; set; }
        public System.DateTime DATEENCAISSEMENT { get; set; }
        public decimal MONTANT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGLERCHQ> REGLERCHQ { get; set; }
    }
}

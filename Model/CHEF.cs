

namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHEF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHEF()
        {
            this.EMPLOYE = new HashSet<EMPLOYE>();
        }
    
        public int IDUSER { get; set; }
        public string LOGIN { get; set; }
        public string CODE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYE> EMPLOYE { get; set; }
    }
}


namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHEQUEFOURNISSEUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHEQUEFOURNISSEUR()
        {
            this.COMMANDEFOUR = new HashSet<COMMANDEFOUR>();
        }
    
        public int IDCHQ_FOUR { get; set; }
        public System.DateTime DATEDONNER { get; set; }
        public System.DateTime DATEPAYER { get; set; }
        public decimal MONTANT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMANDEFOUR> COMMANDEFOUR { get; set; }
    }
}

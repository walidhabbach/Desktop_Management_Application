
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUIT()
        {
            this.COMMANDER = new HashSet<COMMANDER>();
        }
    
        public string IDPRODUIT { get; set; }
        public int IDFOUR { get; set; }
        public string DESIGNATION { get; set; }
        public decimal PRIXACHAT { get; set; }
        public Nullable<decimal> PRIXVENTE { get; set; }
        public Nullable<decimal> DPRIXVENTE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMANDER> COMMANDER { get; set; }
        public virtual FOURNISSEUR FOURNISSEUR { get; set; }
    }
}

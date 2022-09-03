
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class FOURNISSEUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FOURNISSEUR()
        {
            this.COMMANDEFOUR = new HashSet<COMMANDEFOUR>();
            this.PRODUIT = new HashSet<PRODUIT>();
        }
    
        public int IDFOUR { get; set; }
        public string ENTREPRISE { get; set; }
        public string TELEPHONE { get; set; }
        public string CATEGORIE { get; set; }
        public string ADRESSE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMANDEFOUR> COMMANDEFOUR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUIT> PRODUIT { get; set; }
    }
}

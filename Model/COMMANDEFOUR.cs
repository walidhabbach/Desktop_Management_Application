

namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMMANDEFOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMMANDEFOUR()
        {
            this.COMMANDER = new HashSet<COMMANDER>();
            this.CHEQUEFOURNISSEUR = new HashSet<CHEQUEFOURNISSEUR>();
            this.PAIEMENTESPECEFOUR = new HashSet<PAIEMENTESPECEFOUR>();
        }
    
        public int ID_CMD_FOUR { get; set; }
        public int IDFOUR { get; set; }
        public string DESCRIPTION { get; set; }
        public bool STATUT { get; set; }
        public System.DateTime DATECMD { get; set; }
        public bool PESPECE { get; set; }
        public bool PCHEQUE { get; set; }
        public decimal MONTANTTOTAL { get; set; }
        public Nullable<decimal> MTRESTE { get; set; }
        public Nullable<decimal> MTAVANCE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMANDER> COMMANDER { get; set; }
        public virtual FOURNISSEUR FOURNISSEUR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHEQUEFOURNISSEUR> CHEQUEFOURNISSEUR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAIEMENTESPECEFOUR> PAIEMENTESPECEFOUR { get; set; }
    }
}

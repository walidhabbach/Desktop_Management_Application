
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMMANDECLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COMMANDECLIENT()
        {
            this.REGLERCHQ = new HashSet<REGLERCHQ>();
            this.REGLERESPECE = new HashSet<REGLERESPECE>();
        }
    
        public int ID_CMD_CLT { get; set; }
        public int IDCLIENT { get; set; }
        public string DESIGNATION { get; set; }
        public System.DateTime DATE_DEBUT { get; set; }
        public System.DateTime DATE_LIMITE { get; set; }
        public bool STATUT { get; set; }
        public decimal MONTANTTOTAL { get; set; }
        public decimal MTAVANCE { get; set; }
        public Nullable<decimal> MTRESTE { get; set; }
        public bool PCHEQUE { get; set; }
        public bool PESPECE { get; set; }
    
        public virtual CLIENT CLIENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGLERCHQ> REGLERCHQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGLERESPECE> REGLERESPECE { get; set; }
    }
}

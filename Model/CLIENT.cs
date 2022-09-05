
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLIENT()
        {
            this.COMMANDECLIENT = new HashSet<COMMANDECLIENT>();
            this.REGLERCHQ = new HashSet<REGLERCHQ>();
            this.REGLERESPECE = new HashSet<REGLERESPECE>();
        }
    
        public int IDCLIENT { get; set; }
        public string NOM { get; set; }
        public string TELEPHONE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMANDECLIENT> COMMANDECLIENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGLERCHQ> REGLERCHQ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REGLERESPECE> REGLERESPECE { get; set; }
    }
}

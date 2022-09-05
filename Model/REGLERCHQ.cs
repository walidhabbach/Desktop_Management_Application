
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class REGLERCHQ
    {
        public int IDCHQ_CLT { get; set; }
        public int ID_CMD_CLT { get; set; }
        public int IDCLIENT { get; set; }
    
        public virtual CHEQUECLIENT CHEQUECLIENT { get; set; }
        public virtual CLIENT CLIENT { get; set; }
        public virtual COMMANDECLIENT COMMANDECLIENT { get; set; }
    }
}

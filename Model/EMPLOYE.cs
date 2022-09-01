
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYE
    {
        public int IDEMP { get; set; }
        public int IDUSER { get; set; }
        public string NOM { get; set; }
        public string TELEPHONE { get; set; }
        public Nullable<decimal> AGE { get; set; }
        public string ADRESSE { get; set; }
    
        public virtual CHEF CHEF { get; set; }
    }
}

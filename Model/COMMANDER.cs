
namespace Store_Management_System.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMMANDER
    {
        public string IDPRODUIT { get; set; }
        public int ID_CMD_FOUR { get; set; }
        public int QUANTITE { get; set; }
    
        public virtual COMMANDEFOUR COMMANDEFOUR { get; set; }
        public virtual PRODUIT PRODUIT { get; set; }
    }
}

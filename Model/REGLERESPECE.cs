
namespace Store_Management_System.Model
{

    public partial class REGLERESPECE
    {
        public int IDESPECE_CLT { get; set; }
        public int ID_CMD_CLT { get; set; }
        public int IDCLIENT { get; set; }

        public virtual CLIENT CLIENT { get; set; }
        public virtual COMMANDECLIENT COMMANDECLIENT { get; set; }
        public virtual PAIEMENTESPECECLT PAIEMENTESPECECLT { get; set; }
    }
}

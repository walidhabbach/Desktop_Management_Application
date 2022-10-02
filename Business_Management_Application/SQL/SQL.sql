
/*==============================================================*/
/* Table : CHEF                                                 */
/*==============================================================*/
create table CHEF (
   IDUSER               int          identity(1,1)         not null,
   LOGIN                varchar(20)          not null,
   CODE                 varchar(30)          not null,
   constraint PK_CHEF primary key (IDUSER)
)
go
/*==============================================================*/
/* Table : CHEQUECLIENT                                         */
/*==============================================================*/
create table CHEQUECLIENT (
   IDCHQ_CLT            int          identity(1,1)         not null,
   DATEDONNER           date             not null,
   DATEENCAISSEMENT     date             not null,
   MONTANT              money                not null,
   constraint PK_CHEQUECLIENT primary key (IDCHQ_CLT)
)
go

/*==============================================================*/
/* Table : CHEQUEFOURNISSEUR                                    */
/*==============================================================*/
create table CHEQUEFOURNISSEUR (
   IDCHQ_FOUR           int           identity(1,1)        not null,
   DATEDONNER           date            not null,
   DATEPAYER            date             not null,
   MONTANT              money                not null,
   constraint PK_CHEQUEFOURNISSEUR primary key (IDCHQ_FOUR)
)
go

/*==============================================================*/
/* Table : CLIENT                                               */
/*==============================================================*/
create table CLIENT (
   IDCLIENT             int          identity(1,1)         not null,
   NOM                  varchar(30)          not null,
   TELEPHONE            varchar(20)               not null,
   constraint PK_CLIENT primary key (IDCLIENT)
)
go

/*==============================================================*/
/* Table : COMMANDECLIENT                                       */
/*==============================================================*/
create table COMMANDECLIENT (
   ID_CMD_CLT           int          identity(1,1)         not null,
   IDCLIENT             int                  not null,
   DESIGNATION          varchar(30)          not null,
   DATE_DEBUT           date             not null,
   DATE_LIMITE          date             not null,
   STATUT               bit                  not null,
   MONTANTTOTAL         money                not null,
   MTAVANCE             money                not null,
   MTRESTE              money                null,
   PCHEQUE              bit                  not null,
   PESPECE              bit                  not null,
   constraint PK_COMMANDECLIENT primary key (ID_CMD_CLT)
)
go

/*==============================================================*/
/* Index : PASSER_FK                                            */
/*==============================================================*/




create nonclustered index PASSER_FK on COMMANDECLIENT (IDCLIENT ASC)
go

/*==============================================================*/
/* Table : COMMANDEFOUR                                         */
/*==============================================================*/
create table COMMANDEFOUR (
   ID_CMD_FOUR          int          identity(1,1)         not null,
   IDFOUR               int                  not null,
   DESCRIPTION          varchar(30)          not null,
   STATUT               bit                  not null,
   DATECMD              date             not null,
   PESPECE              bit                  not null,
   PCHEQUE              bit                  not null,
   MONTANTTOTAL         money                not null,
   MTRESTE              money                null,
   MTAVANCE             money                null,
   constraint PK_COMMANDEFOUR primary key (ID_CMD_FOUR)
)
go
/*==============================================================*/
/* Index : RECEVOIR_FK                                          */
/*==============================================================*/


create nonclustered index RECEVOIR_FK on COMMANDEFOUR (IDFOUR ASC)
go

/*==============================================================*/
/* Table : COMMANDER         Produit                            */
/*==============================================================*/
create table COMMANDER (
   IDPRODUIT            varchar(30)          not null,
   ID_CMD_FOUR          int                  not null,
   QUANTITE             int                  not null,
   constraint PK_COMMANDER primary key (IDPRODUIT, ID_CMD_FOUR)
)
go

/*==============================================================*/
/* Index : COMMANDER2_FK                                        */
/*==============================================================*/




create nonclustered index COMMANDER2_FK on COMMANDER (IDPRODUIT ASC)
go

/*==============================================================*/
/* Index : COMMANDER_FK                                         */
/*==============================================================*/




create nonclustered index COMMANDER_FK on COMMANDER (ID_CMD_FOUR ASC)
go

/*==============================================================*/
/* Table : EMPLOYE                                              */
/*==============================================================*/
create table EMPLOYE (
   IDEMP                int            identity(1,1)       not null,
   IDUSER               int                  not null,
   NOM                  varchar(30)          not null,
   TELEPHONE            varchar(20)	     not null,
   AGE                  numeric              null,
   ADRESSE              varchar(30)          null,
   constraint PK_EMPLOYE primary key (IDEMP)
)
go

/*==============================================================*/
/* Index : TRAVAILLER_FK                                        */
/*==============================================================*/




create nonclustered index TRAVAILLER_FK on EMPLOYE (IDUSER ASC)
go

/*==============================================================*/
/* Table : FOURNISSEUR                                          */
/*==============================================================*/
create table FOURNISSEUR (
   IDFOUR               int             identity(1,1)      not null,
   ENTREPRISE           varchar(30)          not null,
   TELEPHONE            varchar(20)           not null,
   CATEGORIE            varchar(30)          not null,
   ADRESSE              varchar(30)          not null,
   constraint PK_FOURNISSEUR primary key (IDFOUR)
)
go

/*==============================================================*/
/* Table : PAIEMENTESPECECLT                                    */
/*==============================================================*/
create table PAIEMENTESPECECLT (
   IDESPECE_CLT         int            identity(1,1)        not null,
   DATE_PAIEMENT        date             not null,
   MONTANT              money                not null,
   constraint PK_PAIEMENTESPECECLT primary key (IDESPECE_CLT)
)
go

/*==============================================================*/
/* Table : PAIEMENTESPECEFOUR                                   */
/*==============================================================*/
create table PAIEMENTESPECEFOUR (
   IDESP_FOUR           int             identity(1,1)      not null,
   DATE_PAIEMENT        date             not null,
   MONTANT              money                not null,
   constraint PK_PAIEMENTESPECEFOUR primary key (IDESP_FOUR)
)
go

/*==============================================================*/
/* Table : PRODUIT                                              */
/*==============================================================*/
create table PRODUIT (
   IDPRODUIT            varchar(30)          not null,
   IDFOUR               int                  not null,
   DESIGNATION          varchar(30)          not null,
   PRIXACHAT            money                not null,
   PRIXVENTE            money                null,
   DPRIXVENTE           money                null,
   constraint PK_PRODUIT primary key (IDPRODUIT)
)
go


/*==============================================================*/
/* Table : REGLERCHQ                                            */
/*==============================================================*/
create table REGLERCHQ (
   IDCHQ_CLT            int                  not null,
   ID_CMD_CLT           int                  not null,
   IDCLIENT             int                  not null,
   constraint PK_REGLERCHQ primary key (IDCHQ_CLT, ID_CMD_CLT, IDCLIENT)
)
go



/*==============================================================*/
/* Table : REGLERESPECE                                         */
/*==============================================================*/
create table REGLERESPECE (
   IDESPECE_CLT         int                  not null,
   ID_CMD_CLT           int                  not null,
   IDCLIENT             int                  not null,
   constraint PK_REGLERESPECE primary key (IDESPECE_CLT, ID_CMD_CLT, IDCLIENT)
)
go



/*==============================================================*/
/* Table : REGLER_ESP_FOUR                                      */
/*==============================================================*/
create table REGLER_ESP_FOUR (
   ID_CMD_FOUR          int                  not null,
   IDESP_FOUR           int                  not null,
   constraint PK_REGLER_ESP_FOUR primary key (ID_CMD_FOUR, IDESP_FOUR)
)
go



/*==============================================================*/
/* Table : REGLE_CHQ_FOUR                                       */
/*==============================================================*/
create table REGLE_CHQ_FOUR (
   IDCHQ_FOUR           int                  not null,
   ID_CMD_FOUR          int                  not null,
   constraint PK_REGLE_CHQ_FOUR primary key (IDCHQ_FOUR, ID_CMD_FOUR)
)
go


/*==============================================================*/
/* Table : [Task]                                       */
/*==============================================================*/

CREATE TABLE [dbo].[Task](
	[IdTask] [int] IDENTITY(1,1) NOT NULL,
	[Details] [varchar](max) NULL,
	[Statut] [bit] NULL,
	[Category] [varchar](30) NOT NULL,
	[TaskDate] [date] NOT NULL,
	[PriorityLevel] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTask] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


/*==============================================================*/
/* Table : [CALENDAR]						*/
/*==============================================================*/

CCREATE TABLE [dbo].[CALENDAR](
	[idCalendar] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCalendar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/*==============================================================*/

alter table COMMANDECLIENT
   add constraint FK_COMMANDE_PASSER_CLIENT foreign key (IDCLIENT)
      references CLIENT (IDCLIENT)
go

alter table COMMANDEFOUR
   add constraint FK_COMMANDE_RECEVOIR_FOURNISS foreign key (IDFOUR)
      references FOURNISSEUR (IDFOUR)
go

alter table COMMANDER
   add constraint FK_COMMANDE_COMMANDER_COMMANDE foreign key (ID_CMD_FOUR)
      references COMMANDEFOUR (ID_CMD_FOUR)
go

alter table COMMANDER
   add constraint FK_COMMANDE_COMMANDER_PRODUIT foreign key (IDPRODUIT)
      references PRODUIT (IDPRODUIT)
go

alter table EMPLOYE
   add constraint FK_EMPLOYE_TRAVAILLE_CHEF foreign key (IDUSER)
      references CHEF (IDUSER)
go

alter table PRODUIT
   add constraint FK_PRODUIT_PRODUIRE_FOURNISS foreign key (IDFOUR)
      references FOURNISSEUR (IDFOUR)
go

alter table REGLERCHQ
   add constraint FK_REGLERCH_REGLERCHQ_CLIENT foreign key (IDCLIENT)
      references CLIENT (IDCLIENT)
go

alter table REGLERCHQ
   add constraint FK_REGLERCH_REGLERCHQ_CHEQUECL foreign key (IDCHQ_CLT)
      references CHEQUECLIENT (IDCHQ_CLT)
go

alter table REGLERCHQ
   add constraint FK_REGLERCH_REGLERCHQ_COMMANDE foreign key (ID_CMD_CLT)
      references COMMANDECLIENT (ID_CMD_CLT)
go

alter table REGLERESPECE
   add constraint FK_REGLERES_REGLERESP_CLIENT foreign key (IDCLIENT)
      references CLIENT (IDCLIENT)
go

alter table REGLERESPECE
   add constraint FK_REGLERES_REGLERESP_PAIEMENT foreign key (IDESPECE_CLT)
      references PAIEMENTESPECECLT (IDESPECE_CLT)
go

alter table REGLERESPECE
   add constraint FK_REGLERES_REGLERESP_COMMANDE foreign key (ID_CMD_CLT)
      references COMMANDECLIENT (ID_CMD_CLT)
go

alter table REGLER_ESP_FOUR
   add constraint FK_REGLER_E_REGLER_ES_PAIEMENT foreign key (IDESP_FOUR)
      references PAIEMENTESPECEFOUR (IDESP_FOUR)
go

alter table REGLER_ESP_FOUR
   add constraint FK_REGLER_E_REGLER_ES_COMMANDE foreign key (ID_CMD_FOUR)
      references COMMANDEFOUR (ID_CMD_FOUR)
go

alter table REGLE_CHQ_FOUR
   add constraint FK_REGLE_CH_REGLE_CHQ_COMMANDE foreign key (ID_CMD_FOUR)
      references COMMANDEFOUR (ID_CMD_FOUR)
go

alter table REGLE_CHQ_FOUR
   add constraint FK_REGLE_CH_REGLE_CHQ_CHEQUEFO foreign key (IDCHQ_FOUR)
      references CHEQUEFOURNISSEUR (IDCHQ_FOUR)
go

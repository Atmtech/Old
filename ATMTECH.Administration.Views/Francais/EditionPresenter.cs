using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Common.Utils;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.Services.Interface;
using ATMTECH.ShoppingCart.DAO.Interface.Francais;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.WebControls;
using Parameter = ATMTECH.Entities.Parameter;

namespace ATMTECH.Administration.Views.Francais
{
    public class EditionPresenter : BaseAdministrationPresenter<IEditionPresenter>
    {
        public ICommandeService CommandeService { get; set; }
        public IClientService ClientService { get; set; }
        public IInventaireService InventaireService { get; set; }
        public IProduitService ProduitService { get; set; }
        public IEnterpriseService EnterpriseService { get; set; }
        public IFileService FileService { get; set; }
        public IDAOProprieteEdition DAOProprieteEdition { get; set; }
        public IDAOParameter DAOParameter { get; set; }
        public IDAOTitrePage DAOTitrePage { get; set; }
        public IDAOCoupon DAOCoupon { get; set; }
        public IDAOLogException DAOLogException { get; set; }

        public EditionPresenter(IEditionPresenter view)
            : base(view)
        {
        }

        public const int EST_INSERTION = 0;
        public void Rechercher()
        {
            switch (View.NomEntite.ToLower())
            {
                case "enterprise":
                    IList<Enterprise> enterprises =
                        EnterpriseService.GetAll()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = enterprises.Count;
                    View.ValeurRetrouve = enterprises;
                    break;
                case "orderline":
                    IList<OrderLine> ligneCommandes =
                        CommandeService.ObtenirLigneCommande()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = ligneCommandes.Count;
                    View.ValeurRetrouve = ligneCommandes;
                    break;
                case "customer":
                    IList<Customer> clients =
                        ClientService.ObtenirClient()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = clients.Count;
                    View.ValeurRetrouve = clients;
                    break;
                case "stock":
                    IList<Stock> stocks =
                        InventaireService.ObtenirInventaire()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = stocks.Count;
                    View.ValeurRetrouve = stocks;
                    break;
                case "productfile":
                    IList<ProductFile> fichierProduits =
                        ProduitService.ObtenirFichierProduit()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = fichierProduits.Count;
                    View.ValeurRetrouve = fichierProduits;
                    break;
                case "order":
                    IList<Order> commandes =
                        CommandeService.ObtenirCommande()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = commandes.Count;
                    View.ValeurRetrouve = commandes;
                    break;
                case "product":
                    List<Product> produits =
                        ProduitService.ObtenirProduit()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = produits.Count;
                    View.ValeurRetrouve = produits;
                    break;
                case "productcategory":
                    List<ProductCategory> categories =
                        ProduitService.ObtenirListeCategorie()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = categories.Count;
                    View.ValeurRetrouve = categories;
                    break;
                case "user":
                    List<User> utilisateurs =
                        ClientService.ObtenirUtilisateur()
                            .Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = utilisateurs.Count;
                    View.ValeurRetrouve = utilisateurs;
                    break;
                case "parameter":
                    IList<Parameter> parametres = DAOParameter.GetAllActive();
                    parametres = parametres.Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = parametres.Count;
                    View.ValeurRetrouve = parametres;
                    break;
                case "proprieteedition":
                    IList<ProprieteEdition> proprieteEditions = DAOProprieteEdition.GetAllActive();
                    proprieteEditions = proprieteEditions.Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = proprieteEditions.Count;
                    View.ValeurRetrouve = proprieteEditions;
                    break;
                case "titrepage":
                    IList<TitrePage> titrePages = DAOTitrePage.GetAllActive();
                    titrePages = titrePages.Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = titrePages.Count;
                    View.ValeurRetrouve = titrePages;
                    break;
                case "logexception":
                    IList<LogException> logExceptions = DAOLogException.GetAllActive();
                    logExceptions = logExceptions.Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = logExceptions.Count;
                    View.ValeurRetrouve = logExceptions;
                    break;
                case "coupon":
                    IList<Coupon> coupons = DAOCoupon.GetAllActive();
                    coupons = coupons.Where(x => x.Search.ToLower().Contains(View.CritereRecherche.ToLower()))
                            .ToList();
                    View.NombreValeurRetrouve = coupons.Count;
                    View.ValeurRetrouve = coupons;
                    break;
            }
        }

        public string ObtenirAssemblie()
        {
            ManageClass manageClass = new ManageClass();
            if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", View.NomEntite))
            {
                return "ATMTECH.ShoppingCart.Entities";
            }
            if (manageClass.IsExistInNameSpace("ATMTECH.Entities", View.NomEntite))
            {
                return "ATMTECH.Entities";
            }
            return "ATMTECH.ShoppingCart.Entities";
        }

        public IList<ProprieteEdition> ObtenirListeProprietePourEdition()
        {
            return DAOProprieteEdition.GetAllActive().Where(x => x.NomEntite == View.NomEntite).ToList();
        }

        private IList<ProprieteEdition> ObtenirListeProprieteFrameWork()
        {
            return DAOProprieteEdition.GetAllActive().Where(x => x.NomEntite == null).ToList();
        }

        public IList<Propriete> ObtenirListePropriete()
        {
            ManageClass manageClass = new ManageClass();

            IList<ProprieteEdition> proprieteEditions = ObtenirListeProprietePourEdition();
            IList<ProprieteEdition> proprieteFrameWork = ObtenirListeProprieteFrameWork();

            List<ProprieteEdition> editions = proprieteEditions.Union(proprieteFrameWork).ToList();
            IList<PropertyInfo> listeList = manageClass.GetPropertiesFromClass(ObtenirAssemblie(), View.NomEntite).ToList();
            IList<Propriete> proprietes = new List<Propriete>();
            foreach (PropertyInfo propertyInfo in listeList)
            {
                ProprieteEdition proprieteEdition = editions.FirstOrDefault(x => x.NomPropriete == propertyInfo.Name);
                if (proprieteEdition != null)
                {
                    proprietes.Add(new Propriete
                    {
                        Libelle = proprieteEdition.Affichage,
                        Nom = propertyInfo.Name,
                        EstProprieteNative = propertyInfo.PropertyType.Namespace == "System",
                        PropertyInfo = propertyInfo
                    });
                }
            }
            return proprietes;
            //IList<ProprieteEdition> fusion = new List<ProprieteEdition>();
            //foreach (ProprieteEdition proprieteEdition in proprieteEditions)
            //{
            //    fusion.Add(proprieteEdition);
            //}
            //foreach (ProprieteEdition proprieteEdition in proprieteFrameWork)
            //{
            //    fusion.Add(proprieteEdition);
            //}


            //IList<Propriete> proprietes = new List<Propriete>();
            //foreach (PropertyInfo propertyInfo in fusion)
            //{
            //    if (EstColonneFramework(propertyInfo.Name))
            //    {
            //        proprietes.Add(new Propriete
            //        {
            //            Libelle = proprieteFrameWork.FirstOrDefault(x => x.NomPropriete == propertyInfo.Name).Affichage,
            //            Nom = propertyInfo.Name,
            //            EstProprieteNative = propertyInfo.PropertyType.Namespace == "System",
            //            PropertyInfo = propertyInfo
            //        });
            //    }
            //    else
            //    {
            //        proprietes.Add(new Propriete
            //        {
            //            Libelle = proprieteEditions.FirstOrDefault(x => x.NomPropriete == propertyInfo.Name).Affichage,
            //            Nom = propertyInfo.Name,
            //            EstProprieteNative = propertyInfo.PropertyType.Namespace == "System",
            //            PropertyInfo = propertyInfo
            //        });
            //    }
            //}

            //return proprietes;


            //return null;


            //ManageClass manageClass = new ManageClass();
            //IList<PropertyInfo> listeList = manageClass.GetPropertiesFromClass(ObtenirAssemblie(), View.NomEntite).ToList();
            //IList<PropertyInfo> listeSortie = new List<PropertyInfo>();
            //foreach (PropertyInfo propertyInfo in listeList)
            //{
            //    ProprieteEdition firstOrDefault = proprieteEditions.FirstOrDefault(x => x.NomPropriete == propertyInfo.Name);
            //    if (firstOrDefault != null)
            //    {
            //        listeSortie.Add(propertyInfo);
            //    }
            //}

            //IList<Propriete> proprietes = new List<Propriete>();
            //foreach (PropertyInfo propertyInfo in listeSortie)
            //{
            //    if (EstColonneFramework(propertyInfo.Name))
            //    {
            //        proprietes.Add(new Propriete
            //        {
            //            Libelle = proprieteFrameWork.FirstOrDefault(x => x.NomPropriete == propertyInfo.Name).Affichage,
            //            Nom = propertyInfo.Name,
            //            EstProprieteNative = propertyInfo.PropertyType.Namespace == "System",
            //            PropertyInfo = propertyInfo
            //        });
            //    }
            //    else
            //    {
            //        proprietes.Add(new Propriete
            //        {
            //            Libelle = proprieteEditions.FirstOrDefault(x => x.NomPropriete == propertyInfo.Name).Affichage,
            //            Nom = propertyInfo.Name,
            //            EstProprieteNative = propertyInfo.PropertyType.Namespace == "System",
            //            PropertyInfo = propertyInfo
            //        });
            //    }
            //}

            //return proprietes;
            //return listeSortie.Select(propertyInfo => new Propriete { Libelle = proprieteEditions.FirstOrDefault(x => x.NomPropriete == propertyInfo.Name).Affichage, Nom = propertyInfo.Name, EstProprieteNative = propertyInfo.PropertyType.Namespace == "System", PropertyInfo = propertyInfo }).ToList();
        }
        public IList<Controle> ObtenirListeControle()
        {
            IList<Controle> controles = new List<Controle>();
            Object entite;
            if (View.ValeurId == EST_INSERTION)
            {
                ManageClass manageClass = new ManageClass();
                Type type = manageClass.GetTypeFromNameSpace(ObtenirAssemblie(), View.NomEntite);
                entite = Activator.CreateInstance(type, null);
            }
            else
            {
                entite = ObtenirEntite(View.ValeurId);
            }

            Controle controleEntete = new Controle
            {
                Libelle = new Label { Text = "<h2>Édition / Insertion</h2>" },
                Objet = new Label() { Text = "<h2>" + View.NomEntite + "</h2>" },
                Ordre = 0
            };
            controles.Add(controleEntete);

            if (entite != null)
            {
                IList<Propriete> obtenirListePropriete = ObtenirListePropriete();
                foreach (Propriete propriete in obtenirListePropriete)
                {
                    if (EstProprieteEnregistrable(propriete.PropertyInfo))
                    {
                        Controle controle = new Controle();
                        controle.Ordre = 9999;
                        if (propriete.Nom == "Id") controle.Ordre = 1;
                        if (propriete.Nom == "IsActive") controle.Ordre = 2;
                        if (propriete.Nom == "UserLoginModified") controle.Ordre = 3;
                        if (propriete.Nom == "DateCreated") controle.Ordre = 4;
                        if (propriete.Nom == "DateModified") controle.Ordre = 5;
                        if (propriete.Nom == "Description") controle.Ordre = 6;


                        controle.Libelle = new Label { Text = string.Format("<div style='font-weight:bold;font-size:13px;'>{0}</div>", propriete.Libelle) };
                        controle.Objet = ObtenirControleEdition(propriete, entite);
                        controles.Add(controle);
                    }
                }
            }



            return controles.OrderBy(x => x.Ordre).ToList();
        }
        public Control ObtenirControleEdition(Propriete propriete, Object entite)
        {
            string valeur = ObtenirValeurPropriete(propriete, entite);
            return propriete.EstProprieteNative ?
                ObtenirControleSimple(propriete, valeur) :
                ObtenirControleComplexe(propriete, valeur);
        }
        public Control ObtenirControleSimple(Propriete propriete, string valeur)
        {
            bool estEditable = !EstColonneFramework(propriete.Nom);

            Control creerControleStatutCommande = CreerControleStatutCommande(propriete, valeur);
            if (creerControleStatutCommande != null)
            {
                return creerControleStatutCommande;
            }

            switch (propriete.PropertyInfo.PropertyType.FullName)
            {
                case "System.String":
                    TextBox textBox = new TextBox
                    {
                        ID = propriete.PropertyInfo.Name,
                        Text = valeur,
                        Width = Unit.Percentage(90),
                        Enabled = estEditable,
                        Height = Unit.Pixel(25),
                        TextMode = TextBoxMode.MultiLine
                    };
                    return textBox;
                case "System.Decimal":
                    {
                        Numeric numeric = new Numeric
                        {
                            ID = propriete.PropertyInfo.Name,
                            Text = valeur,
                            Width = Unit.Pixel(150),
                            Enabled = estEditable
                        };
                        return numeric;
                    }
                case "System.Int32":
                    {
                        Numeric numeric = new Numeric
                        {
                            ID = propriete.PropertyInfo.Name,
                            Text = valeur,
                            Width = Unit.Pixel(150),
                            Enabled = estEditable,
                            NoDecimal = true
                        };
                        return numeric;
                    }
                case "System.DateTime":
                    {
                        DatePicker datePicker = new DatePicker
                        {
                            ID = propriete.PropertyInfo.Name,
                            Text = valeur,
                            Width = Unit.Pixel(150),
                            Enabled = estEditable
                        };
                        return datePicker;
                    }
                case "System.Boolean":
                    {
                        CheckBox checkBox = new CheckBox { ID = propriete.PropertyInfo.Name, Enabled = estEditable };
                        if (valeur.ToLower() == "true")
                        {
                            checkBox.Checked = true;
                        }
                        return checkBox;
                    }
            }
            return null;
        }
        public Control ObtenirControleComplexe(Propriete propriete, string valeur)
        {
            return CreerCombobox(propriete.PropertyInfo.Name, ObtenirDonneesPourUneEntite(propriete), valeur);
        }
        public ComboBox CreerCombobox(string nom, object datasource, string valeur)
        {
            ComboBox comboBoxSimple = new ComboBox
            {
                ID = nom
            };
            DropDownList dropDownList = new DropDownList
            {
                DataValueField = BaseEntity.ID,
                DataTextField = BaseEntity.COMBOBOX_DESCRIPTION,
                DataSource = datasource
            };
            dropDownList.DataBind();

            comboBoxSimple.AjouterItemsNull();

            foreach (ListItem item in dropDownList.Items)
            {
                comboBoxSimple.Items.Add(item);
            }

            if (valeur != "0")
            {
                if (!string.IsNullOrEmpty(valeur))
                    comboBoxSimple.SelectedValue = valeur;
            }


            return comboBoxSimple;
        }
        public Object ObtenirDonneesPourUneEntite(Propriete propriete)
        {
            switch (propriete.PropertyInfo.PropertyType.Name.ToLower())
            {
                case "customer":
                    return ClientService.ObtenirClient();
                case "product":
                    return ProduitService.ObtenirProduit();
                case "enterprise":
                    return EnterpriseService.GetAll();
                case "stock":
                    return InventaireService.ObtenirInventaire();
                case "productcategory":
                    return ProduitService.ObtenirListeCategorie();
                case "productcategoryenglish":
                    return ProduitService.ObtenirListeCategorie();
                case "productcategoryfrench":
                    return ProduitService.ObtenirListeCategorie();
                case "user":
                    return ClientService.ObtenirUtilisateur();
                case "file":
                    return FileService.GetAllFile();
            }
            return null;
        }
        public string ObtenirValeurPropriete(Propriete propriete, Object entite)
        {
            if (View.ValeurId == EST_INSERTION)
            {
                switch (propriete.PropertyInfo.Name)
                {
                    case "Id":
                        return "0";
                    case "IsActive":
                        return "True";
                    default:
                        return string.Empty;
                }
            }
            else
            {
                if (entite != null)
                {
                    return propriete.EstProprieteNative ?
                        ObtenirValeurProprieteTypeNatif(propriete, entite) :
                        ObtenirValeurProprieteTypeNonNatif(propriete, entite);
                }
            }
            return null;
        }
        public Object ObtenirEntite(int id)
        {
            if (id != 0 && !String.IsNullOrEmpty(ObtenirAssemblie()))
            {
                ManageClass manageClass = new ManageClass();
                Type d1 = typeof(BaseDao<,>);
                Type type = manageClass.GetTypeFromNameSpace(ObtenirAssemblie(), View.NomEntite);
                Type[] typeArgs = { type, typeof(int) };
                Type constructed = d1.MakeGenericType(typeArgs);
                object o = Activator.CreateInstance(constructed, null);
                Type[] typeArgs2 = { typeof(int) };
                Object test = id;
                object[] parametersArray = new[] { test };
                MethodInfo theMethod = constructed.GetMethod("GetById", typeArgs2);
                return theMethod.Invoke(o, parametersArray);
            }
            return null;
        }
        public int EnregistrerEntite(Object entite)
        {
            ManageClass manageClass = new ManageClass();
            Type d1 = typeof(BaseDao<,>);
            Type type = manageClass.GetTypeFromNameSpace(ObtenirAssemblie(), View.NomEntite);
            Type[] typeArgs = { type, typeof(int) };
            Type constructed = d1.MakeGenericType(typeArgs);
            object o = Activator.CreateInstance(constructed, null);
            Type[] typeArgs2 = { type };
            object[] parametersArray = new[] { entite };
            MethodInfo theMethod = constructed.GetMethod("Save", typeArgs2);
            return (int)theMethod.Invoke(o, parametersArray);
        }
        public int Enregistrer(PlaceHolder panel)
        {
            ManageClass manageClass = new ManageClass();
            Type type = manageClass.GetTypeFromNameSpace(ObtenirAssemblie(), View.NomEntite);
            Object entite = Activator.CreateInstance(type, null);

            if (View.ValeurId != EST_INSERTION)
            {
                entite = ObtenirEntite(View.ValeurId);
            }

            foreach (Control control in type.GetProperties().Select(propertyInfo => Common.Utils.Web.Pages.FindControlRecursive(panel, propertyInfo.Name)))
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                {
                    manageClass.AssignValue(type, entite, textBox.Text, textBox.ID);
                }

                Editor editeur = control as Editor;
                if (editeur != null)
                {
                    manageClass.AssignValue(type, entite, editeur.Text, editeur.ID);
                }

                ComboBox combobox = control as ComboBox;
                if (combobox != null)
                {
                    if (!string.IsNullOrEmpty(combobox.SelectedValue))
                    {
                        manageClass.AssignValue(type, entite, combobox.SelectedValue, combobox.ID);
                    }
                }
                CheckBox checkbox = control as CheckBox;
                if (checkbox != null)
                {
                    manageClass.AssignValue(type, entite, checkbox.Checked ? "True" : "False", checkbox.ID);
                }
                DatePicker datePicker = control as DatePicker;
                if (datePicker != null)
                {
                    manageClass.AssignValue(type, entite, datePicker.Text, datePicker.ID);
                }
                Numeric numeric = control as Numeric;
                if (numeric != null)
                {
                    manageClass.AssignValue(type, entite, numeric.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), numeric.ID);
                }
            }

            return EnregistrerEntite(entite);
        }
        public bool EstColonneFramework(string colonne)
        {
            switch (colonne.ToLower())
            {
                case "id":
                    return true;
                case "datemodified":
                    return true;
                case "datecreated":
                    return true;
                case "search":
                    return true;
                case "isactive":
                    return true;
                case "comboboxdescription":
                    return true;
                case "userloginmodified":
                    return true;
            }

            return false;
        }

        private string ObtenirValeurProprieteTypeNatif(Propriete propriete, Object entite)
        {
            object valeur = propriete.PropertyInfo.GetValue(entite, null);
            return valeur != null ? valeur.ToString() : string.Empty;
        }
        private string ObtenirValeurProprieteTypeNonNatif(Propriete propriete, Object entite)
        {

            object valeurPropriete = propriete.PropertyInfo.GetValue(entite, null);
            if (valeurPropriete != null)
            {
                PropertyInfo propertyInfoId = valeurPropriete.GetType().GetProperty("Id");
                return propertyInfoId.GetValue(valeurPropriete, null).ToString();
            }

            return string.Empty;
        }
        private bool EstProprieteEnregistrable(PropertyInfo propertyInfo)
        {
            if (propertyInfo.Name == BaseEntity.COMBOBOX_DESCRIPTION || propertyInfo.Name == BaseEntity.SEARCH)
                return false;

            if (propertyInfo.Name == "SearchUpdate" || propertyInfo.Name == "ComboboxDescriptionUpdate")
                return false;

            MethodInfo setMethod = propertyInfo.GetSetMethod();
            if (setMethod == null)
                return false;

            return true;
        }

        private Control CreerControleStatutCommande(Propriete propriete, string valeur)
        {
            if (propriete.Nom == "OrderStatus")
            {
                IList<OrderStatusDisplay> orderStatus = new List<OrderStatusDisplay>();
                OrderStatusDisplay orderStatusDisplay1 = new OrderStatusDisplay
                {
                    Id = 1,
                    ComboboxDescription = "Liste de souhait"
                };

                OrderStatusDisplay orderStatusDisplay2 = new OrderStatusDisplay
                {
                    Id = 2,
                    ComboboxDescription = "Commandé par le client"
                };

                OrderStatusDisplay orderStatusDisplay3 = new OrderStatusDisplay
                {
                    Id = 3,
                    ComboboxDescription = "Envoyé au client"
                };

                orderStatus.Add(orderStatusDisplay1);
                orderStatus.Add(orderStatusDisplay2);
                orderStatus.Add(orderStatusDisplay3);

                return CreerCombobox(propriete.Nom, orderStatus, valeur);
            }
            return null;
        }
    }

    public class Propriete
    {
        public string Libelle { get; set; }
        public string Nom { get; set; }
        public bool EstProprieteNative { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }

    public class Controle
    {
        public Label Libelle { get; set; }
        public Control Objet { get; set; }
        public int Ordre { get; set; }
    }

}

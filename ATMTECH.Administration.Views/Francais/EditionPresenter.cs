using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ATMTECH.Administration.DAO.Interface;
using ATMTECH.Administration.Services;
using ATMTECH.Administration.Services.Interface;
using ATMTECH.Administration.Views.Base;
using ATMTECH.Administration.Views.Interface.Francais;
using ATMTECH.Common.Utils;
using ATMTECH.DAO;
using ATMTECH.DAO.Interface;
using ATMTECH.Entities;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;

namespace ATMTECH.Administration.Views.Francais
{
    public class EditionPresenter : BaseAdministrationPresenter<IEditionPresenter>
    {
        public IGenerateControlsService GenerateControlsService { get; set; }
        public IDataEditorService DataEditorService { get; set; }
        public IDAOEntityProperty DAOEntityProperty { get; set; }
        public IDAOEntityInformation DAOEntityInformation { get; set; }
        public IDAOUser DAOUser { get; set; }
        public IDAOFile DAOFile { get; set; }

        public IProduitService ProduitService { get; set; }
        public ICommandeService CommandeService { get; set; }
        public IClientService ClientService { get; set; }
        public IInventaireService InventaireService { get; set; }

        public int NombreRangeeRetrouve { get; set; }

        public EditionPresenter(IEditionPresenter view)
            : base(view)
        {
        }

        public string Entity
        {
            get { return View.Entity; }
        }
        public string NameSpace
        {
            get { return View.NameSpace; }
        }
        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            RafraichirDonnee();


            User user = AuthenticationService.AuthenticateUser;
            if (user == null) return;
            if (!user.IsAdministrator)
            {
                NavigationService.Redirect("default.aspx");
            }

        }

        public Object RechercheInformation(string recherche, int pageIndex)
        {
            switch (Entity.ToLower())
            {
                case "orderline":
                    IList<OrderLine> ligneCommandes = CommandeService.ObtenirLigneCommande().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = ligneCommandes.Count;
                    return ligneCommandes;
                case "customer":
                    IList<Customer> clients = ClientService.ObtenirClient().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = clients.Count;
                    return clients;
                case "stock":
                    IList<Stock> stocks = InventaireService.ObtenirInventaire().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = stocks.Count;
                    return stocks;
                case "productfile":
                    IList<ProductFile> fichierProduits = ProduitService.ObtenirFichierProduit().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = fichierProduits.Count;
                    return fichierProduits;
                case "order":
                    IList<Order> commandes = CommandeService.ObtenirCommande().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = commandes.Count;
                    return commandes;
                case "product":
                    List<Product> produits = ProduitService.ObtenirProduit().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = produits.Count;
                    return produits;
                case "productcategory":
                    List<ProductCategory> categories = ProduitService.ObtenirListeCategorie().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = categories.Count;
                    return categories;
                case "user":
                    List<User> utilisateurs = ClientService.ObtenirUtilisateur().Where(x => x.Search.ToLower().Contains(recherche.ToLower())).ToList();
                    NombreRangeeRetrouve = utilisateurs.Count;
                    return utilisateurs;
            }
            return null;
        }
        public void UpdateProductPriceHistory(int idProduct, decimal priceBefore, decimal priceAfter)
        {
            //ProductService.UpdateProductPriceHistory(idProduct, priceBefore, priceAfter);
        }
        public void Save(object entite)
        {
            switch (Entity.ToLower())
            {
                case "orderline":
                    Enregistrer<OrderLine>(entite);
                    break;
                case "customer":
                    Enregistrer<Customer>(entite);
                    break;
                case "stock":
                    Enregistrer<Stock>(entite);
                    break;
                case "productfile":
                    Enregistrer<ProductFile>(entite);
                    break;
                case "order":
                    Enregistrer<Order>(entite);
                    break;
                case "product":
                    Enregistrer<Product>(entite);
                    break;
                case "productcategory":
                    Enregistrer<ProductCategory>(entite);
                    break;
                case "user":
                    Enregistrer<User>(entite);
                    break;
            }

            RafraichirDonnee();
        }

        private void Enregistrer<TModel>(Object entite)
        {
            BaseDao<TModel, int> daoModel = new BaseDao<TModel, int>();
            daoModel.Save((TModel)entite);
        }


        public void Inactivate(int id)
        {
            Object entity = null;
            if (id != 0)
            {
                entity = DataEditorService.GetById(NameSpace, Entity, id);
            }
            ManageClass manageClass = new ManageClass();
            if (entity != null)
            {
                Type type = entity.GetType();
                manageClass.AssignValue(type, entity, "false", "IsActive");
            }

            DataEditorService.Save(NameSpace, Entity, entity);
        }
        public void CopierLigne(int id)
        {
            Object entity = null;
            if (id != 0)
            {
                entity = DataEditorService.GetById(NameSpace, Entity, id);
            }
            ManageClass manageClass = new ManageClass();
            if (entity != null)
            {
                Type type = entity.GetType();
                manageClass.AssignValue(type, entity, "0", "Id");
            }
            View.IdCopy = DataEditorService.Save(NameSpace, Entity, entity);
        }


        public IList<PropertyWithLabel> ListeProprieteSansCelleSysteme(string nameSpace, string entity)
        {
            return GenerateControlsService.ListeProprieteSansCelleSysteme(nameSpace, entity, View.EntityInformations, View.EntityProperties);
        }
        public IList<ControlWithLabel> CreateControls(string nameSpace, string entity, bool isInserting, int id,
                                               int idEnterprise)
        {
            return GenerateControlsService.CreateControls(nameSpace, entity, isInserting, id, idEnterprise, View.EntityInformations, View.EntityProperties);
        }

        private void SetEntityInformationAndProperty()
        {
            View.EntityInformations = DAOEntityInformation.GetAllEntityInformationSimple();
            View.EntityProperties = DAOEntityProperty.GEtAllEntityProperty();
        }
        private EntityInformation FindEntityInformation()
        {
            SetEntityInformationAndProperty();
            ManageClass manageClass = new ManageClass();
            EntityInformation entityInformation = null;
            if (manageClass.IsExistInNameSpace("ATMTECH.ShoppingCart.Entities", Entity))
            {
                //entityInformation = DAOEntityInformation.GetEntity("ATMTECH.ShoppingCart.Entities." + Entity);
                entityInformation =
                    View.EntityInformations.Where(x => x.NameSpace == "ATMTECH.ShoppingCart.Entities." + Entity)
                        .ToList()[0];
                entityInformation.EntityProperties =
                    View.EntityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();
            }
            if (manageClass.IsExistInNameSpace("ATMTECH.Entities", Entity))
            {
                //  entityInformation = DAOEntityInformation.GetEntity("ATMTECH.Entities." + Entity);

                entityInformation =
                  View.EntityInformations.Where(x => x.NameSpace == "ATMTECH.Entities." + Entity)
                      .ToList()[0];
                entityInformation.EntityProperties =
                    View.EntityProperties.Where(x => x.EntityInformation.Id == entityInformation.Id).ToList();

            }
            return entityInformation;
        }
        private void RafraichirDonnee()
        {
            EntityInformation entityInformation = FindEntityInformation();
            if (entityInformation != null) View.InnerTitle = entityInformation.PageTitle;
        }
    }


}

using System.Collections.Generic;
using System.Linq;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;
using ATMTECH.ShoppingCart.Services.Interface.Francais;
using ATMTECH.ShoppingCart.Views.Base;
using ATMTECH.ShoppingCart.Views.Interface.Francais;

namespace ATMTECH.ShoppingCart.Views.Francais
{
    public class AjouterProduitAuPanierPresenter : BaseShoppingCartPresenter<IAjouterProduitAuPanierPresenter>
    {
        public AjouterProduitAuPanierPresenter(IAjouterProduitAuPanierPresenter view)
            : base(view)
        {
        }

        public IProduitService ProduitService { get; set; }
        public IClientService ClientService { get; set; }
        public ICommandeService CommandeService { get; set; }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
            AfficherProduit(View.IdProduit);
            AfficherListeDeroulanteCouleur();
            AfficherTaille();
            AfficherPrix();
            AfficherListeDesCouleurs();
            GererAffichagePourPossibiliteCommander();
        }
        public void AfficherListeDesCouleurs()
        {

            IList<Couleur> listeCouleur = new List<Couleur>();

            foreach (Stock stock in View.Produit.Stocks)
            {
                Couleur couleur = new Couleur
                {
                    Anglais = stock.ColorEnglish,
                    Francais = stock.ColorFrench,
                    EquivalentWeb = RetournerEquivalentCouleurWebStock(stock)
                };

                if (listeCouleur.Count(x => x.Anglais == stock.ColorEnglish) == 0)
                {
                    listeCouleur.Add(couleur);
                }
            }

            View.ListeCouleurs = listeCouleur;
        }
        public void AfficherTaille()
        {
            if (View.Produit != null)
            {
                IList<Taille> tailles = new List<Taille>();
                IList<Stock> stocks = View.Produit.Stocks.Where(x => x.ColorEnglish == View.Couleur).ToList();
                if (stocks.Count == 0)
                {
                    stocks = View.Produit.Stocks.Where(x => x.ColorFrench == View.Couleur).ToList();
                }

                foreach (Stock stock in stocks)
                {
                    int ordre = 0;
                    if (stock.Size == "OS") ordre = 0;
                    if (stock.Size == "S") ordre = 0;
                    if (stock.Size == "S/M") ordre = 0;
                    if (stock.Size == "M") ordre = 1;
                    if (stock.Size == "M/L") ordre = 1;
                    if (stock.Size == "L") ordre = 2;
                    if (stock.Size == "L/XL") ordre = 2;
                    if (stock.Size == "XL") ordre = 3;
                    if (stock.Size == "XL/2XL") ordre = 3;
                    if (stock.Size == "2XL") ordre = 4;
                    if (stock.Size == "3XL") ordre = 5;
                    if (stock.Size == "4XL") ordre = 6;
                    if (stock.Size == "5XL") ordre = 7;
                    if (stock.Size == "YXS") ordre = 0;
                    if (stock.Size == "XS") ordre = 1;
                    if (stock.Size == "YS") ordre = 1;
                    if (stock.Size == "YM") ordre = 2;
                    if (stock.Size == "YL") ordre = 3;
                    if (stock.Size == "YXL") ordre = 4;
                    if (tailles.Count(x => x.Nom == stock.Size) == 0)
                    {
                        tailles.Add(new Taille { Nom = stock.Size, Ordre = ordre });
                    }
                }

                View.Tailles = tailles.OrderBy(x => x.Ordre).ToList();
            }
        }
        public void AfficherListeDeroulanteCouleur()
        {
            if (View.Produit != null)
            {
                IList<string> couleur = new List<string>();
                foreach (Stock stock in View.Produit.Stocks.Where(stock => !couleur.Contains(stock.ColorFrench)))
                {
                    couleur.Add(stock.ColorFrench);
                }

                IList<string> color = new List<string>();
                foreach (Stock stock in View.Produit.Stocks.Where(stock => !color.Contains(stock.ColorEnglish)))
                {
                    color.Add(stock.ColorEnglish);
                }

                switch (CurrentLanguage)
                {
                    case LocalizationLanguage.FRENCH:
                        View.ListeDeroulanteCouleurs = couleur.OrderBy(x => x.ToLower()).ToList();
                        break;
                    case LocalizationLanguage.ENGLISH:
                        View.ListeDeroulanteCouleurs = color.OrderBy(x => x.ToLower()).ToList();
                        break;
                }
            }
        }
        public void AfficherProduit(int id)
        {
            if (id == 0)
            {
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
            View.Produit = ProduitService.ObtenirProduit(id);
        }
        public void AfficherPrix()
        {
            Stock stock = TrouverLeStockAvecTailleEtCouleur();
            decimal prixAjusteStock = 0;
            if (stock != null)
            {
                prixAjusteStock = stock.AdjustPrice;
            }

            View.PrixUnitaireEnSolde = View.Produit.SalePrice + prixAjusteStock;
            View.PrixUnitaireOriginal = View.Produit.UnitPrice + prixAjusteStock;


        }
        public void GererAffichagePourPossibiliteCommander()
        {
            View.EstPossibleDeCommander = ClientService.ClientAuthentifie != null;
        }
        public void AjouterLigneCommande()
        {
            Stock stock = TrouverLeStockAvecTailleEtCouleur();
            if (stock != null)
            {
                CommandeService.AjouterLigneCommande(stock.Id, View.Quantite);
                NavigationService.Redirect(Pages.Pages.DEFAULT);
            }
        }
        private Stock TrouverLeStockAvecTailleEtCouleur()
        {
            Stock stock = null;
            switch (CurrentLanguage)
            {
                case LocalizationLanguage.FRENCH:
                    stock = View.Produit.Stocks.FirstOrDefault(x => x.FeatureFrench == View.Taille + " - " + View.Couleur);
                    break;
                case LocalizationLanguage.ENGLISH:
                    stock = View.Produit.Stocks.FirstOrDefault(x => x.FeatureEnglish == View.Taille + " - " + View.Couleur);
                    break;
            }
            return stock;
        }
        private string RetournerEquivalentCouleurWebStock(Stock stock)
        {
            if (stock.FeatureEnglish.ToLower().IndexOf("cardinal red") > 0) return "#8C2633";
            if (stock.FeatureEnglish.ToLower().IndexOf("white") > 0) return "white";
            if (stock.FeatureEnglish.ToLower().IndexOf("navy") > 0) return "#353F5B";
            if (stock.FeatureEnglish.ToLower().IndexOf("forest green") > 0) return "#008977";
            if (stock.FeatureEnglish.ToLower().IndexOf("black") > 0) return "#25282a";
            if (stock.FeatureEnglish.ToLower().IndexOf("red") > 0) return "#b7312c";
            if (stock.FeatureEnglish.ToLower().IndexOf("royal") > 0) return "#1d4f91";
            if (stock.FeatureEnglish.ToLower().IndexOf("maroon") > 0) return "#582d40";
            if (stock.FeatureEnglish.ToLower().IndexOf("sport grey") > 0) return "#d0d3d4";
            if (stock.FeatureEnglish.ToLower().IndexOf("safety green") > 0) return "#44d62c";
            if (stock.FeatureEnglish.ToLower().IndexOf("safety orange") > 0) return "#fe5000";
            if (stock.FeatureEnglish.ToLower().IndexOf("charcoal") > 0) return "#63666a";
            if (stock.FeatureEnglish.ToLower().IndexOf("purple") > 0) return "#3f2a56";
            if (stock.FeatureEnglish.ToLower().IndexOf("light pink") > 0) return "#dcb6c9";
            if (stock.FeatureEnglish.ToLower().IndexOf("gold") > 0) return "#ffb81c";
            if (stock.FeatureEnglish.ToLower().IndexOf("orange") > 0) return "#dc4405";
            if (stock.FeatureEnglish.ToLower().IndexOf("sand") > 0) return "#c5b9ac";
            if (stock.FeatureEnglish.ToLower().IndexOf("light blue") > 0) return "#a2b2c8";
            if (stock.FeatureEnglish.ToLower().IndexOf("indigo blue") > 0) return "#4f758b";
            if (stock.FeatureEnglish.ToLower().IndexOf("ash grey") > 0) return "#c8c9c7";
            if (stock.FeatureEnglish.ToLower().IndexOf("dark chocolate") > 0) return "#3e2b2e";
            if (stock.FeatureEnglish.ToLower().IndexOf("dark heather") > 0) return "#3f4444";
            if (stock.FeatureEnglish.ToLower().IndexOf("carolina blue") > 0) return "#7ba4db";
            if (stock.FeatureEnglish.ToLower().IndexOf("irish green") > 0) return "#00966c";
            if (stock.FeatureEnglish.ToLower().IndexOf("cherry red") > 0) return "#a6192e";
            if (stock.FeatureEnglish.ToLower().IndexOf("heliconia") > 0) return "#e31c79";
            if (stock.FeatureEnglish.ToLower().IndexOf("military green") > 0) return "#65665c";
            if (stock.FeatureEnglish.ToLower().IndexOf("kiwi") > 0) return "#a2a569";
            if (stock.FeatureEnglish.ToLower().IndexOf("antique sapphire") > 0) return "#006a8e";
            if (stock.FeatureEnglish.ToLower().IndexOf("navy/sport grey") > 0) return "#1f2a44/#d0d3d4";
            if (stock.FeatureEnglish.ToLower().IndexOf("black/sport grey") > 0) return "#25282a/#d0d3d4";
            if (stock.FeatureEnglish.ToLower().IndexOf("red/sport grey") > 0) return "#b7312c/#d0d3d4";
            if (stock.FeatureEnglish.ToLower().IndexOf("royal/sport grey") > 0) return "#1d4f91/#d0d3d4";
            if (stock.FeatureEnglish.ToLower().IndexOf("sport grey/black") > 0) return "#d0d3d4/#25282a";
            if (stock.FeatureEnglish.ToLower().IndexOf("black/red") > 0) return "#25282a/#b7312c";
            if (stock.FeatureEnglish.ToLower().IndexOf("navy/gold") > 0) return "#1f2a44/#ffb81c";
            if (stock.FeatureEnglish.ToLower().IndexOf("azalea") > 0) return "#eb6fbd";
            if (stock.FeatureEnglish.ToLower().IndexOf("moss") > 0) return "#3d441e";
            if (stock.FeatureEnglish.ToLower().IndexOf("russet") > 0) return "#512f2e";
            if (stock.FeatureEnglish.ToLower().IndexOf("tweed") > 0) return "#4b4f54";
            if (stock.FeatureEnglish.ToLower().IndexOf("meadow") > 0) return "#046a38";
            if (stock.FeatureEnglish.ToLower().IndexOf("blackberry") > 0) return "#4a3041";
            if (stock.FeatureEnglish.ToLower().IndexOf("lilac") > 0) return "#563d82";
            if (stock.FeatureEnglish.ToLower().IndexOf("sunset") > 0) return "#dc6b2f";
            if (stock.FeatureEnglish.ToLower().IndexOf("midnight") > 0) return "#005670";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather grey") > 0) return "#768692";
            if (stock.FeatureEnglish.ToLower().IndexOf("stream") > 0) return "stream";
            if (stock.FeatureEnglish.ToLower().IndexOf("night") > 0) return "night";
            if (stock.FeatureEnglish.ToLower().IndexOf("grey") > 0) return "grey";
            if (stock.FeatureEnglish.ToLower().IndexOf("orbit heather grey") > 0) return "orbit heather grey";
            if (stock.FeatureEnglish.ToLower().IndexOf("knight blue") > 0) return "knight blue";
            if (stock.FeatureEnglish.ToLower().IndexOf("dark grey") > 0) return "#3E4545";
            if (stock.FeatureEnglish.ToLower().IndexOf("blue") > 0) return "blue";
            if (stock.FeatureEnglish.ToLower().IndexOf("english blue") > 0) return "english blue";
            if (stock.FeatureEnglish.ToLower().IndexOf("french grey") > 0) return "french grey";
            if (stock.FeatureEnglish.ToLower().IndexOf("danish blue") > 0) return "danish blue";
            if (stock.FeatureEnglish.ToLower().IndexOf("blue mist") > 0) return "blue mist";
            if (stock.FeatureEnglish.ToLower().IndexOf("blue ocean") > 0) return "#0077BE";
            if (stock.FeatureEnglish.ToLower().IndexOf("cobalt") > 0) return "#0047bb";
            if (stock.FeatureEnglish.ToLower().IndexOf("grey charcoal") > 0) return "#63666a";
            if (stock.FeatureEnglish.ToLower().IndexOf("stone blue") > 0) return "#768692";
            if (stock.FeatureEnglish.ToLower().IndexOf("lime") > 0) return "#78d64b";
            if (stock.FeatureEnglish.ToLower().IndexOf("kelly green") > 0) return "#007b5f";
            if (stock.FeatureEnglish.ToLower().IndexOf("ice grey") > 0) return "ice grey";
            if (stock.FeatureEnglish.ToLower().IndexOf("texas orange") > 0) return "#b15533";
            if (stock.FeatureEnglish.ToLower().IndexOf("sapphire") > 0) return "#00F2F2";
            if (stock.FeatureEnglish.ToLower().IndexOf("natural") > 0) return "#b46a55";
            if (stock.FeatureEnglish.ToLower().IndexOf("tangerine") > 0) return "#FF7000";
            if (stock.FeatureEnglish.ToLower().IndexOf("olive") > 0) return "#51534a";
            if (stock.FeatureEnglish.ToLower().IndexOf("iris") > 0) return "#407ec9";
            if (stock.FeatureEnglish.ToLower().IndexOf("prairie dust") > 0) return "#7a7256";
            if (stock.FeatureEnglish.ToLower().IndexOf("blue dusk") > 0) return "#253746";
            if (stock.FeatureEnglish.ToLower().IndexOf("metro blue") > 0) return "#1b365d";
            if (stock.FeatureEnglish.ToLower().IndexOf("tan") > 0) return "#a899968";
            if (stock.FeatureEnglish.ToLower().IndexOf("daisy") > 0) return "#f6be00";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather navy") > 0) return "#333F48";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather indigo") > 0) return "#5B6770";
            if (stock.FeatureEnglish.ToLower().IndexOf("sky") > 0) return "#71c5e8";
            if (stock.FeatureEnglish.ToLower().IndexOf("honey") > 0) return "#EDAE5A";
            if (stock.FeatureEnglish.ToLower().IndexOf("orchid") > 0) return "#c5b4e3";
            if (stock.FeatureEnglish.ToLower().IndexOf("antique royal") > 0) return "#003087";
            if (stock.FeatureEnglish.ToLower().IndexOf("safety pink") > 0) return "#E16F8F";
            if (stock.FeatureEnglish.ToLower().IndexOf("mint green") > 0) return "#A0CFAB";
            if (stock.FeatureEnglish.ToLower().IndexOf("pistachio") > 0) return "#BDC293";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather blue") > 0) return "#3B60AF";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather charcoal") > 0) return "#616265";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather brown") > 0) return "heather brown";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather green") > 0) return "#00A353";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather red") > 0) return "#a20067";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather orange") > 0) return "#FF8D6D";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather purple") > 0) return "#614B79";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather fuchsia") > 0) return "heather fuchsia";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather graphite") > 0) return "heather graphite";
            if (stock.FeatureEnglish.ToLower().IndexOf("pewter grey") > 0) return "pewter grey";
            if (stock.FeatureEnglish.ToLower().IndexOf("stadium green") > 0) return "stadium green";
            if (stock.FeatureEnglish.ToLower().IndexOf("valor blue") > 0) return "valor blue";
            if (stock.FeatureEnglish.ToLower().IndexOf("varsity purple") > 0) return "varsity purple";
            if (stock.FeatureEnglish.ToLower().IndexOf("perfect pink") > 0) return "perfect pink";
            if (stock.FeatureEnglish.ToLower().IndexOf("team maroon") > 0) return "perfect pink";
            if (stock.FeatureEnglish.ToLower().IndexOf("university red") > 0) return "university red";
            if (stock.FeatureEnglish.ToLower().IndexOf("team orange") > 0) return "team orange";
            if (stock.FeatureEnglish.ToLower().IndexOf("chlorine blue") > 0) return "chlorine blue";
            if (stock.FeatureEnglish.ToLower().IndexOf("city green") > 0) return "#3E4723";
            if (stock.FeatureEnglish.ToLower().IndexOf("chocolate") > 0) return "#4E2A28";
            if (stock.FeatureEnglish.ToLower().IndexOf("green apple") > 0) return "#3D9B35";
            if (stock.FeatureEnglish.ToLower().IndexOf("river blue") > 0) return "#7498C0";
            if (stock.FeatureEnglish.ToLower().IndexOf("marbled charcoal") > 0) return "#55565A";
            if (stock.FeatureEnglish.ToLower().IndexOf("marbled galapagos") > 0) return "#005C82";
            if (stock.FeatureEnglish.ToLower().IndexOf("marbled heliconia") > 0) return "#D50F67";
            if (stock.FeatureEnglish.ToLower().IndexOf("marbled royal") > 0) return "#2E5596";
            if (stock.FeatureEnglish.ToLower().IndexOf("eco white") > 0) return "eco white";
            if (stock.FeatureEnglish.ToLower().IndexOf("independence red") > 0) return "#892034";
            if (stock.FeatureEnglish.ToLower().IndexOf("marron") > 0) return "marron";
            if (stock.FeatureEnglish.ToLower().IndexOf("yellow") > 0) return "yellow";
            if (stock.FeatureEnglish.ToLower().IndexOf("gravel") > 0) return "#747B7E";
            if (stock.FeatureEnglish.ToLower().IndexOf("azelea") > 0) return "azelea";
            if (stock.FeatureEnglish.ToLower().IndexOf("vivid lime") > 0) return "vivid lime";
            if (stock.FeatureEnglish.ToLower().IndexOf("uniform black") > 0) return "uniform black";
            if (stock.FeatureEnglish.ToLower().IndexOf("red violet") > 0) return "red violet";
            if (stock.FeatureEnglish.ToLower().IndexOf("tenesse orange") > 0) return "tenesse orange";
            if (stock.FeatureEnglish.ToLower().IndexOf("ant.cherry red") > 0) return "#971B2F";
            if (stock.FeatureEnglish.ToLower().IndexOf("antique irish green") > 0) return "#00843D";
            if (stock.FeatureEnglish.ToLower().IndexOf("antique orange") > 0) return "#B33D26";
            if (stock.FeatureEnglish.ToLower().IndexOf("berry") > 0) return "#7F2952";
            if (stock.FeatureEnglish.ToLower().IndexOf("electric green") > 0) return "#43B02A";
            if (stock.FeatureEnglish.ToLower().IndexOf("violet") > 0) return "#8381BA";
            if (stock.FeatureEnglish.ToLower().IndexOf("heather sapphire") > 0) return "#0076A8";
            if (stock.FeatureEnglish.ToLower().IndexOf("antique cherry") > 0) return "#971B2F";
            if (stock.FeatureEnglish.ToLower().IndexOf("coral silk") > 0) return "#DF6B7C";
            if (stock.ColorEnglish.ToLower().IndexOf("university blue") >= 0) return "university blue";
            if (stock.ColorEnglish.ToLower().IndexOf("college navy") >= 0) return "#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("game royal") >= 0) return "game royal";
            if (stock.ColorEnglish.ToLower().IndexOf("bright grape") >= 0) return "bright grape";
            if (stock.ColorEnglish.ToLower().IndexOf("court purple") >= 0) return "court purple";
            if (stock.ColorEnglish.ToLower().IndexOf("universty red") >= 0) return "universty red";
            if (stock.ColorEnglish.ToLower().IndexOf("stadium grey") >= 0) return "stadium grey";
            if (stock.ColorEnglish.ToLower().IndexOf("squadron blue") >= 0) return "squadron blue";
            if (stock.ColorEnglish.ToLower().IndexOf("violet force") >= 0) return "violet force";
            if (stock.ColorEnglish.ToLower().IndexOf("night stadium") >= 0) return "night stadium";
            if (stock.ColorEnglish.ToLower().IndexOf("poison green") >= 0) return "poison green";
            if (stock.ColorEnglish.ToLower().IndexOf("lucid green") >= 0) return "lucid green";
            if (stock.ColorEnglish.ToLower().IndexOf("turf orange") >= 0) return "turf orange";
            if (stock.ColorEnglish.ToLower().IndexOf("athletic grey") >= 0) return "athletic grey";
            if (stock.ColorEnglish.ToLower().IndexOf("denim") >= 0) return "denim";
            if (stock.ColorEnglish.ToLower().IndexOf("azure") >= 0) return "azure";
            if (stock.ColorEnglish.ToLower().IndexOf("white/navy") >= 0) return "white/#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("white/black") >= 0) return "white/black";
            if (stock.ColorEnglish.ToLower().IndexOf("white/red") >= 0) return "white/red";
            if (stock.ColorEnglish.ToLower().IndexOf("white/royal") >= 0) return "white/royal";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/royal") >= 0) return "#d0d3d4/royal";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/navy") >= 0) return "#d0d3d4/#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/red") >= 0) return "#d0d3d4/red";
            if (stock.ColorEnglish.ToLower().IndexOf("brown") >= 0) return "brown";
            if (stock.ColorEnglish.ToLower().IndexOf("black heather") >= 0) return "black heather";
            if (stock.ColorEnglish.ToLower().IndexOf("militairy blue") >= 0) return "militairy blue";
            if (stock.ColorEnglish.ToLower().IndexOf("lt. crimson") >= 0) return "lt. crimson";
            if (stock.ColorEnglish.ToLower().IndexOf("night factor") >= 0) return "night factor";
            if (stock.ColorEnglish.ToLower().IndexOf("military blue") >= 0) return "military blue";
            if (stock.ColorEnglish.ToLower().IndexOf("geranium") >= 0) return "geranium";
            if (stock.ColorEnglish.ToLower().IndexOf("corn silk") >= 0) return "corn silk";
            if (stock.ColorEnglish.ToLower().IndexOf("black/volt") >= 0) return "black/volt";
            if (stock.ColorEnglish.ToLower().IndexOf("black/dk grey") >= 0) return "black/dk grey";
            if (stock.ColorEnglish.ToLower().IndexOf("lt mg grey/dk grey") >= 0) return "lt mg grey/dk grey";
            if (stock.ColorEnglish.ToLower().IndexOf("cool grey/dk grey") >= 0) return "cool grey/dk grey";
            if (stock.ColorEnglish.ToLower().IndexOf("game royal/dk blue") >= 0) return "game royal/dk blue";
            if (stock.ColorEnglish.ToLower().IndexOf("univ red/dk grey") >= 0) return "univ red/dk grey";
            if (stock.ColorEnglish.ToLower().IndexOf("cool grey") >= 0) return "cool grey";
            if (stock.ColorEnglish.ToLower().IndexOf("lt blue lacquer/bl") >= 0) return "lt blue lacquer/bl";
            if (stock.ColorEnglish.ToLower().IndexOf("dairing red/red") >= 0) return "dairing red/red";
            if (stock.ColorEnglish.ToLower().IndexOf("black/stadium") >= 0) return "black/stadium";
            if (stock.ColorEnglish.ToLower().IndexOf("dove grey/volt") >= 0) return "dove grey/volt";
            if (stock.ColorEnglish.ToLower().IndexOf("clear water/grey") >= 0) return "clear water/grey";
            if (stock.ColorEnglish.ToLower().IndexOf("daring red/red") >= 0) return "daring red/red";
            if (stock.ColorEnglish.ToLower().IndexOf("dove grey/black") >= 0) return "dove grey/black";
            if (stock.ColorEnglish.ToLower().IndexOf("dove grey/charcoal") >= 0) return "dove grey/charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("lt blue lacquer/blue") >= 0) return "lt blue lacquer/blue";
            if (stock.ColorEnglish.ToLower().IndexOf("black/white") >= 0) return "black/white";
            if (stock.ColorEnglish.ToLower().IndexOf("blue force/water") >= 0) return "blue force/water";
            if (stock.ColorEnglish.ToLower().IndexOf("blue force") >= 0) return "blue force";
            if (stock.ColorEnglish.ToLower().IndexOf("gym red") >= 0) return "gym red";
            if (stock.ColorEnglish.ToLower().IndexOf("dove grey") >= 0) return "dove grey";
            if (stock.ColorEnglish.ToLower().IndexOf("light green") >= 0) return "light green";
            if (stock.ColorEnglish.ToLower().IndexOf("lt blue lacquer") >= 0) return "lt blue lacquer";
            if (stock.ColorEnglish.ToLower().IndexOf("bleu force") >= 0) return "bleu force";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal/black") >= 0) return "charcoal/black";
            if (stock.ColorEnglish.ToLower().IndexOf("royal blue") >= 0) return "royal blue";
            if (stock.ColorEnglish.ToLower().IndexOf("heather irish green") >= 0) return "heather irish green";
            if (stock.ColorEnglish.ToLower().IndexOf("heather royal") >= 0) return "heather royal";
            if (stock.ColorEnglish.ToLower().IndexOf("pure platinum") >= 0) return "pure platinum";
            if (stock.ColorEnglish.ToLower().IndexOf("black/dove grey") >= 0) return "black/dove grey";
            if (stock.ColorEnglish.ToLower().IndexOf("blue force/blue") >= 0) return "blue force/blue";
            if (stock.ColorEnglish.ToLower().IndexOf("dark navy") >= 0) return "dark #1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("light charcoal") >= 0) return "light charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("jet black") >= 0) return "jet black";
            if (stock.ColorEnglish.ToLower().IndexOf("heather dark grey") >= 0) return "heather dark grey";
            if (stock.ColorEnglish.ToLower().IndexOf("heather aubergine") >= 0) return "heather aubergine";
            if (stock.ColorEnglish.ToLower().IndexOf("heather galapagos") >= 0) return "heather galapagos";
            if (stock.ColorEnglish.ToLower().IndexOf("heather raspberry") >= 0) return "heather raspberry";
            if (stock.ColorEnglish.ToLower().IndexOf("heather blue/h.grey") >= 0) return "heather blue/h.grey";
            if (stock.ColorEnglish.ToLower().IndexOf("white/h.dark grey") >= 0) return "white/h.dark grey";
            if (stock.ColorEnglish.ToLower().IndexOf("h.grey/h.dark grey") >= 0) return "h.grey/h.dark grey";
            if (stock.ColorEnglish.ToLower().IndexOf("h.grey/h.aubergine") >= 0) return "h.grey/h.aubergine";
            if (stock.ColorEnglish.ToLower().IndexOf("h.grey/h.bleu") >= 0) return "h.grey/h.bleu";
            if (stock.ColorEnglish.ToLower().IndexOf("heather grey/h.red") >= 0) return "heather grey/h.red";
            if (stock.ColorEnglish.ToLower().IndexOf("bright gold") >= 0) return "bright gold";
            if (stock.ColorEnglish.ToLower().IndexOf("independent red") >= 0) return "independent red";
            if (stock.ColorEnglish.ToLower().IndexOf("heather grey") >= 0) return "heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("jade dome") >= 0) return "jade dome";
            if (stock.ColorEnglish.ToLower().IndexOf("charity pink") >= 0) return "charity pink";
            if (stock.ColorEnglish.ToLower().IndexOf("caribbean blue") >= 0) return "caribbean blue";
            if (stock.ColorEnglish.ToLower().IndexOf("spring yellow") >= 0) return "spring yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("heather dk grey") >= 0) return "heather dk grey";
            if (stock.ColorEnglish.ToLower().IndexOf("hot pink") >= 0) return "hot pink";
            if (stock.ColorEnglish.ToLower().IndexOf("carribean blue") >= 0) return "carribean blue";
            if (stock.ColorEnglish.ToLower().IndexOf("white/dark grey") >= 0) return "white/dark grey";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/dark grey") >= 0) return "navy/dark grey";
            if (stock.ColorEnglish.ToLower().IndexOf("black/dark grey") >= 0) return "black/dark grey";
            if (stock.ColorEnglish.ToLower().IndexOf("heather purple/neon yellow") >= 0) return "heather purple/neon yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("hot pink/neon yellow") >= 0) return "hot pink/neon yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("heather blue/neon yellow") >= 0) return "heather blue/neon yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("heather green/neon yellow") >= 0) return "heather green/neon yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("heather dk grey/dark grey") >= 0) return "heather dk grey/dark grey";
            if (stock.ColorEnglish.ToLower().IndexOf("navy / charcoal") >= 0) return "#1f2a44/ charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("black / charcoal") >= 0) return "black / charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal / charcoal") >= 0) return "charcoal / charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey / charcoal") >= 0) return "#d0d3d4/ charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("camouflage green") >= 0) return "camouflage green";
            if (stock.ColorEnglish.ToLower().IndexOf("camouflage sand") >= 0) return "camouflage sand";
            if (stock.ColorEnglish.ToLower().IndexOf("storm grey") >= 0) return "storm grey";
            if (stock.ColorEnglish.ToLower().IndexOf("silver") >= 0) return "silver";
            if (stock.ColorEnglish.ToLower().IndexOf("smoke") >= 0) return "smoke";
            if (stock.ColorEnglish.ToLower().IndexOf("independent red/navy") >= 0) return "red/#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("white/heather grey") >= 0) return "white/heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("caribbean bl/h.grey") >= 0) return "caribbean bl/h.grey";
            if (stock.ColorEnglish.ToLower().IndexOf("heather dark grey/dkgrey") >= 0) return "heather dark grey/dkgrey";
            if (stock.ColorEnglish.ToLower().IndexOf("black/gold") >= 0) return "black/gold";
            if (stock.ColorEnglish.ToLower().IndexOf("black/orange") >= 0) return "black/orange";
            if (stock.ColorEnglish.ToLower().IndexOf("brown/khaki") >= 0) return "brown/khaki";
            if (stock.ColorEnglish.ToLower().IndexOf("khaki/black") >= 0) return "khaki/black";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/white") >= 0) return "#1f2a44/white";
            if (stock.ColorEnglish.ToLower().IndexOf("red/black") >= 0) return "red/black";
            if (stock.ColorEnglish.ToLower().IndexOf("royal/white") >= 0) return "royal/white";
            if (stock.ColorEnglish.ToLower().IndexOf("forest/gold") >= 0) return "forest/gold";
            if (stock.ColorEnglish.ToLower().IndexOf("forest/white") >= 0) return "forest/white";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/gray") >= 0) return "#1f2a44/gray";
            if (stock.ColorEnglish.ToLower().IndexOf("red/white") >= 0) return "red/white";
            if (stock.ColorEnglish.ToLower().IndexOf("pink") >= 0) return "pink";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather") >= 0) return "deep heather";
            if (stock.ColorEnglish.ToLower().IndexOf("true royal") >= 0) return "true royal";
            if (stock.ColorEnglish.ToLower().IndexOf("white/pink") >= 0) return "white/pink";
            if (stock.ColorEnglish.ToLower().IndexOf("dark heather/black") >= 0) return "dark heather/black";
            if (stock.ColorEnglish.ToLower().IndexOf("heather slate") >= 0) return "heather slate";
            if (stock.ColorEnglish.ToLower().IndexOf("team purple") >= 0) return "team purple";
            if (stock.ColorEnglish.ToLower().IndexOf("dark grey heather") >= 0) return "dark grey heather";
            if (stock.ColorEnglish.ToLower().IndexOf("athletic heather") >= 0) return "athletic heather";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather/black") >= 0) return "deep heather/black";
            if (stock.ColorEnglish.ToLower().IndexOf("heather blue/navy") >= 0) return "heather blue/#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("heather green/forest") >= 0) return "heather green/forest";
            if (stock.ColorEnglish.ToLower().IndexOf("heather brown/brown") >= 0) return "heather brown/brown";
            if (stock.ColorEnglish.ToLower().IndexOf("white/asphalt") >= 0) return "white/asphalt";
            if (stock.ColorEnglish.ToLower().IndexOf("white/true royal") >= 0) return "white/true royal";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather/bk") >= 0) return "deep heather/bk";
            if (stock.ColorEnglish.ToLower().IndexOf("blue triblend") >= 0) return "blue triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal triblend") >= 0) return "charcoal triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("grey triblend") >= 0) return "grey triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("light red triblend") >= 0) return "light red triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("navy triblend") >= 0) return "#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("white fleck triblend") >= 0) return "white fleck triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("black/grey") >= 0) return "black/grey";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/grey") >= 0) return "#1f2a44/grey";
            if (stock.ColorEnglish.ToLower().IndexOf("granite/black") >= 0) return "granite/black";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather/dk grey") >= 0) return "deep heather/dk grey";
            if (stock.ColorEnglish.ToLower().IndexOf("asphalt") >= 0) return "asphalt";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal marble") >= 0) return "charcoal marble";
            if (stock.ColorEnglish.ToLower().IndexOf("navy marble") >= 0) return "#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("white marble") >= 0) return "white marble";
            if (stock.ColorEnglish.ToLower().IndexOf("black marble") >= 0) return "black marble";
            if (stock.ColorEnglish.ToLower().IndexOf("true royal marble") >= 0) return "true royal marble";
            if (stock.ColorEnglish.ToLower().IndexOf("d.grey heather/bk") >= 0) return "d.grey heather/bk";
            if (stock.ColorEnglish.ToLower().IndexOf("digital black") >= 0) return "digital black";
            if (stock.ColorEnglish.ToLower().IndexOf("digital grey") >= 0) return "digital grey";
            if (stock.ColorEnglish.ToLower().IndexOf("digital blue") >= 0) return "digital blue";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather/navy") >= 0) return "#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("solid black triblend") >= 0) return "solid black triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("fuchsia") >= 0) return "fuchsia";
            if (stock.ColorEnglish.ToLower().IndexOf("turquoise") >= 0) return "turquoise";
            if (stock.ColorEnglish.ToLower().IndexOf("solid white triblend") >= 0) return "solid white triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("red triblend") >= 0) return "red triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("green triblend") >= 0) return "green triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("teal") >= 0) return "teal";
            if (stock.ColorEnglish.ToLower().IndexOf("marble black") >= 0) return "marble black";
            if (stock.ColorEnglish.ToLower().IndexOf("marble red") >= 0) return "marble red";
            if (stock.ColorEnglish.ToLower().IndexOf("blue marble") >= 0) return "blue marble";
            if (stock.ColorEnglish.ToLower().IndexOf("dark grey/venom") >= 0) return "dark grey/venom";
            if (stock.ColorEnglish.ToLower().IndexOf("metallic silver/red") >= 0) return "metallic silver/red";
            if (stock.ColorEnglish.ToLower().IndexOf("black blue / white") >= 0) return "black blue / white";
            if (stock.ColorEnglish.ToLower().IndexOf("black/blue") >= 0) return "black/blue";
            if (stock.ColorEnglish.ToLower().IndexOf("black tartan") >= 0) return "black tartan";
            if (stock.ColorEnglish.ToLower().IndexOf("black/silver") >= 0) return "black/silver";
            if (stock.ColorEnglish.ToLower().IndexOf("white/silver") >= 0) return "white/silver";
            if (stock.ColorEnglish.ToLower().IndexOf("midnight navy/white") >= 0) return "#1f2a44/white";
            if (stock.ColorEnglish.ToLower().IndexOf("lt.crimson/silver") >= 0) return "lt.crimson/silver";
            if (stock.ColorEnglish.ToLower().IndexOf("real tree max") >= 0) return "real tree max";
            if (stock.ColorEnglish.ToLower().IndexOf("hardwood green") >= 0) return "hardwood green";
            if (stock.ColorEnglish.ToLower().IndexOf("khaki") >= 0) return "khaki";
            if (stock.ColorEnglish.ToLower().IndexOf("blaze orange") >= 0) return "blaze orange";
            if (stock.ColorEnglish.ToLower().IndexOf("light tan") >= 0) return "light tan";
            if (stock.ColorEnglish.ToLower().IndexOf("earth buck") >= 0) return "earth buck";
            if (stock.ColorEnglish.ToLower().IndexOf("bark/orange") >= 0) return "bark/orange";
            if (stock.ColorEnglish.ToLower().IndexOf("flit-orange") >= 0) return "flit-orange";
            if (stock.ColorEnglish.ToLower().IndexOf("tobacco") >= 0) return "tobacco";
            if (stock.ColorEnglish.ToLower().IndexOf("black/purple") >= 0) return "black/purple";
            if (stock.ColorEnglish.ToLower().IndexOf("black/teal") >= 0) return "black/teal";
            if (stock.ColorEnglish.ToLower().IndexOf("natural/black") >= 0) return "natural/black";
            if (stock.ColorEnglish.ToLower().IndexOf("gray/black") >= 0) return "gray/black";
            if (stock.ColorEnglish.ToLower().IndexOf("dark gray") >= 0) return "dark gray";
            if (stock.ColorEnglish.ToLower().IndexOf("black/green") >= 0) return "black/green";
            if (stock.ColorEnglish.ToLower().IndexOf("black/gray") >= 0) return "black/gray";
            if (stock.ColorEnglish.ToLower().IndexOf("black red") >= 0) return "black red";
            if (stock.ColorEnglish.ToLower().IndexOf("gray") >= 0) return "gray";
            if (stock.ColorEnglish.ToLower().IndexOf("spruce") >= 0) return "spruce";
            if (stock.ColorEnglish.ToLower().IndexOf("khaki/spruce") >= 0) return "khaki/spruce";
            if (stock.ColorEnglish.ToLower().IndexOf("red/navy") >= 0) return "red/#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("black/lt.stone") >= 0) return "black/lt.stone";
            if (stock.ColorEnglish.ToLower().IndexOf("brown/lt.stone") >= 0) return "brown/lt.stone";
            if (stock.ColorEnglish.ToLower().IndexOf("loden/gr.stone") >= 0) return "loden/gr.stone";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/lt.stone") >= 0) return "#1f2a44/lt.stone";
            if (stock.ColorEnglish.ToLower().IndexOf("green camo") >= 0) return "green camo";
            if (stock.ColorEnglish.ToLower().IndexOf("silver camo") >= 0) return "silver camo";
            if (stock.ColorEnglish.ToLower().IndexOf("loden green") >= 0) return "loden green";
            if (stock.ColorEnglish.ToLower().IndexOf("natural black") >= 0) return "natural black";
            if (stock.ColorEnglish.ToLower().IndexOf("natural chocolat") >= 0) return "natural chocolat";
            if (stock.ColorEnglish.ToLower().IndexOf("natural clover") >= 0) return "natural clover";
            if (stock.ColorEnglish.ToLower().IndexOf("aqua print") >= 0) return "aqua print";
            if (stock.ColorEnglish.ToLower().IndexOf("flamingo print") >= 0) return "flamingo print";
            if (stock.ColorEnglish.ToLower().IndexOf("natural flamingo") >= 0) return "natural flamingo";
            if (stock.ColorEnglish.ToLower().IndexOf("natural orange") >= 0) return "natural orange";
            if (stock.ColorEnglish.ToLower().IndexOf("natural storm") >= 0) return "natural storm";
            if (stock.ColorEnglish.ToLower().IndexOf("natural chocolate") >= 0) return "natural chocolate";
            if (stock.ColorEnglish.ToLower().IndexOf("natural navy") >= 0) return "natural #1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("natural sky blue") >= 0) return "natural sky blue";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/flamingo") >= 0) return "#1f2a44/flamingo";
            if (stock.ColorEnglish.ToLower().IndexOf("red black") >= 0) return "red black";
            if (stock.ColorEnglish.ToLower().IndexOf("flamingo") >= 0) return "flamingo";
            if (stock.ColorEnglish.ToLower().IndexOf("skyblue") >= 0) return "skyblue";
            if (stock.ColorEnglish.ToLower().IndexOf("max") >= 0) return "max";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal mix") >= 0) return "charcoal mix";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey /black") >= 0) return "#d0d3d4/black";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/forest green") >= 0) return "#d0d3d4/forest green";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/purple") >= 0) return "#d0d3d4/purple";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/royal blue") >= 0) return "#d0d3d4/royal blue";
            if (stock.ColorEnglish.ToLower().IndexOf("black/charcoal") >= 0) return "black/charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("black/kelly") >= 0) return "black/kelly";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal/red") >= 0) return "charcoal/red";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/light blue") >= 0) return "#1f2a44/light blue";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/red") >= 0) return "#1f2a44/red";
            if (stock.ColorEnglish.ToLower().IndexOf("realtree ap") >= 0) return "realtree ap";
            if (stock.ColorEnglish.ToLower().IndexOf("realtree white") >= 0) return "realtree white";
            if (stock.ColorEnglish.ToLower().IndexOf("mossy oak") >= 0) return "mossy oak";
            if (stock.ColorEnglish.ToLower().IndexOf("realtree") >= 0) return "realtree";
            if (stock.ColorEnglish.ToLower().IndexOf("camo") >= 0) return "camo";
            if (stock.ColorEnglish.ToLower().IndexOf("kelly") >= 0) return "kelly";
            if (stock.ColorEnglish.ToLower().IndexOf("columbia") >= 0) return "columbia";
            if (stock.ColorEnglish.ToLower().IndexOf("michelangelo") >= 0) return "michelangelo";
            if (stock.ColorEnglish.ToLower().IndexOf("red/gray") >= 0) return "red/gray";
            if (stock.ColorEnglish.ToLower().IndexOf("black/royal") >= 0) return "black/royal";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/columbia") >= 0) return "#1f2a44/columbia";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/orange") >= 0) return "#1f2a44/orange";
            if (stock.ColorEnglish.ToLower().IndexOf("maroon/gold") >= 0) return "maroon/gold";
            if (stock.ColorEnglish.ToLower().IndexOf("purple/gold") >= 0) return "purple/gold";
            if (stock.ColorEnglish.ToLower().IndexOf("granite") >= 0) return "granite";
            if (stock.ColorEnglish.ToLower().IndexOf("binary blue") >= 0) return "binary blue";
            if (stock.ColorEnglish.ToLower().IndexOf("red university") >= 0) return "red university";
            if (stock.ColorEnglish.ToLower().IndexOf("light bone") >= 0) return "light bone";
            if (stock.ColorEnglish.ToLower().IndexOf("pink pow") >= 0) return "pink pow";
            if (stock.ColorEnglish.ToLower().IndexOf("black/anthracite") >= 0) return "black/anthracite";
            if (stock.ColorEnglish.ToLower().IndexOf("white/dove/grey") >= 0) return "white/dove/grey";
            if (stock.ColorEnglish.ToLower().IndexOf("advantage classic") >= 0) return "advantage classic";
            if (stock.ColorEnglish.ToLower().IndexOf("original mossyoak breakup") >= 0) return "original mossyoak breakup";
            if (stock.ColorEnglish.ToLower().IndexOf("neon yellow") >= 0) return "neon yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("navy blue") >= 0) return "#1f2a44 blue";
            if (stock.ColorEnglish.ToLower().IndexOf("grey red") >= 0) return "grey red";
            if (stock.ColorEnglish.ToLower().IndexOf("orion blue") >= 0) return "orion blue";
            if (stock.ColorEnglish.ToLower().IndexOf("grigio scuro") >= 0) return "grigio scuro";
            if (stock.ColorEnglish.ToLower().IndexOf("graphite") >= 0) return "graphite";
            if (stock.ColorEnglish.ToLower().IndexOf("electric blue") >= 0) return "electric blue";
            if (stock.ColorEnglish.ToLower().IndexOf("red line") >= 0) return "red line";
            if (stock.ColorEnglish.ToLower().IndexOf("dark heather grey") >= 0) return "dark heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("stone grey") >= 0) return "stone grey";
            if (stock.ColorEnglish.ToLower().IndexOf("jet back") >= 0) return "jet back";
            if (stock.ColorEnglish.ToLower().IndexOf("dark blue") >= 0) return "dark blue";
            if (stock.ColorEnglish.ToLower().IndexOf("light heather grey") >= 0) return "light heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("grenadine") >= 0) return "grenadine";
            if (stock.ColorEnglish.ToLower().IndexOf("jet black heather") >= 0) return "jet black heather";
            if (stock.ColorEnglish.ToLower().IndexOf("faded denim") >= 0) return "faded denim";
            if (stock.ColorEnglish.ToLower().IndexOf("brillant blue") >= 0) return "brillant blue";
            if (stock.ColorEnglish.ToLower().IndexOf("green slate") >= 0) return "green slate";
            if (stock.ColorEnglish.ToLower().IndexOf("cardinal") >= 0) return "cardinal";
            if (stock.ColorEnglish.ToLower().IndexOf("neon fuschia") >= 0) return "neon fuschia";
            if (stock.ColorEnglish.ToLower().IndexOf("neon green") >= 0) return "neon green";
            if (stock.ColorEnglish.ToLower().IndexOf("neon pink") >= 0) return "neon pink";
            if (stock.ColorEnglish.ToLower().IndexOf("safety yellow") >= 0) return "safety yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("black/taupe") >= 0) return "black/taupe";
            if (stock.ColorEnglish.ToLower().IndexOf("saddle/black") >= 0) return "saddle/black";
            if (stock.ColorEnglish.ToLower().IndexOf("dk heather grey") >= 0) return "dk heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("dk heather gy/bk") >= 0) return "dk heather gy/bk";
            if (stock.ColorEnglish.ToLower().IndexOf("dk heather gy/ny") >= 0) return "dk heather gy/ny";
            if (stock.ColorEnglish.ToLower().IndexOf("dk heather gy/rd") >= 0) return "dk heather gy/rd";
            if (stock.ColorEnglish.ToLower().IndexOf("heather") >= 0) return "heather";
            if (stock.ColorEnglish.ToLower().IndexOf("oatmeal") >= 0) return "oatmeal";
            if (stock.ColorEnglish.ToLower().IndexOf("lt heather grey") >= 0) return "lt heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("black/stone") >= 0) return "black/stone";
            if (stock.ColorEnglish.ToLower().IndexOf("forest/stone") >= 0) return "forest/stone";
            if (stock.ColorEnglish.ToLower().IndexOf("khaki/navy") >= 0) return "khaki/#1f2a44";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/stone") >= 0) return "navy/stone";
            if (stock.ColorEnglish.ToLower().IndexOf("red/stone") >= 0) return "red/stone";
            if (stock.ColorEnglish.ToLower().IndexOf("sage/stone") >= 0) return "sage/stone";
            if (stock.ColorEnglish.ToLower().IndexOf("stone/black") >= 0) return "stone/black";
            if (stock.ColorEnglish.ToLower().IndexOf("stone/navy") >= 0) return "stone/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("black/natural") >= 0) return "black/natural";
            if (stock.ColorEnglish.ToLower().IndexOf("darkgrey/black") >= 0) return "darkgrey/black";
            if (stock.ColorEnglish.ToLower().IndexOf("forest/natural") >= 0) return "forest/natural";
            if (stock.ColorEnglish.ToLower().IndexOf("khaki/forest") >= 0) return "khaki/forest";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/natural") >= 0) return "navy/natural";
            if (stock.ColorEnglish.ToLower().IndexOf("fatigue") >= 0) return "fatigue";
            if (stock.ColorEnglish.ToLower().IndexOf("ocean") >= 0) return "ocean";
            if (stock.ColorEnglish.ToLower().IndexOf("gray/charcoal") >= 0) return "gray/charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("light blue/navy") >= 0) return "light blue/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("olive/navy") >= 0) return "olive/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("orange/charcoal") >= 0) return "orange/charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("forest") >= 0) return "forest";
            if (stock.ColorEnglish.ToLower().IndexOf("stone") >= 0) return "stone";
            if (stock.ColorEnglish.ToLower().IndexOf("royal/black") >= 0) return "royal/black";
            if (stock.ColorEnglish.ToLower().IndexOf("antracite/black") >= 0) return "antracite/black";
            if (stock.ColorEnglish.ToLower().IndexOf("dk grey/mil.blue") >= 0) return "dk grey/mil.blue";
            if (stock.ColorEnglish.ToLower().IndexOf("anthracite black") >= 0) return "anthracite black";
            if (stock.ColorEnglish.ToLower().IndexOf("dk grey military blue") >= 0) return "dk grey military blue";
            if (stock.ColorEnglish.ToLower().IndexOf("wolf grey gym red") >= 0) return "wolf grey gym red";
            if (stock.ColorEnglish.ToLower().IndexOf("wolf grey/gym red") >= 0) return "wolf grey/gym red";
            if (stock.ColorEnglish.ToLower().IndexOf("dark grey volt") >= 0) return "dark grey volt";
            if (stock.ColorEnglish.ToLower().IndexOf("volt") >= 0) return "volt";
            if (stock.ColorEnglish.ToLower().IndexOf("vibrant green") >= 0) return "vibrant green";
            if (stock.ColorEnglish.ToLower().IndexOf("blue sky") >= 0) return "blue sky";
            if (stock.ColorEnglish.ToLower().IndexOf("salmon") >= 0) return "salmon";
            if (stock.ColorEnglish.ToLower().IndexOf("light grey") >= 0) return "light grey";
            if (stock.ColorEnglish.ToLower().IndexOf("hunter green") >= 0) return "hunter green";
            if (stock.ColorEnglish.ToLower().IndexOf("green") >= 0) return "green";
            if (stock.ColorEnglish.ToLower().IndexOf("blue/black") >= 0) return "blue/black";
            if (stock.ColorEnglish.ToLower().IndexOf("green/black") >= 0) return "green/black";
            if (stock.ColorEnglish.ToLower().IndexOf("yellow/black") >= 0) return "yellow/black";
            if (stock.ColorEnglish.ToLower().IndexOf("grey/black") >= 0) return "grey/black";
            if (stock.ColorEnglish.ToLower().IndexOf("baby blue") >= 0) return "baby blue";
            if (stock.ColorEnglish.ToLower().IndexOf("butter") >= 0) return "butter";
            if (stock.ColorEnglish.ToLower().IndexOf("khaki/brown") >= 0) return "khaki/brown";
            if (stock.ColorEnglish.ToLower().IndexOf("neon blue") >= 0) return "neon blue";
            if (stock.ColorEnglish.ToLower().IndexOf("neon orange") >= 0) return "neon orange";
            if (stock.ColorEnglish.ToLower().IndexOf("olive/stone") >= 0) return "olive/stone";
            if (stock.ColorEnglish.ToLower().IndexOf("sky blue") >= 0) return "sky blue";
            if (stock.ColorEnglish.ToLower().IndexOf("black/black") >= 0) return "black/black";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/navy") >= 0) return "navy/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("white/kelly green") >= 0) return "white/kelly green";
            if (stock.ColorEnglish.ToLower().IndexOf("white/white") >= 0) return "white/white";
            if (stock.ColorEnglish.ToLower().IndexOf("olive green") >= 0) return "olive green";
            if (stock.ColorEnglish.ToLower().IndexOf("tiger camo") >= 0) return "tiger camo";



            return null;
        }
    }
    public class Taille
    {
        public string Nom { get; set; }
        public int Ordre { get; set; }
    }

    public class Couleur
    {
        public string Anglais { get; set; }
        public string Francais { get; set; }
        public string EquivalentWeb { get; set; }
    }

}
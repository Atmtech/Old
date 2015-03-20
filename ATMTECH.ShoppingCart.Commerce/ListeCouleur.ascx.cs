using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using ATMTECH.Common.Constant;
using ATMTECH.ShoppingCart.Entities;

namespace ATMTECH.ShoppingCart.Commerce
{
    public partial class ListeCouleur : System.Web.UI.UserControl
    {
        public string Langue { get; set; }
        public Product Produit
        {
            get { return (Product)Session["produitCouleur"]; }
            set
            {
                string html = string.Empty;

                IList<Couleur> listeCouleur = new List<Couleur>();

                foreach (Stock stock in value.Stocks)
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

                foreach (Couleur couleur in listeCouleur)
                {
                    html += Langue == LocalizationLanguage.FRENCH
                                ? "<div title='" + couleur.Francais + "' style='background-color:" +
                                  couleur.EquivalentWeb +
                                  ";border:solid 1px gray; width: 20px; height:20px;float: left;margin-left: 5px;'>&nbsp;</div>"
                                : "<div title='" + couleur.Anglais + "' style='background-color:" +
                                  couleur.EquivalentWeb +
                                  ";border:solid 1px gray; width: 20px; height:20px;float: left;margin-left: 5px;'>&nbsp;</div>";
                }

                html += "<div style='clear: both;'></div>";
                Literal literal = new Literal { Text = html };
                placeHolderCouleur.Controls.Add(literal);
            }
        }

        private string RetournerEquivalentCouleurWebStock(Stock stock)
        {
            if (stock.ColorEnglish.ToLower().IndexOf("cardinal red") >= 0) return "red";
            if (stock.ColorEnglish.ToLower().IndexOf("white") >= 0) return "white";
            if (stock.ColorEnglish.ToLower().IndexOf("navy") >= 0) return "navy";
            if (stock.ColorEnglish.ToLower().IndexOf("forest green") >= 0) return "green";
            if (stock.ColorEnglish.ToLower().IndexOf("black") >= 0) return "black";
            if (stock.ColorEnglish.ToLower().IndexOf("red") >= 0) return "red";
            if (stock.ColorEnglish.ToLower().IndexOf("royal") >= 0) return "royal";
            if (stock.ColorEnglish.ToLower().IndexOf("maroon") >= 0) return "maroon";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey") >= 0) return "gray";
            if (stock.ColorEnglish.ToLower().IndexOf("safety green") >= 0) return "green";
            if (stock.ColorEnglish.ToLower().IndexOf("safety orange") >= 0) return "orange";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal") >= 0) return "darkgray";
            if (stock.ColorEnglish.ToLower().IndexOf("purple") >= 0) return "purple";
            if (stock.ColorEnglish.ToLower().IndexOf("light pink") >= 0) return "lightpink";
            if (stock.ColorEnglish.ToLower().IndexOf("gold") >= 0) return "gold";
            if (stock.ColorEnglish.ToLower().IndexOf("orange") >= 0) return "orange";
            if (stock.ColorEnglish.ToLower().IndexOf("sand") >= 0) return "sandybrown";
            if (stock.ColorEnglish.ToLower().IndexOf("light blue") >= 0) return "lightblue";
            if (stock.ColorEnglish.ToLower().IndexOf("indigo blue") >= 0) return "indigo";
            if (stock.ColorEnglish.ToLower().IndexOf("ash grey") >= 0) return "gray";
            if (stock.ColorEnglish.ToLower().IndexOf("dark chocolate") >= 0) return "chocolate";
            if (stock.ColorEnglish.ToLower().IndexOf("dark heather") >= 0) return "dark heather";
            if (stock.ColorEnglish.ToLower().IndexOf("carolina blue") >= 0) return "blue";
            if (stock.ColorEnglish.ToLower().IndexOf("irish green") >= 0) return "green";
            if (stock.ColorEnglish.ToLower().IndexOf("cherry red") >= 0) return "red";
            if (stock.ColorEnglish.ToLower().IndexOf("heliconia") >= 0) return "heliconia";
            if (stock.ColorEnglish.ToLower().IndexOf("military green") >= 0) return "green";
            if (stock.ColorEnglish.ToLower().IndexOf("kiwi") >= 0) return "kiwi";
            if (stock.ColorEnglish.ToLower().IndexOf("antique sapphire") >= 0) return "blue";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/sport grey") >= 0) return "navy/sport grey";
            if (stock.ColorEnglish.ToLower().IndexOf("black/sport grey") >= 0) return "black/sport grey";
            if (stock.ColorEnglish.ToLower().IndexOf("red/sport grey") >= 0) return "red/sport grey";
            if (stock.ColorEnglish.ToLower().IndexOf("royal/sport grey") >= 0) return "royal/sport grey";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/black") >= 0) return "sport grey/black";
            if (stock.ColorEnglish.ToLower().IndexOf("black/red") >= 0) return "black/red";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/gold") >= 0) return "navy/gold";
            if (stock.ColorEnglish.ToLower().IndexOf("azalea") >= 0) return "azalea";
            if (stock.ColorEnglish.ToLower().IndexOf("moss") >= 0) return "moss";
            if (stock.ColorEnglish.ToLower().IndexOf("russet") >= 0) return "russet";
            if (stock.ColorEnglish.ToLower().IndexOf("tweed") >= 0) return "tweed";
            if (stock.ColorEnglish.ToLower().IndexOf("meadow") >= 0) return "meadow";
            if (stock.ColorEnglish.ToLower().IndexOf("blackberry") >= 0) return "blackberry";
            if (stock.ColorEnglish.ToLower().IndexOf("lilac") >= 0) return "lilac";
            if (stock.ColorEnglish.ToLower().IndexOf("sunset") >= 0) return "sunset";
            if (stock.ColorEnglish.ToLower().IndexOf("midnight") >= 0) return "midnight";
            if (stock.ColorEnglish.ToLower().IndexOf("heather grey") >= 0) return "heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("stream") >= 0) return "stream";
            if (stock.ColorEnglish.ToLower().IndexOf("night") >= 0) return "night";
            if (stock.ColorEnglish.ToLower().IndexOf("grey") >= 0) return "gray";
            if (stock.ColorEnglish.ToLower().IndexOf("orbit heather grey") >= 0) return "orbit heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("knight blue") >= 0) return "blue";
            if (stock.ColorEnglish.ToLower().IndexOf("dark grey") >= 0) return "gray";
            if (stock.ColorEnglish.ToLower().IndexOf("blue") >= 0) return "blue";
            if (stock.ColorEnglish.ToLower().IndexOf("english blue") >= 0) return "blue";
            if (stock.ColorEnglish.ToLower().IndexOf("french grey") >= 0) return "french grey";
            if (stock.ColorEnglish.ToLower().IndexOf("danish blue") >= 0) return "danish blue";
            if (stock.ColorEnglish.ToLower().IndexOf("blue mist") >= 0) return "blue mist";
            if (stock.ColorEnglish.ToLower().IndexOf("blue ocean") >= 0) return "blue ocean";
            if (stock.ColorEnglish.ToLower().IndexOf("cobalt") >= 0) return "cobalt";
            if (stock.ColorEnglish.ToLower().IndexOf("grey charcoal") >= 0) return "grey charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("stone blue") >= 0) return "stone blue";
            if (stock.ColorEnglish.ToLower().IndexOf("lime") >= 0) return "lime";
            if (stock.ColorEnglish.ToLower().IndexOf("kelly green") >= 0) return "kelly green";
            if (stock.ColorEnglish.ToLower().IndexOf("ice grey") >= 0) return "ice grey";
            if (stock.ColorEnglish.ToLower().IndexOf("texas orange") >= 0) return "texas orange";
            if (stock.ColorEnglish.ToLower().IndexOf("sapphire") >= 0) return "sapphire";
            if (stock.ColorEnglish.ToLower().IndexOf("natural") >= 0) return "natural";
            if (stock.ColorEnglish.ToLower().IndexOf("tangerine") >= 0) return "tangerine";
            if (stock.ColorEnglish.ToLower().IndexOf("olive") >= 0) return "olive";
            if (stock.ColorEnglish.ToLower().IndexOf("iris") >= 0) return "iris";
            if (stock.ColorEnglish.ToLower().IndexOf("prairie dust") >= 0) return "prairie dust";
            if (stock.ColorEnglish.ToLower().IndexOf("blue dusk") >= 0) return "blue dusk";
            if (stock.ColorEnglish.ToLower().IndexOf("metro blue") >= 0) return "metro blue";
            if (stock.ColorEnglish.ToLower().IndexOf("tan") >= 0) return "tan";
            if (stock.ColorEnglish.ToLower().IndexOf("daisy") >= 0) return "daisy";
            if (stock.ColorEnglish.ToLower().IndexOf("heather navy") >= 0) return "heather navy";
            if (stock.ColorEnglish.ToLower().IndexOf("heather indigo") >= 0) return "heather indigo";
            if (stock.ColorEnglish.ToLower().IndexOf("sky") >= 0) return "sky";
            if (stock.ColorEnglish.ToLower().IndexOf("honey") >= 0) return "honey";
            if (stock.ColorEnglish.ToLower().IndexOf("orchid") >= 0) return "orchid";
            if (stock.ColorEnglish.ToLower().IndexOf("antique royal") >= 0) return "antique royal";
            if (stock.ColorEnglish.ToLower().IndexOf("safety pink") >= 0) return "safety pink";
            if (stock.ColorEnglish.ToLower().IndexOf("mint green") >= 0) return "mint green";
            if (stock.ColorEnglish.ToLower().IndexOf("pistachio") >= 0) return "pistachio";
            if (stock.ColorEnglish.ToLower().IndexOf("heather blue") >= 0) return "heather blue";
            if (stock.ColorEnglish.ToLower().IndexOf("heather charcoal") >= 0) return "heather charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("heather brown") >= 0) return "heather brown";
            if (stock.ColorEnglish.ToLower().IndexOf("heather green") >= 0) return "heather green";
            if (stock.ColorEnglish.ToLower().IndexOf("heather red") >= 0) return "heather red";
            if (stock.ColorEnglish.ToLower().IndexOf("heather orange") >= 0) return "heather orange";
            if (stock.ColorEnglish.ToLower().IndexOf("heather purple") >= 0) return "heather purple";
            if (stock.ColorEnglish.ToLower().IndexOf("heather fuchsia") >= 0) return "heather fuchsia";
            if (stock.ColorEnglish.ToLower().IndexOf("heather graphite") >= 0) return "heather graphite";
            if (stock.ColorEnglish.ToLower().IndexOf("pewter grey") >= 0) return "pewter grey";
            if (stock.ColorEnglish.ToLower().IndexOf("stadium green") >= 0) return "stadium green";
            if (stock.ColorEnglish.ToLower().IndexOf("valor blue") >= 0) return "valor blue";
            if (stock.ColorEnglish.ToLower().IndexOf("varsity purple") >= 0) return "varsity purple";
            if (stock.ColorEnglish.ToLower().IndexOf("perfect pink") >= 0) return "perfect pink";
            if (stock.ColorEnglish.ToLower().IndexOf("team maroon") >= 0) return "team maroon";
            if (stock.ColorEnglish.ToLower().IndexOf("university red") >= 0) return "university red";
            if (stock.ColorEnglish.ToLower().IndexOf("team orange") >= 0) return "team orange";
            if (stock.ColorEnglish.ToLower().IndexOf("chlorine blue") >= 0) return "chlorine blue";
            if (stock.ColorEnglish.ToLower().IndexOf("city green") >= 0) return "city green";
            if (stock.ColorEnglish.ToLower().IndexOf("chocolate") >= 0) return "chocolate";
            if (stock.ColorEnglish.ToLower().IndexOf("green apple") >= 0) return "green apple";
            if (stock.ColorEnglish.ToLower().IndexOf("river blue") >= 0) return "river blue";
            if (stock.ColorEnglish.ToLower().IndexOf("marbled charcoal") >= 0) return "marbled charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("marbled galapagos") >= 0) return "marbled galapagos";
            if (stock.ColorEnglish.ToLower().IndexOf("marbled heliconia") >= 0) return "marbled heliconia";
            if (stock.ColorEnglish.ToLower().IndexOf("marbled royal") >= 0) return "marbled royal";
            if (stock.ColorEnglish.ToLower().IndexOf("eco white") >= 0) return "eco white";
            if (stock.ColorEnglish.ToLower().IndexOf("independence red") >= 0) return "independence red";
            if (stock.ColorEnglish.ToLower().IndexOf("marron") >= 0) return "marron";
            if (stock.ColorEnglish.ToLower().IndexOf("yellow") >= 0) return "yellow";
            if (stock.ColorEnglish.ToLower().IndexOf("gravel") >= 0) return "gravel";
            if (stock.ColorEnglish.ToLower().IndexOf("azelea") >= 0) return "azelea";
            if (stock.ColorEnglish.ToLower().IndexOf("vivid lime") >= 0) return "vivid lime";
            if (stock.ColorEnglish.ToLower().IndexOf("uniform black") >= 0) return "uniform black";
            if (stock.ColorEnglish.ToLower().IndexOf("red violet") >= 0) return "red violet";
            if (stock.ColorEnglish.ToLower().IndexOf("tenesse orange") >= 0) return "tenesse orange";
            if (stock.ColorEnglish.ToLower().IndexOf("ant.cherry red") >= 0) return "ant.cherry red";
            if (stock.ColorEnglish.ToLower().IndexOf("antique irish green") >= 0) return "antique irish green";
            if (stock.ColorEnglish.ToLower().IndexOf("antique orange") >= 0) return "antique orange";
            if (stock.ColorEnglish.ToLower().IndexOf("berry") >= 0) return "berry";
            if (stock.ColorEnglish.ToLower().IndexOf("electric green") >= 0) return "electric green";
            if (stock.ColorEnglish.ToLower().IndexOf("violet") >= 0) return "violet";
            if (stock.ColorEnglish.ToLower().IndexOf("heather sapphire") >= 0) return "heather sapphire";
            if (stock.ColorEnglish.ToLower().IndexOf("antique cherry") >= 0) return "antique cherry";
            if (stock.ColorEnglish.ToLower().IndexOf("coral silk") >= 0) return "coral silk";
            if (stock.ColorEnglish.ToLower().IndexOf("university blue") >= 0) return "university blue";
            if (stock.ColorEnglish.ToLower().IndexOf("college navy") >= 0) return "college navy";
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
            if (stock.ColorEnglish.ToLower().IndexOf("white/navy") >= 0) return "white/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("white/black") >= 0) return "white/black";
            if (stock.ColorEnglish.ToLower().IndexOf("white/red") >= 0) return "white/red";
            if (stock.ColorEnglish.ToLower().IndexOf("white/royal") >= 0) return "white/royal";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/royal") >= 0) return "sport grey/royal";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/navy") >= 0) return "sport grey/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/red") >= 0) return "sport grey/red";
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
            if (stock.ColorEnglish.ToLower().IndexOf("dark navy") >= 0) return "dark navy";
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
            if (stock.ColorEnglish.ToLower().IndexOf("navy / charcoal") >= 0) return "navy / charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("black / charcoal") >= 0) return "black / charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal / charcoal") >= 0) return "charcoal / charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey / charcoal") >= 0) return "sport grey / charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("camouflage green") >= 0) return "camouflage green";
            if (stock.ColorEnglish.ToLower().IndexOf("camouflage sand") >= 0) return "camouflage sand";
            if (stock.ColorEnglish.ToLower().IndexOf("storm grey") >= 0) return "storm grey";
            if (stock.ColorEnglish.ToLower().IndexOf("silver") >= 0) return "silver";
            if (stock.ColorEnglish.ToLower().IndexOf("smoke") >= 0) return "smoke";
            if (stock.ColorEnglish.ToLower().IndexOf("independent red/navy") >= 0) return "independent red/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("white/heather grey") >= 0) return "white/heather grey";
            if (stock.ColorEnglish.ToLower().IndexOf("caribbean bl/h.grey") >= 0) return "caribbean bl/h.grey";
            if (stock.ColorEnglish.ToLower().IndexOf("heather dark grey/dkgrey") >= 0) return "heather dark grey/dkgrey";
            if (stock.ColorEnglish.ToLower().IndexOf("black/gold") >= 0) return "black/gold";
            if (stock.ColorEnglish.ToLower().IndexOf("black/orange") >= 0) return "black/orange";
            if (stock.ColorEnglish.ToLower().IndexOf("brown/khaki") >= 0) return "brown/khaki";
            if (stock.ColorEnglish.ToLower().IndexOf("khaki/black") >= 0) return "khaki/black";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/white") >= 0) return "navy/white";
            if (stock.ColorEnglish.ToLower().IndexOf("red/black") >= 0) return "red/black";
            if (stock.ColorEnglish.ToLower().IndexOf("royal/white") >= 0) return "royal/white";
            if (stock.ColorEnglish.ToLower().IndexOf("forest/gold") >= 0) return "forest/gold";
            if (stock.ColorEnglish.ToLower().IndexOf("forest/white") >= 0) return "forest/white";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/gray") >= 0) return "navy/gray";
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
            if (stock.ColorEnglish.ToLower().IndexOf("heather blue/navy") >= 0) return "heather blue/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("heather green/forest") >= 0) return "heather green/forest";
            if (stock.ColorEnglish.ToLower().IndexOf("heather brown/brown") >= 0) return "heather brown/brown";
            if (stock.ColorEnglish.ToLower().IndexOf("white/asphalt") >= 0) return "white/asphalt";
            if (stock.ColorEnglish.ToLower().IndexOf("white/true royal") >= 0) return "white/true royal";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather/bk") >= 0) return "deep heather/bk";
            if (stock.ColorEnglish.ToLower().IndexOf("blue triblend") >= 0) return "blue triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal triblend") >= 0) return "charcoal triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("grey triblend") >= 0) return "grey triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("light red triblend") >= 0) return "light red triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("navy triblend") >= 0) return "navy triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("white fleck triblend") >= 0) return "white fleck triblend";
            if (stock.ColorEnglish.ToLower().IndexOf("black/grey") >= 0) return "black/grey";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/grey") >= 0) return "navy/grey";
            if (stock.ColorEnglish.ToLower().IndexOf("granite/black") >= 0) return "granite/black";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather/dk grey") >= 0) return "deep heather/dk grey";
            if (stock.ColorEnglish.ToLower().IndexOf("asphalt") >= 0) return "asphalt";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal marble") >= 0) return "charcoal marble";
            if (stock.ColorEnglish.ToLower().IndexOf("navy marble") >= 0) return "navy marble";
            if (stock.ColorEnglish.ToLower().IndexOf("white marble") >= 0) return "white marble";
            if (stock.ColorEnglish.ToLower().IndexOf("black marble") >= 0) return "black marble";
            if (stock.ColorEnglish.ToLower().IndexOf("true royal marble") >= 0) return "true royal marble";
            if (stock.ColorEnglish.ToLower().IndexOf("d.grey heather/bk") >= 0) return "d.grey heather/bk";
            if (stock.ColorEnglish.ToLower().IndexOf("digital black") >= 0) return "digital black";
            if (stock.ColorEnglish.ToLower().IndexOf("digital grey") >= 0) return "digital grey";
            if (stock.ColorEnglish.ToLower().IndexOf("digital blue") >= 0) return "digital blue";
            if (stock.ColorEnglish.ToLower().IndexOf("deep heather/navy") >= 0) return "deep heather/navy";
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
            if (stock.ColorEnglish.ToLower().IndexOf("midnight navy/white") >= 0) return "midnight navy/white";
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
            if (stock.ColorEnglish.ToLower().IndexOf("red/navy") >= 0) return "red/navy";
            if (stock.ColorEnglish.ToLower().IndexOf("black/lt.stone") >= 0) return "black/lt.stone";
            if (stock.ColorEnglish.ToLower().IndexOf("brown/lt.stone") >= 0) return "brown/lt.stone";
            if (stock.ColorEnglish.ToLower().IndexOf("loden/gr.stone") >= 0) return "loden/gr.stone";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/lt.stone") >= 0) return "navy/lt.stone";
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
            if (stock.ColorEnglish.ToLower().IndexOf("natural navy") >= 0) return "natural navy";
            if (stock.ColorEnglish.ToLower().IndexOf("natural sky blue") >= 0) return "natural sky blue";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/flamingo") >= 0) return "navy/flamingo";
            if (stock.ColorEnglish.ToLower().IndexOf("red black") >= 0) return "red black";
            if (stock.ColorEnglish.ToLower().IndexOf("flamingo") >= 0) return "flamingo";
            if (stock.ColorEnglish.ToLower().IndexOf("skyblue") >= 0) return "skyblue";
            if (stock.ColorEnglish.ToLower().IndexOf("max") >= 0) return "max";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal mix") >= 0) return "charcoal mix";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey /black") >= 0) return "sport grey /black";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/forest green") >= 0) return "sport grey/forest green";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/purple") >= 0) return "sport grey/purple";
            if (stock.ColorEnglish.ToLower().IndexOf("sport grey/royal blue") >= 0) return "sport grey/royal blue";
            if (stock.ColorEnglish.ToLower().IndexOf("black/charcoal") >= 0) return "black/charcoal";
            if (stock.ColorEnglish.ToLower().IndexOf("black/kelly") >= 0) return "black/kelly";
            if (stock.ColorEnglish.ToLower().IndexOf("charcoal/red") >= 0) return "charcoal/red";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/light blue") >= 0) return "navy/light blue";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/red") >= 0) return "navy/red";
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
            if (stock.ColorEnglish.ToLower().IndexOf("navy/columbia") >= 0) return "navy/columbia";
            if (stock.ColorEnglish.ToLower().IndexOf("navy/orange") >= 0) return "navy/orange";
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
            if (stock.ColorEnglish.ToLower().IndexOf("navy blue") >= 0) return "navy blue";
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
            if (stock.ColorEnglish.ToLower().IndexOf("khaki/navy") >= 0) return "khaki/navy";
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

    public class Couleur
    {
        public string Anglais { get; set; }
        public string Francais { get; set; }
        public string EquivalentWeb { get; set; }
    }

}
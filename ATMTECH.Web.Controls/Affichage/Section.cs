using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Contrôle qui permet d'afficher une entête section et un
    /// contenu qui peut être agrandi ou rapetissé.
    /// </summary>
    /// <code><![CDATA[
    /// Exemples d'utilisation:
    /// 
    ///<ATMTECH:Section runat="server" Libelle="Une section">
    ///   <div>Le contenu!</div>
    ///</ATMTECH:Section>
    /// ]]></code>
    [PersistChildren(true)]
    [ParseChildren(false)]
    [Designer(typeof(ContainerControlDesigner))]
    public class Section : ControleBase
    {
        private readonly List<Control> _contenu = new List<Control>();
        private HtmlGenericControl _contenant;
        private HtmlInputHidden _etat;
        private Image _bouton;
        private Label _lblTitre;
        private string _libelle = String.Empty;

        /// <summary>
        /// Le contenu du libellé
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Le contenu du libellé.")]
        public string Libelle
        {
            get { return _libelle; }
            set
            {
                _libelle = value;
                if (_lblTitre != null)
                {
                    _lblTitre.Text = _libelle;
                }
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public Section()
            : base(false)
        {
        }

        private bool _estOuvert;

        /// <summary>
        /// Si vrai, le contenu de la section est ouverte
        /// </summary>
        [CategoryAttribute("Appearance")]
        [Description("Indique si la section est ouverte.")]
        public bool EstOuvert
        {
            get { return _etat == null ? _estOuvert : _etat.Value == "1"; }
            set
            {
                _estOuvert = value;
                if (_etat != null)
                    _etat.Value = _estOuvert ? "1" : "0";
            }
        }

        // Pas de balises entourant ce contrôle
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }
        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        /// <summary>
        /// Appelé par l'infrastructure de page ASP.NET pour avertir les contrôles serveur qui utilisent une implémentation basée sur la composition qu'ils doivent créer tous les contrôles enfants qu'ils contiennent en préparation de la publication ou du rendu.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            CreerEntete();
            CreerContenu();
        }

        /// <summary>
        /// Cette méthode est appelée par ASP.NET pour chaque
        /// contrôle enfant. On doit donc les garder dans une
        /// liste pour pouvoir générer le contenu.
        /// </summary>
        protected override void AddParsedSubObject(object obj)
        {
            _contenu.Add((Control)obj);
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.Init"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnInit(EventArgs e)
        {
            EnsureChildControls();
            base.OnInit(e);
        }

        /// <summary>
        /// Déclenche l'événement <see cref="E:System.Web.UI.Control.PreRender"/>.
        /// </summary>
        /// <param name="e">Objet <see cref="T:System.EventArgs"/> qui contient les données d'événement.</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Page.InclureRessourceJavascript("Affichage.Section.js");
            CreerJavaScriptImages();

            AjusteImageBoutonSelonEtat();
            if (!string.IsNullOrEmpty(CssClass))
            {
                _contenant.Attributes["class"] = CssClass;
            }
        }

        private void AjusteImageBoutonSelonEtat()
        {
            if (EstOuvert)
            {
                _contenant.Style.Add(HtmlTextWriterStyle.Display, "block");
                _bouton.ImageUrl = ObtenirUrlImageReduire();
                _bouton.AlternateText = "Réduire";
            }
            else
            {
                _contenant.Style.Add(HtmlTextWriterStyle.Display, "none");
                _bouton.ImageUrl = ObtenirUrlImageAgrandir();
                _bouton.AlternateText = "Agrandir";
            }
        }

        private string ObtenirUrlImageReduire()
        {
            return Page.GetResourceUrl("Affichage.reduire.png");
        }

        private string ObtenirUrlImageAgrandir()
        {
            return Page.GetResourceUrl("Affichage.agrandir.png");
        }

        private void CreerJavaScriptImages()
        {
            string js = "$.extend($.ATMTECH, {" +
                        "imgSctAgrandir: '" + ObtenirUrlImageAgrandir() + "'," +
                        "imgSctReduire: '" + ObtenirUrlImageReduire() + "'" +
                        "});";
            Page.IncorporerJavascript("SectionImgs", js);
        }

        private void CreerEntete()
        {
            HtmlGenericControl cadre = new HtmlGenericControl("div");
            cadre.Attributes.Add("class", "section");

            CreerBouton(cadre);
            CreerLibelle(cadre);
            CreerInputHiddenEtat(cadre);

            Controls.Add(cadre);
        }

        private void CreerContenu()
        {
            _contenant = new HtmlGenericControl("div");
            _contenu.ForEach(c => _contenant.Controls.Add(c));
            Controls.Add(_contenant);
        }

        /// <summary>
        /// L'état (ouvert/fermé) doit être persisté au post-back.
        /// Le JavaScript regarde donc le contenu de ce input hidden.
        /// </summary>
        private void CreerInputHiddenEtat(Control cadre)
        {
            _etat = new HtmlInputHidden();
            _etat.Value = _estOuvert ? "1" : "0";
            cadre.Controls.Add(_etat);
        }

        private void CreerLibelle(Control cadre)
        {
            _lblTitre = new Label { Text = Libelle };
            cadre.Controls.Add(_lblTitre);
        }

        private void CreerBouton(Control cadre)
        {
            _bouton = new Image();
            cadre.Controls.Add(_bouton);
        }
    }
}
using System;
using System.Web.UI.WebControls;
using ATMTECH.Web.Controls.Base;
using ATMTECH.Web.Controls.Edition;

// Contient le code qui gère les événements des contrôles enfants

namespace ATMTECH.Web.Controls.Grille
{
    /// <summary>
    /// 
    /// </summary>
    public partial class GrilleAvance
    {
        private void AttacherEvenements()
        {
            AttacherEvenementDataSourceGrille();
            AttacherEvenementDataSourceDetail();
            AttacherEvenementGrille();
            AttacherEvenementDetail();
            AttacherEvenementFenetre();
        }

        /// <summary>
        /// Événements du DataSourceObject lié à la GridView
        /// </summary>
        private void AttacherEvenementDataSourceGrille()
        {
            _objectDataSource.Deleted += OnDeleted;
            _objectDataSource.Deleting += OnDeleting;
            _objectDataSource.Filtering += OnFiltering;
            _objectDataSource.Inserted += OnInserted;
            _objectDataSource.Inserting += OnInserting;
            _objectDataSource.ObjectCreated += OnObjectCreated;
            _objectDataSource.ObjectCreating += OnObjectCreating;
            _objectDataSource.ObjectDisposing += OnObjectDisposing;
            _objectDataSource.Selected += OnSelected;
            _objectDataSource.Selecting += OnSelecting;
            _objectDataSource.Updated += OnUpdated;
            _objectDataSource.Updating += OnUpdating;
        }

        /// <summary>
        /// Événements du DataSourceObject lié au FormView
        /// </summary>
        private void AttacherEvenementDataSourceDetail()
        {
            _objectDataSourceDetail.Deleted += OnDetailDeleted;
            _objectDataSourceDetail.Deleting += OnDetailDeleting;
            _objectDataSourceDetail.Filtering += OnDetailFiltering;
            _objectDataSourceDetail.Inserted += OnDetailInserted;
            _objectDataSourceDetail.Inserting += OnDetailInserting;
            _objectDataSourceDetail.ObjectCreated += OnDetailObjectCreated;
            _objectDataSourceDetail.ObjectCreating += OnDetailObjectCreating;
            _objectDataSourceDetail.ObjectDisposing += OnDetailObjectDisposing;
            _objectDataSourceDetail.Selected += OnDetailSelected;
            _objectDataSourceDetail.Selecting += OnDetailSelecting;
            _objectDataSourceDetail.Updated += OnDetailUpdated;
            _objectDataSourceDetail.Updating += OnDetailUpdating;
        }

        /// <summary>
        /// Événements de la GridView
        /// </summary>
        private void AttacherEvenementGrille()
        {
            _grille.PageIndexChanged += OnPageIndexChanged;
            _grille.PageIndexChanging += OnPageIndexChanging;
            _grille.RowCancelingEdit += OnRowCancelingEdit;
            _grille.RowCommand += OnRowCommand;
            _grille.RowCreated += OnRowCreated;
            _grille.RowDataBound += OnRowDataBound;
            _grille.DataBinding += OnDataBinding;
            _grille.DataBound += OnDataBound;
            _grille.RowDeleted += OnRowDeleted;
            _grille.RowDeleting += OnRowDeleting;
            _grille.RowEditing += OnRowEditing;
            _grille.RowUpdated += OnRowUpdated;
            _grille.RowUpdating += OnRowUpdating;
            //_grille.SelectedIndexChanged += OnSelectedIndexChanged;
            _grille.Sorted += OnSorted;
            _grille.Sorting += OnSorting;
        }

        /// <summary>
        /// Événements du FormView
        /// </summary>
        private void AttacherEvenementDetail()
        {
            _detail.ItemCommand += OnDetailFormItemCommand;
            _detail.ItemInserting += OnDetailFormItemInserting;
            _detail.ItemInserted += OnDetailFormItemInserted;
            _detail.ItemUpdated += OnDetailFormItemUpdated;
        }

        /// <summary>
        /// Événements de FenetreDialogue
        /// </summary>
        private void AttacherEvenementFenetre()
        {
            _fenetreEdition.Fermer += OnFenetreEditionClosed;
        }

        #region Gestionnaires d'événements du DataSource de la grille
        // ====================================================================

        private void OnDeleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            OnDeleted(e);
        }

        private void OnDeleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            OnDeleting(e);
        }

        private void OnFiltering(object sender, ObjectDataSourceFilteringEventArgs e)
        {
            OnFiltering(e);
        }

        private void OnInserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            OnInserted(e);
        }

        private void OnInserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            OnInserting(e);
        }

        private void OnObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            object presenter = Parent.ObtenirPresenter();

            if (presenter != null)
                e.ObjectInstance = presenter;

            OnObjectCreated(e);
        }

        private void OnObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            object presenter = Parent.ObtenirPresenter();

            if (presenter != null)
                e.ObjectInstance = presenter;

            OnObjectCreating(e);
        }

        private void OnObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
        {
            OnObjectDisposing(e);
        }

        private bool _estSelectionCount;
        
        private void OnSelected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (_estSelectionCount)
            {
                NombreResultats = (int) (e.ReturnValue is int ? e.ReturnValue : 0);
            }
            OnSelected(e);
        }

        private void OnSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            _estSelectionCount = e.ExecutingSelectCount;
            if (_aRecupereParametre)
            {
                CorroborerArgumentDataSource(e);
            }

            //Si EstAutomatiquementLie est false, on ne doit pas exécuter le Select.
            if (EstAutomatiquementLie)
            {
                OnSelecting(e);
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void OnUpdated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            OnUpdated(e);
        }

        private void OnUpdating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            OnUpdating(e);
        }

        // ====================================================================
        #endregion

        #region Gestionnaires d'événements du DataSource du FormView (DetailGrille)
        // ====================================================================

        private void OnDetailDeleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            OnDeleted(e);
        }

        private void OnDetailDeleting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            OnDeleting(e);
        }

        private void OnDetailFiltering(object sender, ObjectDataSourceFilteringEventArgs e)
        {
            OnFiltering(e);
        }

        private void OnDetailInserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Page.IsValid)
            {
                if (EstFenetreDialogue)
                {
                    _fenetreEdition.FermerFenetre();
                }
                OnInserted(e);
                _grille.DataBind();
            }
            else
            {
                _annulerModif = true;
            }
        }

        private void OnDetailInserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            OnInserting(e);
        }

        private void OnDetailObjectCreated(object sender, ObjectDataSourceEventArgs e)
        {
            object presenter = Parent.ObtenirPresenter();

            if (presenter != null)
                e.ObjectInstance = presenter;

            OnObjectCreated(e);
        }

        private void OnDetailObjectCreating(object sender, ObjectDataSourceEventArgs e)
        {
            object presenter = Parent.ObtenirPresenter();

            if (presenter != null)
                e.ObjectInstance = presenter;

            OnObjectCreating(e);
        }

        private void OnDetailObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
        {
            OnObjectDisposing(e);
        }

        private void OnDetailSelected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            OnDetailSelected(e);
        }

        private void OnDetailSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

            if (!string.IsNullOrEmpty(ObjectDatasource.MaximumRowsParameterName) && EstPermiPagination)
            {
                //Ajouter le paramètre MaximumRow avec comme valeur le nombre d'élément
                //afficher de la grille.
                e.InputParameters.Add(
                    ObjectDatasource.MaximumRowsParameterName, Grille.PageSize);
            }
            //Vérifier si l'argument index de départ est présent dans le datasource de la grille
            if (!string.IsNullOrEmpty(ObjectDatasource.StartRowIndexParameterName) && EstPermiPagination)
            {
                //Ajouter le paramètre StartRowIndex avec comme valeur le résultat
                //de la fonction CalculerIndexLigneGrille().
                e.InputParameters.Add(
                    ObjectDatasource.StartRowIndexParameterName, CalculerIndexLigneGrille());
            }
            //Vérifier si l'argument de tri est présent dans le datasource de la grille
            if (!string.IsNullOrEmpty(ObjectDatasource.SortParameterName) && EstPermiTri)
            {
                string sortExpression = _grille.SortExpression;

                if (Grille.SortDirection == SortDirection.Descending)
                    sortExpression += " DESC";
                //Ajouter le paramètre Sort avec comme valeur le nom de la 
                //colonne trié par la grille.
                e.InputParameters.Add(
                    ObjectDatasource.SortParameterName, sortExpression);
            }

            //Envoi l'évênement à la page.
            OnDetailSelecting(e);
        }

        private void OnDetailUpdated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (Page.IsValid)
            {
                if (EstFenetreDialogue)
                {
                    _fenetreEdition.FermerFenetre();
                }
                OnUpdated(e);
                _grille.DataBind();
            }
            else
            {
                _annulerModif = true;
            }
        }

        private void OnDetailUpdating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            OnUpdating(e);
            _annulerModif = e.Cancel;
        }

        // ====================================================================
        #endregion

        #region Gestionnaires d'événements du GridView
        // ====================================================================

        private void OnPageIndexChanged(object sender, EventArgs e)
        {
            OnPageIndexChanged(e);
            RaiseBubbleEvent(this, e);
        }

        private void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Si le Champ Selection est présent, on doit sauvegarder l'état 
            // de la sélection avant de changer de page.
            if (VerifierPresenceChampSelection())
            {
                PersisterEntiteSelectionneAvantPaging();
            }
            OnPageIndexChanging(e);
            RaiseBubbleEvent(this, e);
        }

        private void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            OnRowCancelingEdit(e);
            RaiseBubbleEvent(this, e);
        }


        /// <summary>
        /// Méthode appellée quand une commande est envoyée à une rangée.
        /// </summary>
        /// <param name="sender">L'objet ayant initialisé la commande.</param>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs"/> contenant les données de l'évènement.</param>
        private void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (EstGereBeforeRowCommand())
            {
                OnBeforeRowCommand(e);
                if (!EstPageValide()) return;
            }

            switch (e.CommandName)
            {
                case CONSULTER_BOUTON_COMMAND:
                    {
                        int index = int.Parse(e.CommandArgument.ToString());

                        if (!string.IsNullOrEmpty(ConsulterMethode))
                        {
                            AppelerMethodePourEntite(ConsulterMethode, index);
                        }
                        else
                        {
                            object entite = RecupererEntiteLigneSelectionnee(index);
                            EntiteSelectionneEtPersistes.Clear();
                            EntiteSelectionneEtPersistes.Add(entite);
                        }
                    }
                    break;
                case AJOUTER_BOUTON_COMMAND:
                    if (EstFenetreDialogue)
                    {
                        _detail.EntrerModeAjout();
                        _fenetreEdition.OuvrirFenetre(_detail.TitreInsertion);
                        if (!_detail.EstAvecAutoComplete)
                            _udpDetail.Update();
                    }
                    else if (!string.IsNullOrEmpty(AjouterMethode))
                    {
                        if (EstMaitreDetail)
                        {
                            EffacerSelection(false);
                        }
                        AppelerMethodeAjouter();
                    }
                    break;
            }

            OnRowCommand(e);
            RaiseBubbleEvent(this, e);
        }

        private bool EstPageValide()
        {
            Page.Validate("GrilleAvance-Bidon");
            return Page.IsValid;
        }

        private void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header && EstPermiTri)
            {
                IndiquerColonneDeTri(e);
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RenseignerCommandArgument(e.Row);
            }
            OnRowCreated(e);
        }

        private bool _rowDataBinding;

        private void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            _rowDataBinding = true;
            //Ajout des tooltips si ligne d'entête.
            if (e.Row.RowType == DataControlRowType.Header)
            {
                CreerTooltipEntete(e);
            }
            //Cocher le ChampSelection, si besoin.
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (VerifierPresenceChampSelection())
                {
                    CocherChampSelection(e.Row);
                }
                if (EstMaitreDetail || EstRangeeCliquable)
                {
                    e.Row.Attributes["id"] = e.Row.UniqueID;
                }
            }
            OnRowDataBound(e);
        }

        private void OnDataBinding(object sender, EventArgs e)
        {
            OnDataBinding(e);
        }

        private void OnDataBound(object sender, EventArgs e)
        {
            _rowDataBinding = false;
            GridViewRow pager = _grille.BottomPagerRow;
            if (AfficherNombreResultats && pager != null && !pager.Visible)
            {
                // Afficher la barre de pagination pour que le nombre de résultats soit visible.
                pager.Visible = true;
            }
            OnDataBound(e);
            if (EstMaitreDetail)
                SelectionnerValeur();
        }

        private void OnRowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (EstMaitreDetail && EstPageValide())
            {
                EffacerSelection();
            }
            OnRowDeleted(e);
            RaiseBubbleEvent(this, e);
            if (_grille.Rows.Count <= 1 && _grille.PageIndex > 0)
            {
                _grille.PageIndex--;
            }
        }

        private void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            OnRowDeleting(e);
            RaiseBubbleEvent(this, e);
        }

        private void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            if (EstFenetreDialogue)
            {
                _detail.EntrerModeEdition(e.NewEditIndex);    
                _fenetreEdition.OuvrirFenetre(_detail.TitreModification);
                if(!_detail.EstAvecAutoComplete)
                    _udpDetail.Update();
            }
            else if (!string.IsNullOrEmpty(ModifierMethode))
            {
                AppelerMethodePourEntite(ModifierMethode, e.NewEditIndex);
            }
            e.Cancel = true; //Hack pour eviter l'édition dans la grille.
            OnRowEditing(e);
            RaiseBubbleEvent(this, e);
        }

        private void OnRowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            OnRowUpdated(e);
            RaiseBubbleEvent(this, e);
        }

        private void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OnRowUpdating(e);
            RaiseBubbleEvent(this, e);
        }

        [Obsolete]
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            AppelerMethodeSelectionner();
        }

        private void OnSorted(object sender, EventArgs e)
        {
            OnSorted(e);
            RaiseBubbleEvent(this, e);
        }

        private void OnSorting(object sender, GridViewSortEventArgs e)
        {
            //Si le Champ Selection est présent, on doit sauvegarder l'état 
            // de la sélection avant de changer de page.
            if (VerifierPresenceChampSelection())
            {
                PersisterEntiteSelectionneAvantPaging();
            }
            OnSorting(e);
            RaiseBubbleEvent(this, e);
        }

        // ====================================================================
        #endregion

        #region Gestionnaires d'événements du FormView (DetailGrille)
        // ====================================================================

        private void OnDetailFormItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case BoutonAnnuler.NOM_COMMANDE:
                    if (EstFenetreDialogue)
                    {
                        _fenetreEdition.FermerFenetre();
                        OnFenetreEditionClosed(sender, e);
                    }
                    break;
                case BoutonReinitialiser.NOM_COMMANDE:
                    FormViewMode mode = _detail.CurrentMode;
                    _detail.RetournerModeParDefaut();
                    _detail.ChangeMode(mode);
                    break;
            }
        }

        private void OnDetailFormItemInserting(object sender, FormViewInsertEventArgs e)
        {
            // En mode insertion, on assigne une valeur par défaut à la clé primaire,
            // si aucune valeur n'est déjà "bindée". Cela permet de faire un binding
            // "costum" dans notre Presenter. Autrement, le FormView plantera sur l'insertion
            // avec un message "ObjectDataSource ... has no value to insert".
            if (e.Values.Count == 0)
            {
                e.Values.Add(DataKeyNames[0], null);
            }
        }

        private void OnDetailFormItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            // Permet de conserver les valeurs dans le viewstate si l'insertion
            // a été annulée sur OnInserting
            e.KeepInInsertMode = _annulerModif;
            _detail.AnnulerModification = _annulerModif;
        }

        private void OnDetailFormItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            // Permet de conserver les valeurs dans le viewstate si la modification
            // a été annulée sur OnInserting
            e.KeepInEditMode = _annulerModif;
            _detail.AnnulerModification = _annulerModif;
        }

        // ====================================================================
        #endregion

        #region Gestionnaires d'événements de FenetreDialogue
        // ====================================================================

        private void OnFenetreEditionClosed(object sender, EventArgs e)
        {
            _detail.RetournerModeParDefaut();
            OnFenetreEditionClosed(e);
        }

        // ====================================================================
        #endregion

    }
}

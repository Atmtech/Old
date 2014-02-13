using System;
using System.Web.UI.WebControls;

// Contient le code nécessaire à l'appel des événements liés au contrôle

namespace ATMTECH.Web.Controls.Grille
{
    public partial class GrilleAvance
    {
        /// <summary>
        /// 
        /// </summary>
        public GrilleAvance( )
            : base(false)
        {
            _grillePageIndexChanged = new object();
            _grillePageIndexChanging = new object();
            _grilleRowCancelingEdit = new object();
            _grilleBeforeRowCommand = new object();
            _grilleRowCommand = new object();
            _grilleRowCreated = new object();
            _grilleRowDatabound = new object();
            _grilleRowDeleted = new object();
            _grilleRowDeleting = new object();
            _grilleRowEditing = new object();
            _grilleRowUpdated = new object();
            _grilleRowUpdating = new object();
            _grilleSorted = new object();
            _grilleSorting = new object();
            _grilleDataBinding = new object();
            _grilleDataBound = new object();
            _dataSourceDeleted = new object();
            _dataSourceDeleting = new object();
            _dataSourceFiltering = new object();
            _dataSourceInserted = new object();
            _dataSourceInserting = new object();
            _dataSourceObjectCreated = new object();
            _dataSourceObjectCreating = new object();
            _dataSourceObjectDisposing = new object();
            _dataSourceSelected = new object();
            _dataSourceSelecting = new object();
            _dataSourceUpdated = new object();
            _dataSourceUpdating = new object();
            _detailDataSourceSelected = new object();
            _detailDataSourceSelecting = new object();
            _fenetreEditionClosed = new object();
        }

        private readonly object _grillePageIndexChanged;
        private readonly object _grillePageIndexChanging;
        private readonly object _grilleRowCancelingEdit;
        private readonly object _grilleBeforeRowCommand;
        private readonly object _grilleRowCommand;
        private readonly object _grilleRowCreated;
        private readonly object _grilleRowDatabound;
        private readonly object _grilleRowDeleted;
        private readonly object _grilleRowDeleting;
        private readonly object _grilleRowEditing;
        private readonly object _grilleRowUpdated;
        private readonly object _grilleRowUpdating;
        private readonly object _grilleSorted;
        private readonly object _grilleSorting;
        private readonly object _grilleDataBinding;
        private readonly object _grilleDataBound;
        private readonly object _dataSourceDeleted;
        private readonly object _dataSourceDeleting;
        private readonly object _dataSourceFiltering;
        private readonly object _dataSourceInserted;
        private readonly object _dataSourceInserting;
        private readonly object _dataSourceObjectCreated;
        private readonly object _dataSourceObjectCreating;
        private readonly object _dataSourceObjectDisposing;
        private readonly object _dataSourceSelected;
        private readonly object _dataSourceSelecting;
        private readonly object _dataSourceUpdated;
        private readonly object _dataSourceUpdating;
        private readonly object _detailDataSourceSelected;
        private readonly object _detailDataSourceSelecting;
        private readonly object _fenetreEditionClosed;

        #region Evénements relayés par la grille
        // --------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler PageIndexChanged
        {
            add { Events.AddHandler(_grillePageIndexChanged, value); }
            remove { Events.RemoveHandler(_grillePageIndexChanged, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewPageEventHandler PageIndexChanging
        {
            add { Events.AddHandler(_grillePageIndexChanging, value); }
            remove { Events.RemoveHandler(_grillePageIndexChanging, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewCancelEditEventHandler RowCancelingEdit
        {
            add { Events.AddHandler(_grilleRowCancelingEdit, value); }
            remove { Events.RemoveHandler(_grilleRowCancelingEdit, value); }
        }

        public event GridViewCommandEventHandler BeforeRowCommand
        {
            add { Events.AddHandler(_grilleBeforeRowCommand, value); }
            remove { Events.RemoveHandler(_grilleBeforeRowCommand, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewCommandEventHandler RowCommand
        {
            add { Events.AddHandler(_grilleRowCommand, value); }
            remove { Events.RemoveHandler(_grilleRowCommand, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewRowEventHandler RowCreated
        {
            add { Events.AddHandler(_grilleRowCreated, value); }
            remove { Events.RemoveHandler(_grilleRowCreated, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewRowEventHandler RowDatabound
        {
            add { Events.AddHandler(_grilleRowDatabound, value); }
            remove { Events.RemoveHandler(_grilleRowDatabound, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewDeletedEventHandler RowDeleted
        {
            add { Events.AddHandler(_grilleRowDeleted, value); }
            remove { Events.RemoveHandler(_grilleRowDeleted, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewDeleteEventHandler RowDeleting
        {
            add { Events.AddHandler(_grilleRowDeleting, value); }
            remove { Events.RemoveHandler(_grilleRowDeleting, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewEditEventHandler RowEditing
        {
            add { Events.AddHandler(_grilleRowEditing, value); }
            remove { Events.RemoveHandler(_grilleRowEditing, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewUpdatedEventHandler RowUpdated
        {
            add { Events.AddHandler(_grilleRowUpdated, value); }
            remove { Events.RemoveHandler(_grilleRowUpdated, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewUpdateEventHandler RowUpdating
        {
            add { Events.AddHandler(_grilleRowUpdating, value); }
            remove { Events.RemoveHandler(_grilleRowUpdating, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler Sorted
        {
            add { Events.AddHandler(_grilleSorted, value); }
            remove { Events.RemoveHandler(_grilleSorted, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event GridViewSortEventHandler Sorting
        {
            add { Events.AddHandler(_grilleSorting, value); }
            remove { Events.RemoveHandler(_grilleSorting, value); }
        }

        public new event EventHandler DataBinding
        {
            add { Events.AddHandler(_grilleDataBinding, value); }
            remove { Events.RemoveHandler(_grilleDataBinding, value); }
        }

        public event EventHandler DataBound
        {
            add { Events.AddHandler(_grilleDataBound, value); }
            remove { Events.RemoveHandler(_grilleDataBound, value); }
        }


        // --------------------------------------------------------------------
        #endregion

        #region Evénements relayés par les Datasource
        // --------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceStatusEventHandler Deleted
        {
            add { Events.AddHandler(_dataSourceDeleted, value); }
            remove { Events.RemoveHandler(_dataSourceDeleted, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceMethodEventHandler Deleting
        {
            add { Events.AddHandler(_dataSourceDeleting, value); }
            remove { Events.RemoveHandler(_dataSourceDeleting, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceFilteringEventHandler Filtering
        {
            add { Events.AddHandler(_dataSourceFiltering, value); }
            remove { Events.RemoveHandler(_dataSourceFiltering, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceStatusEventHandler Inserted
        {
            add { Events.AddHandler(_dataSourceInserted, value); }
            remove { Events.RemoveHandler(_dataSourceInserted, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceMethodEventHandler Inserting
        {
            add { Events.AddHandler(_dataSourceInserting, value); }
            remove { Events.RemoveHandler(_dataSourceInserting, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceObjectEventHandler ObjectCreated
        {
            add { Events.AddHandler(_dataSourceObjectCreated, value); }
            remove { Events.RemoveHandler(_dataSourceObjectCreated, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceObjectEventHandler ObjectCreating
        {
            add { Events.AddHandler(_dataSourceObjectCreating, value); }
            remove { Events.RemoveHandler(_dataSourceObjectCreating, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceDisposingEventHandler ObjectDisposing
        {
            add { Events.AddHandler(_dataSourceObjectDisposing, value); }
            remove { Events.RemoveHandler(_dataSourceObjectDisposing, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceStatusEventHandler Selected
        {
            add { Events.AddHandler(_dataSourceSelected, value); }
            remove { Events.RemoveHandler(_dataSourceSelected, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceSelectingEventHandler Selecting
        {
            add { Events.AddHandler(_dataSourceSelecting, value); }
            remove { Events.RemoveHandler(_dataSourceSelecting, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceStatusEventHandler Updated
        {
            add { Events.AddHandler(_dataSourceUpdated, value); }
            remove { Events.RemoveHandler(_dataSourceUpdated, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public event ObjectDataSourceMethodEventHandler Updating
        {
            add { Events.AddHandler(_dataSourceUpdating, value); }
            remove { Events.RemoveHandler(_dataSourceUpdating, value); }
        }

        /// <summary>
        /// Évênement Selected de l'objectDatasource qui gère la fenêtre de 
        /// modification.
        /// </summary>
        public event ObjectDataSourceStatusEventHandler DetailSelected
        {
            add { Events.AddHandler(_detailDataSourceSelected, value); }
            remove { Events.RemoveHandler(_detailDataSourceSelected, value); }
        }

        /// <summary>
        /// Évênement Selecting de l'objectDatasource qui gère la fenêtre de 
        /// modification.
        /// </summary>
        public event ObjectDataSourceSelectingEventHandler DetailSelecting
        {
            add { Events.AddHandler(_detailDataSourceSelecting, value); }
            remove { Events.RemoveHandler(_detailDataSourceSelecting, value); }
        }

        // --------------------------------------------------------------------
        #endregion

        #region Evénements relayés par la Fenêtre
        // --------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler FenetreEditionClosed
        {
            add { Events.AddHandler(_fenetreEditionClosed, value); }
            remove { Events.RemoveHandler(_fenetreEditionClosed, value); }
        }

        // --------------------------------------------------------------------
        #endregion

        #region Méthodes des événements relayés par la grille
        // ====================================================================

        /// <summary>
        /// Lève l'évènement <see cref="PageIndexChanged"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="EventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnPageIndexChanged(EventArgs e)
        {
            EventHandler eventHandler =
                (EventHandler)Events[_grillePageIndexChanged];
            if (eventHandler != null)
                eventHandler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="PageIndexChanging"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewPageEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            GridViewPageEventHandler handler =
                (GridViewPageEventHandler)Events[_grillePageIndexChanging];
            if (handler != null)
                handler(this, e);
        }
        /// <summary>
        /// Lève l'évènement <see cref="RowCancelingEdit"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewCancelEditEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowCancelingEdit(GridViewCancelEditEventArgs e)
        {
            GridViewCancelEditEventHandler handler =
                (GridViewCancelEditEventHandler)Events[_grilleRowCancelingEdit];
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnBeforeRowCommand(GridViewCommandEventArgs e)
        {
            GridViewCommandEventHandler handler = ObtenirHandlerBeforeRowCommand();
            if (handler != null)
                handler(this, e);
        }

        private bool EstGereBeforeRowCommand()
        {
            return ObtenirHandlerBeforeRowCommand() != null;
        }

        private GridViewCommandEventHandler ObtenirHandlerBeforeRowCommand()
        {
            GridViewCommandEventHandler handler =
                (GridViewCommandEventHandler) Events[_grilleBeforeRowCommand];
            return handler;
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowCommand"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewCommandEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowCommand(GridViewCommandEventArgs e)
        {
            GridViewCommandEventHandler handler =
                (GridViewCommandEventHandler)Events[_grilleRowCommand];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowCreated"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewRowEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowCreated(GridViewRowEventArgs e)
        {
            GridViewRowEventHandler gridViewRowEventHandler =
                (GridViewRowEventHandler)Events[_grilleRowCreated];
            if (gridViewRowEventHandler != null)
                gridViewRowEventHandler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowDatabound"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewRowEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowDataBound(GridViewRowEventArgs e)
        {
            GridViewRowEventHandler gridViewRowEventHandler =
                (GridViewRowEventHandler)Events[_grilleRowDatabound];
            if (gridViewRowEventHandler != null)
                gridViewRowEventHandler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowDeleted"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewDeletedEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowDeleted(GridViewDeletedEventArgs e)
        {
            GridViewDeletedEventHandler handler =
                (GridViewDeletedEventHandler)Events[_grilleRowDeleted];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowDeleting"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowDeleting(GridViewDeleteEventArgs e)
        {
            GridViewDeleteEventHandler handler =
                (GridViewDeleteEventHandler)Events[_grilleRowDeleting];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowEditing"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewEditEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowEditing(GridViewEditEventArgs e)
        {
            GridViewEditEventHandler handler =
                (GridViewEditEventHandler)Events[_grilleRowEditing];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowUpdated"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewUpdatedEventArgs"/> contenent les données de l'évènement.</param>
        protected virtual void OnRowUpdated(GridViewUpdatedEventArgs e)
        {
            GridViewUpdatedEventHandler handler =
                (GridViewUpdatedEventHandler)Events[_grilleRowUpdated];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="RowUpdating"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewUpdateEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnRowUpdating(GridViewUpdateEventArgs e)
        {
            GridViewUpdateEventHandler handler =
                (GridViewUpdateEventHandler)Events[_grilleRowUpdating];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Sorted"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement</param>
        protected virtual void OnSorted(EventArgs e)
        {
            EventHandler handler =
                (EventHandler)Events[_grilleSorted];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Sorting"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.GridViewSortEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnSorting(GridViewSortEventArgs e)
        {
            GridViewSortEventHandler handler =
                (GridViewSortEventHandler)Events[_grilleSorting];
            if (handler != null)
                handler(this, e);
        }

        protected override void OnDataBinding(EventArgs e)
        {
            EventHandler handler =
                (EventHandler)Events[_grilleDataBinding];
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnDataBound(EventArgs e)
        {
            EventHandler handler =
                (EventHandler)Events[_grilleDataBound];
            if (handler != null)
                handler(this, e);
        }

        // ====================================================================
        #endregion

        #region Méthodes des événements relayés par les DataSource
        // ====================================================================

        /// <summary>
        /// Lève l'évènement <see cref="Deleted"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnDeleted(ObjectDataSourceStatusEventArgs e)
        {
            ObjectDataSourceStatusEventHandler handler =
                (ObjectDataSourceStatusEventHandler)Events[_dataSourceDeleted];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Deleting"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnDeleting(ObjectDataSourceMethodEventArgs e)
        {
            ObjectDataSourceMethodEventHandler handler =
                (ObjectDataSourceMethodEventHandler)Events[_dataSourceDeleting];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Filtering"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceFilteringEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnFiltering(ObjectDataSourceFilteringEventArgs e)
        {
            ObjectDataSourceFilteringEventHandler handler =
                (ObjectDataSourceFilteringEventHandler)Events[_dataSourceFiltering];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Inserted"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnInserted(ObjectDataSourceStatusEventArgs e)
        {
            ObjectDataSourceStatusEventHandler handler =
                (ObjectDataSourceStatusEventHandler)Events[_dataSourceInserted];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Inserting"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnInserting(ObjectDataSourceMethodEventArgs e)
        {
            ObjectDataSourceMethodEventHandler handler =
                (ObjectDataSourceMethodEventHandler)Events[_dataSourceInserting];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="ObjectCreated"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnObjectCreated(ObjectDataSourceEventArgs e)
        {
            ObjectDataSourceObjectEventHandler handler =
                (ObjectDataSourceObjectEventHandler)Events[_dataSourceObjectCreated];
            if (handler != null)
                handler(this, e);
        }
        /// <summary>
        /// Lève l'évènement <see cref="ObjectCreating"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnObjectCreating(ObjectDataSourceEventArgs e)
        {
            ObjectDataSourceObjectEventHandler handler =
                (ObjectDataSourceObjectEventHandler)Events[_dataSourceObjectCreating];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="ObjectDisposing"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceDisposingEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnObjectDisposing(ObjectDataSourceDisposingEventArgs e)
        {
            ObjectDataSourceDisposingEventHandler handler =
                (ObjectDataSourceDisposingEventHandler)Events[_dataSourceObjectDisposing];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Selected"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnSelected(ObjectDataSourceStatusEventArgs e)
        {
            ObjectDataSourceStatusEventHandler handler =
                (ObjectDataSourceStatusEventHandler)Events[_dataSourceSelected];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Selecting"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnSelecting(ObjectDataSourceSelectingEventArgs e)
        {
            ObjectDataSourceSelectingEventHandler handler =
                (ObjectDataSourceSelectingEventHandler)Events[_dataSourceSelecting];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Updated"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs"/> contenant les données de l'évènement</param>
        protected virtual void OnUpdated(ObjectDataSourceStatusEventArgs e)
        {
            ObjectDataSourceStatusEventHandler handler =
                (ObjectDataSourceStatusEventHandler)Events[_dataSourceUpdated];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="Updating"/>.
        /// </summary>
        /// <param name="e">L'instance <see cref="System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnUpdating(ObjectDataSourceMethodEventArgs e)
        {
            ObjectDataSourceMethodEventHandler handler =
                (ObjectDataSourceMethodEventHandler)Events[_dataSourceUpdating];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="DetailSelected"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnDetailSelected(ObjectDataSourceStatusEventArgs e)
        {
            ObjectDataSourceStatusEventHandler handler =
                (ObjectDataSourceStatusEventHandler)Events[_detailDataSourceSelected];
            if (handler != null)
                handler(this, e);
        }

        /// <summary>
        /// Lève l'évènement <see cref="DetailSelecting"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnDetailSelecting(ObjectDataSourceSelectingEventArgs e)
        {
            ObjectDataSourceSelectingEventHandler handler =
                (ObjectDataSourceSelectingEventHandler)Events[_detailDataSourceSelecting];
            if (handler != null)
                handler(this, e);
        }

        // ====================================================================
        #endregion

        #region Méthodes des événements relayés par la Fenêtre
        // ====================================================================

        /// <summary>
        /// Lève l'évènement <see cref="FenetreEditionClosed"/>.
        /// </summary>
        /// <param name="e">L'instance de <see cref="System.EventArgs"/> contenant les données de l'évènement.</param>
        protected virtual void OnFenetreEditionClosed(EventArgs e)
        {
            EventHandler handler =
                (EventHandler)Events[_fenetreEditionClosed];
            if (handler != null)
                handler(this, e);
        }

        // ====================================================================
        #endregion
    }
}

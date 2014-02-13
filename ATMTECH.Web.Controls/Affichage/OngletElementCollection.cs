using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace ATMTECH.Web.Controls.Affichage
{
    /// <summary>
    /// Classe implémentant la collection dans l'onglet.
    /// </summary>
    
    public class OngletElementCollection : IList, IStateManager
    {
        private ArrayList _items;
        private bool _persisteTout;

        /// <summary>
        /// initialise une nouvelle instance de la classe <see cref="OngletElementCollection"/>.
        /// </summary>
        public OngletElementCollection()
        {
            _items = new ArrayList();
        }

        /// <summary>
        /// Rechercher l'onglet avec le titre passé en paramètre.
        /// </summary>
        /// <param name="value">Le titre recherché.</param>
        /// <returns>L'onglet correspondant à la recherche ou un élément null.</returns>
        public OngletElement RechercherParTitre(string value)
        {
            return _items.Cast<OngletElement>().FirstOrDefault(itm => itm.Titre.Equals(value));
        }

        /// <summary>
        /// Recherche l'ongle qui possède comme contenu, le type de usercontrol 
        /// passé comme valeur de recherche.
        /// </summary>
        /// <param name="value">Type de l'usercontrol en format string</param>
        /// <returns>L'onglet correspondant à la recherche ou un élément null.</returns>
        public OngletElement RechercherParContenu(string value)
        {
            return _items.Cast<OngletElement>().FirstOrDefault(itm => itm.Contenu.Equals(value));
        }

        /// <summary>
        /// Recherche l'onglet qui possède l'état sélectionné.
        /// </summary>
        /// <returns>L'onglet correspondant à la recherche ou un élément null.</returns>
        public OngletElement OngletSelectionne()
        {
            return _items.Cast<OngletElement>().FirstOrDefault(itm => itm.Selectionne);
        }

        /// <summary>
        /// Selectionne l'onglet qui se retrouve à la position demandée dans la collection d'onglet.
        /// </summary>
        /// <param name="index">Position de l'onglet.</param>
        public void SelectionnerOnglet(int index)
        {
            if (_items.Count <= 0) return;

            OngletElement prochainOnglet = (OngletElement) _items[index];
            ReinitialiserSelection();
            prochainOnglet.Selectionne = true;
        }

        /// <summary>
        /// Obtenir le contenu de l'onglet sélectionné
        /// </summary>
        public Type ObtenirContenuSelectionne()
        {
            OngletElement selectionne =
                _items.Cast<OngletElement>().FirstOrDefault(itm => itm.Selectionne);

            return selectionne == null ? null : Type.GetType(selectionne.Contenu);
        }

        /// <summary>
        /// Obtenir l'index de l'onglet sélectionné
        /// </summary>
        /// <returns>Position dans la collection</returns>
        public int IndexOngletSelectionne()
        {
            OngletElement selectionne =
                _items.Cast<OngletElement>().FirstOrDefault(itm => itm.Selectionne);
            return IndexOf(selectionne);
        }

        #region Implementation of IEnumerable

        /// <summary>
        /// Obtient un énumérateur qui parcourt une collection
        /// </summary>
        /// <returns>
        /// Un <see cref="T:System.Collections.IEnumerable"/> qui peut être utilisé pour parcourir une collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            _items.CopyTo(array, index);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Obtient un objet qui peut être utilisé pour synchroniser les accès à la <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// Un objet qui peut être utilisé pour synchroniser les accès à la <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public object SyncRoot
        {
            get { return _items.SyncRoot; }
        }

        /// <summary>
        /// Obtient une valeur indiquant si la <see cref="T:System.Collections.ICollection"/> est synchronysée (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>vrai si l'accès à la <see cref="T:System.Collections.ICollection"/> est synchronisée (thread safe); sinon, faux.
        /// </returns>
        public bool IsSynchronized
        {
            get { return _items.IsSynchronized; }
        }

        #endregion

        #region Implementation of 
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Add(object value)
        {
            return Add((OngletElement)value);
        }

        /// <summary>
        /// Ajoute la valeur spécifiée à la collection.
        /// </summary>
        /// <param name="value">La valeur.</param>
        /// <returns></returns>
        public int Add(OngletElement value)
        {
            int resultat = _items.Add(value);
            if (IsTrackingViewState)
            {
                value.Dirty = true;
            }
            return resultat;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(object value)
        {
            return _items.Contains(value);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(object value)
        {
            return IndexOf((OngletElement)value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int IndexOf(OngletElement value)
        {
            return _items.IndexOf(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        public void Insert(int index, object value)
        {
            Insert(index, (OngletElement)value);
        }

        /// <summary>
        /// Insère l'index spécifié dans l'onglet.
        /// </summary>
        /// <param name="index">L'index.</param>
        /// <param name="value">La valeur.</param>
        public void Insert(int index, OngletElement value)
        {
            _items.Insert(index, value);
            if (IsTrackingViewState)
            {
                _persisteTout = true;
            }
        }

        /// <summary>
        /// Retire la première occurence d'un objet spécifié dans la <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">L'<see cref="T:System.Object"/> à retirer de la <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// -ou-
        /// La <see cref="T:System.Collections.IList"/> à une grandeur fixe.
        /// </exception>
        public void Remove(object value)
        {
            Remove((OngletElement)value);
        }

        /// <summary>
        /// Retire la valeur spécifié des items contenus dans l'onglet.
        /// </summary>
        /// <param name="value">La valeur.</param>
        public void Remove(OngletElement value)
        {
            _items.Remove(value);
            if (IsTrackingViewState)
            {
                _persisteTout = true;
            }
        }

        /// <summary>
        /// Retire un item de la <see cref="T:System.Collections.IList"/> à un index spécifié.
        /// </summary>
        /// <param name="index">L'index à retirer.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> n'est pas un index valide de <see cref="T:System.Collections.IList"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// -ou-
        /// La <see cref="T:System.Collections.IList"/> a une taille fixe.
        /// </exception>
        public void RemoveAt(int index)
        {
            _items.RemoveAt(index);
            if (IsTrackingViewState)
            {
                _persisteTout = true;
            }
        }

        /// <summary>
        /// Obtient ou affecte l'<see cref="System.Object"/> à l'indes spécifié.
        /// </summary>
        /// <value></value>
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items[index] = value; }
        }

        /// <summary>
        /// Obtient une valeur indiquant si la <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// </summary>
        /// <value></value>
        /// <returns>vrai si la <see cref="T:System.Collections.IList"/> est en lecture seule; sinon, faux.
        /// </returns>
        public bool IsReadOnly
        {
            get { return _items.IsReadOnly; }
        }

        /// <summary>
        /// Obtient une valeur indiquant si la <see cref="T:System.Collections.IList"/> a une grandeur fixe.
        /// </summary>
        /// <value></value>
        /// <returns>vrai si la <see cref="T:System.Collections.IList"/> a une grandeur fixe; sinon, faux.
        /// </returns>
        public bool IsFixedSize
        {
            get { return _items.IsFixedSize; }
        }

        #endregion

        #region Implementation of IStateManager

        /// <summary>
        /// Implémenté par une classe, charge dans un contrôle serveur son état d'affichage précédemment enregistré.
        /// </summary>
        /// <param name="state"><see cref="T:System.Object"/> qui contient les valeurs d'état d'affichage enregistrées du contrôle.</param>
        
        public void LoadViewState(object state)
        {
            if (state != null)
            {
                if (state is Pair)
                {
                    Pair pair = (Pair)state;
                    ArrayList x = (ArrayList)pair.First;
                    ArrayList y = (ArrayList)pair.Second;

                    for (int i = 0; i < x.Count; i++)
                    {
                        int index = (int)x[i];

                        if (index < Count)
                        {
                            OngletElement ATMTECHOngletElement = (OngletElement)this[index];
                            ATMTECHOngletElement.LoadViewState(y[i]);
                        }
                        else
                        {
                            OngletElement ATMTECHOngletElement = new OngletElement();
                            ATMTECHOngletElement.LoadViewState(y[i]);
                            Add(ATMTECHOngletElement);
                        }
                    }
                }
                else
                {
                    Triplet triplet = (Triplet)state;
                    _items = new ArrayList();
                    _persisteTout = true;

                    string[] xx = (string[])triplet.First;
                    string[] yy = (string[])triplet.Second;
                    bool[] zz = (bool[])triplet.Third;

                    for (int i = 0; i < xx.Count(); i++)
                    {
                        Add(new OngletElement(xx[i], yy[i], zz[i]));
                    }
                }
            }
        }

        /// <summary>
        /// Implémenté par une classe, enregistre les modifications de l'état d'affichage d'un contrôle serveur dans un <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// 	<see cref="T:System.Object"/> qui contient les changements de l'état d'affichage.
        /// </returns>
        public object SaveViewState()
        {
            if (_persisteTout)
            {
                int nombre = Count;
                Object[] xx = new string[nombre];
                Object[] yy = new string[nombre];
                bool[] z = new bool[nombre];

                for (int i = 0; i < nombre; i++)
                {
                    OngletElement ATMTECHOngletElement = (OngletElement)this[i];
                    xx[i] = ATMTECHOngletElement.Titre;
                    yy[i] = ATMTECHOngletElement.Contenu;
                    z[i] = ATMTECHOngletElement.Enabled;
                }
                return new Triplet(xx, yy, z);
            }
            ArrayList x = new ArrayList(4);
            ArrayList y = new ArrayList(4);

            for (int i = 0; i < Count; i++)
            {
                OngletElement ATMTECHOngletElement = (OngletElement)this[i];
                Object etat = ATMTECHOngletElement.SaveViewState();

                if (etat != null)
                {
                    x.Add(i);
                    y.Add(etat);
                }
            }
            return x.Count > 0 ? new Pair(x, y) : null;
        }

        /// <summary>
        /// Implémenté par une classe, commande au contrôle serveur d'effectuer le suivi des modifications de son état d'affichage.
        /// </summary>
        public void TrackViewState()
        {
            IsTrackingViewState = true;
        }

        /// <summary>
        /// Implémenté par une classe, obtient une valeur indiquant si un contrôle serveur effectue le suivi des changements de son état d'affichage.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// true si le contrôle serveur effectue le suivi des changements de son état d'affichage ; sinon, false.
        /// </returns>
        public bool IsTrackingViewState { get; private set; }

        #endregion

        #region [ Méthode privé ]

        private void ReinitialiserSelection()
        {
            foreach (OngletElement itm in _items)
            {
                itm.Selectionne = false;
            }
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void EnleverOngletDisabled()
        {
            IList<OngletElement> listDisable = _items.Cast<OngletElement>().Where(p => !p.Enabled).ToList();
            foreach(OngletElement lst in listDisable)
            {
                _items.Remove(lst);
            }
        }

        /// <summary>
        /// Récupère un onglet par le titre dans la collection
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public OngletElement ObtenirOngletParTitre(string titre)
        {
            return _items.Cast<OngletElement>().FirstOrDefault(p => p.Titre == titre);
        }
        
        /// <summary>
        /// Récupère un onglet par le titre dans la collection
        /// </summary>
        [Obsolete("Assigner un ID propre à l'onglet pour l'obtenir")]
        public OngletElement ObtenirOngletParIdObjetSecurite(string idObjetSecurite)
        {
            return _items.Cast<OngletElement>().FirstOrDefault(p => p.IdObjetSecurite == idObjetSecurite);
        }

        /// <summary>
        /// Récupère un onglet par son ID
        /// </summary>
        public OngletElement ObtenirOngletParId(string id)
        {
            return _items.Cast<OngletElement>().FirstOrDefault(p => p.ID == id);
        }
    }
}
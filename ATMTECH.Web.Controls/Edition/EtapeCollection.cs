using System;
using System.Collections;


namespace ATMTECH.Web.Controls.Edition
{
    /// <summary>
    /// 
    /// </summary>
    
    public class EtapeCollection : IList
    {
        private readonly ArrayList _etapes;
        private readonly Wizard _parent;

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="EtapeCollection"/>.
        /// </summary>
        /// <param name="parent">The parent.</param>
        public EtapeCollection(Wizard parent)
        {
            _etapes = new ArrayList();
            _parent = parent;
        }
               
     

        #region Implementation of IEnumerable

        /// <summary>
        /// Retourne un itérateur pour itérer à travers une collection
        /// </summary>
        /// <returns>
        /// Un objet <see cref="T:System.Collections.IEnumerable"/> qui peut être utiliser pour parcourir une collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return _etapes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection

        /// <summary>
        /// Méthode permettant de copier un array à un index spécifié.
        /// </summary>
        /// <param name="array">L'array.</param>
        /// <param name="arrayIndex">L'index de l'array.</param>
        
        public void CopyTo(Array array, int arrayIndex)
        {
            _etapes.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Obtient le nombre d'élément(s) contenu(s) dans la <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// Le nombre d'élément(s) contenu(s) dans la <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public int Count
        {
            get { return _etapes.Count; }
        }

        /// <summary>
        /// Obtient un objet qui peut être utilisé pour synchronisé l'accès à une <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// Un objet qui peut être utilisé pour synchronisé l'accès à une <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public object SyncRoot
        {
            get {return _etapes.SyncRoot; }
        }

        /// <summary>
        /// Obtient une valeur indiquant si la <see cref="T:System.Collections.ICollection"/> est synchronisée (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>vraie si l'accès à la <see cref="T:System.Collections.ICollection"/> est synchronisée (thread safe); sinon, faux.
        /// </returns>
        public bool IsSynchronized
        {
            get { return _etapes.IsSynchronized; }
        }

        #endregion

        #region Implementation of IList

        /// <summary>
        /// Ajouter un item à la liste.
        /// </summary>
        /// <param name="item">L'item.</param>
        /// <returns></returns>
        public int Add(Etape item)
        {
            int value =  _etapes.Add(item);
            _parent.ChargerOnglet(item);
            return value;
        }

        /// <summary>
        /// Détermine si la liste contient l'item spécifié.
        /// </summary>
        /// <param name="item">L'item.</param>
        /// <returns>
        /// 	<c>Vrai</c> si la liste contient l'item; autrement, <c>faux</c>.
        /// </returns>
        public bool Contains(Etape item)
        {
            return _etapes.Contains(item);
        }

        /// <summary>
        /// Ajoute un item à la <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">L'<see cref="T:System.Object"/> à ajouter à la <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// La position à laquelle le nouvel élément a été inséré.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// -ou-
        /// La <see cref="T:System.Collections.IList"/> a une grandeur fixe.
        /// </exception>
        public int Add(object value)
        {
           return Add((Etape) value);
        }

        /// <summary>
        /// Détermine si la <see cref="T:System.Collections.IList"/> contient une valeur spécifique.
        /// </summary>
        /// <param name="value">L'<see cref="T:System.Object"/> à localiser dans la <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// vrai si l'<see cref="T:System.Object"/> se retrouve dans la <see cref="T:System.Collections.IList"/>; sinon, faux.
        /// </returns>
        public bool Contains(object value)
        {
            return Contains((Etape) value);
        }

        /// <summary>
        /// Vide la <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// </exception>
        public void Clear()
        {
            _etapes.Clear();
        }

        /// <summary>
        /// Trouve l'index pour un item donné
        /// </summary>
        /// <param name="item">L'item.</param>
        /// <returns></returns>
        public int IndexOf(Etape item)
        {
            return _etapes.IndexOf(item);
        }

        /// <summary>
        /// Détermine l'index d'un item spécifié dans la <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">L'<see cref="T:System.Object"/> à localiser dans la <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// L'index de la <paramref name="value"/> si elle se trouve dans la liste; sinon, -1.
        /// </returns>
        public int IndexOf(object value)
        {
            return IndexOf((Etape) value);
        }

        /// <summary>
        /// Insère un item à la <see cref="T:System.Collections.IList"/> à l'index spécifié.
        /// </summary>
        /// <param name="index">L'index à lequel la <paramref name="value"/> devrait être insérée.</param>
        /// <param name="value">L'<see cref="T:System.Object"/> à insérer dans la <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> n'est pas un index valide de <see cref="T:System.Collections.IList"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// -ou-
        /// La <see cref="T:System.Collections.IList"/> a une grandeur fixe.
        /// </exception>
        /// <exception cref="T:System.NullReferenceException">
        /// 	<paramref name="value"/> est une référence nulle dans la <see cref="T:System.Collections.IList"/>.
        /// </exception>
        public void Insert(int index, object value)
        {
            Insert( index, (Etape)value);
        }

        /// <summary>
        /// Retire la première occurence d'un objet spécifié dans la <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">L'<see cref="T:System.Object"/> à retirer de la <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// -ou-
        /// La <see cref="T:System.Collections.IList"/> a une taille fixe.
        /// </exception>
        public void Remove(object value)
        {
            Remove((Etape) value);
        }

        /// <summary>
        /// Insère un item dans l'index donné.
        /// </summary>
        /// <param name="index">L'index.</param>
        /// <param name="item">L'item.</param>
        public void Insert(int index, Etape item)
        {
            _etapes.Insert(index, item);
        }

        /// <summary>
        /// Enlève l'item donné de la liste.
        /// </summary>
        /// <param name="item">L'item.</param>
        public void Remove(Etape item)
        {
           _etapes.Remove(item);
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
            _etapes.RemoveAt(index);
        }

        /// <summary>
        /// Obtient ou affecte <see cref="System.Object"/> à un index spécifié.
        /// </summary>
        /// <value></value>
        public object this[int index]
        {
            get { return _etapes[index]; }
            set { _etapes[index] = value; }
        }

        /// <summary>
        /// Obtient une valeur indiquant si la <see cref="T:System.Collections.IList"/> est en lecture seule.
        /// </summary>
        /// <value></value>
        /// <returns>Vrai si la <see cref="T:System.Collections.IList"/> est en lecture seule; sinon, faux.
        /// </returns>
        public bool IsReadOnly
        {
            get { return _etapes.IsReadOnly; }
        }

        /// <summary>
        /// Obtient une valeur indiquant si la <see cref="T:System.Collections.IList"/> a une taille fixe.
        /// </summary>
        /// <value></value>
        /// <returns>vrai si la <see cref="T:System.Collections.IList"/> a uen taille fixe; sinon, faux.
        /// </returns>
        public bool IsFixedSize
        {
            get { return _etapes.IsFixedSize; }
        }

        #endregion

        /// <summary>
        /// Vérifie si l'étape précédente est accessible.
        /// </summary>
        /// <returns></returns>
        public bool VerifierEtapePrecedanteAccessible()
        {
            int indexCourante = _parent.IndexEtapeCourante;
            int indexEtapePrecedante = indexCourante - 1;

            if (indexEtapePrecedante < 0 || Count <= 0)
                return false;

            Etape precedante = this[indexEtapePrecedante] as Etape;

            return precedante != null ? precedante.EstReaccessible : false;
        }

        /// <summary>
        /// Obtient l'étape courante.
        /// </summary>
        /// <returns></returns>
        public Etape ObtenirEtapeCourante()
        {
            int indexCourante = _parent.IndexEtapeCourante;
            return this[indexCourante] as Etape;
        }

        /// <summary>
        /// Vérifie si on est en présence de l'étape finale.
        /// </summary>
        /// <returns></returns>
        
        public bool VerifierSiEtapeFinal()
        {
            int indexCourante = _parent.IndexEtapeCourante;
            Etape courante = this[indexCourante] as Etape ;

            if (courante == null)
                //TODO: ajouter un nouveau type d'exception pour cette erreur.               
                throw new ApplicationException("L'étape courante n'existe pas.");

            return courante.TypeSequence == EnumTypeSequence.Fin;
        }

        /// <summary>
        /// Vérifie l'étape existante par son index
        /// </summary>
        /// <param name="indexEtapeSuivante">L'index de l'étape suivante.</param>
        /// <returns></returns>
        public bool VerifierExistanteEtapeParIndex(int indexEtapeSuivante)
        {
            if (indexEtapeSuivante >= Count)
                return false;

            Etape etape = this[indexEtapeSuivante] as Etape ;

            return etape != null;
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ATMTECH.Web.Controls.Validation
{
    /// <summary>
    /// Classe de collection pour les messages
    /// </summary>
    public class MessageCollection : IList<Message>
    {
        /// <summary>
        /// Exception levée lorsqu'il y a une erreur lors de l'ajout d'un message
        /// </summary>
        public event EventHandler MessageErreurAjoute;


        private readonly ArrayList _messages;

        /// <summary>
        /// Initialise une nouvelle instance de la classe<see cref="MessageCollection"/>.
        /// </summary>
        public MessageCollection()
        {
            _messages = new ArrayList(3);
        }

        #region [ Implementation de IList<Message> ]

        /// <summary>
        /// Retourne un énumérateur qui parcours une collection
        /// </summary>
        /// <returns>
        /// Un <see cref="T:System.Collections.Generic.IEnumerable`1"/> qui peut être utilisé pour parcourir la collection.
        /// </returns>
        public IEnumerator<Message> GetEnumerator()
        {
            return (IEnumerator<Message>) _messages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Ajoute un item à la <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">L'objet à ajouter à la <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.Generic.ICollection`1"/> est en lecture seule.
        /// </exception>
        public void Add(Message item)
        {
            _messages.Add(item);
            if (item.Categorie != EnumCategorieMessage.Succes)
            {
                OnMessageErreurAjoute(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Lève l'évènement <see cref="MessageErreurAjoute"/>.
        /// </summary>
        /// <param name="e">L' <see cref="System.EventArgs"/> instance contenant l'évènement.</param>
        protected virtual void OnMessageErreurAjoute(EventArgs e)
        {
            if (MessageErreurAjoute != null)
            {
                MessageErreurAjoute(this, e);
            }
        }

        /// <summary>
        /// Enlève tous les items de <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.Generic.ICollection`1"/> est en lecture seule.
        /// </exception>
        public void Clear()
        {
            _messages.Clear();
        }

        /// <summary>
        /// Détermine si la <see cref="T:System.Collections.Generic.ICollection`1"/> contient une valeur spécifique.
        /// </summary>
        /// <param name="item">L'object à localiser dans la <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <returns>
        /// vrai si l' <paramref name="item"/> est trouvé dans la <see cref="T:System.Collections.Generic.ICollection`1"/>; sinon, faux.
        /// </returns>
        public bool Contains(Message item)
        {
            return _messages.Contains(item);
        }

        /// <summary>
        /// Copie les éléments de la <see cref="T:System.Collections.Generic.ICollection`1"/> vers une <see cref="T:System.Array"/>, commençant à un index particulié <see cref="T:System.Array"/>.
        /// </summary>
        /// <param name="array">L'<see cref="T:System.Array"/> qui est la destination des éléments copiés à partir de <see cref="T:System.Collections.Generic.ICollection`1"/>. L'<see cref="T:System.Array"/> doit avoir des index basés sur 0.</param>
        /// <param name="arrayIndex">L'index dans l'<paramref name="array"/> à partir duquel on commence la copie.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="array"/> est null.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="arrayIndex"/> est plus petit que zéro.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// 	<paramref name="array"/> est multidimensionnelle.
        /// -ou-
        /// <paramref name="arrayIndex"/> est égal à ou est plus grand que la longueur de <paramref name="array"/>.
        /// -ou-
        /// Le nombre d'éléments dans la source <see cref="T:System.Collections.Generic.ICollection`1"/> est supérieur à l'espace disponible dans <paramref name="arrayIndex"/> à la fin de la destination <paramref name="array"/>.
        /// -ou-
        /// Le type des éléments ne peut pas être casté automatiquement au type de la destination <paramref name="array"/>.
        /// </exception>
        public void CopyTo(Message[] array, int arrayIndex)
        {
            _messages.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Enlève la première occurence d'un object spécifié dans <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="item">L'objet à enlever de <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        /// <returns>
        /// Vrai si <paramref name="item"/> a été enlevé avec succès de <see cref="T:System.Collections.Generic.ICollection`1"/>; sinon, retourne faux. Cette méthode retourne également faux si <paramref name="item"/> ne se retrouve pas dans <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.Generic.ICollection`1"/> est en lecture seule.
        /// </exception>
        public bool Remove(Message item)
        {
            _messages.Remove(item);
            return true;
        }

        /// <summary>
        /// Obtient le nombre d'éléments contenus dans la <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// Le nombre d'éléments contenus dans la <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get { return _messages.Count; }
        }

        /// <summary>
        /// Obtient une valeur indiquant si la <see cref="T:System.Collections.Generic.ICollection`1"/> est en lecture seule.
        /// </summary>
        /// <value></value>
        /// <returns>Vrai si la <see cref="T:System.Collections.Generic.ICollection`1"/> est en lecture seule; sinon, faux.
        /// </returns>
        public bool IsReadOnly
        {
            get { return _messages.IsReadOnly; }
        }

        /// <summary>
        /// Détermine l'index d'un item spécifique dans la <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </summary>
        /// <param name="item">L'objet à localiser dans la <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        /// <returns>
        /// L'index de l'<paramref name="item"/> si trouvé dans la liste; sinon, -1.
        /// </returns>
        public int IndexOf(Message item)
        {
            return _messages.IndexOf(item);
        }

        /// <summary>
        /// Insère un item dans la <see cref="T:System.Collections.Generic.IList`1"/> à l'index spécifié.
        /// </summary>
        /// <param name="index">L'index à lequel l'<paramref name="item"/> devrait être inséré.</param>
        /// <param name="item">l'objet à insérer dans la <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> n'est pas un index valide de <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.Generic.IList`1"/> est en lecture seule.
        /// </exception>
        public void Insert(int index, Message item)
        {
            _messages.Insert(index, item);
        }

        /// <summary>
        /// Enlève l'élément à l'index spécifié de la <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </summary>
        /// <param name="index">L'index de l'élément à enlever.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> n'est pas un index valide de la <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// La <see cref="T:System.Collections.Generic.IList`1"/> est en lecture seule.
        /// </exception>
        public void RemoveAt(int index)
        {
            _messages.RemoveAt(index);
        }

        /// <summary>
        /// Méthode permettant d'obtenir ou de fixer la valeur de <see cref="ATMTECH.Web.Controls.Validation.Message"/> à
        /// l'index spécifié.
        /// </summary>
        /// <value></value>
        public Message this[int index]
        {
            get { return (Message) _messages[index]; }
            set { _messages[index] = value; }
        }

        #endregion

        /// <summary>
        /// Compte le nombre de message d'erreur.
        /// </summary>
        /// <returns></returns>
        public int CompterMessageErreur()
        {
            int compte = 0;

            IList<Message> messages = RechercherMessageErreur();
            if (messages != null)
                compte += messages.Count;

            return compte;
        }

        /// <summary>
        /// Recherche les messages de catégorie "attention".
        /// </summary>
        /// <returns></returns>
        public IList<Message> RechercherMessageAttention()
        {
            return RechercherParCategorie(EnumCategorieMessage.Attention);
        }

        /// <summary>
        /// Recherche les messages de catégorie "confirmation".
        /// </summary>
        /// <returns></returns>
        public IList<Message> RechercherMessageConfirmation()
        {
            return RechercherParCategorie(EnumCategorieMessage.Confirmation);
        }

        /// <summary>
        /// Recherche les messages de catégorie "erreur".
        /// </summary>
        /// <returns></returns>
        public IList<Message> RechercherMessageErreur()
        {
            return RechercherParCategorie(EnumCategorieMessage.Severe);
        }

        /// <summary>
        /// Recherche les messages de catégorie "succes".
        /// </summary>
        /// <returns></returns>
        public IList<Message> RechercherMessageSucces()
        {
            return RechercherParCategorie(EnumCategorieMessage.Succes);
        }

        private IList<Message> RechercherParCategorie(EnumCategorieMessage categorie)
        {
            return _messages
                .Cast<Message>()
                .ToList()
                .FindAll(x => x.Categorie == categorie);
        }
    }
}
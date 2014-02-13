using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMTECH.Common
{
    [Serializable]
    public class Monnaie : IEquatable<Monnaie>,
                           IComparable<Monnaie>,
                           IFormattable,
                           IConvertible
    {
        private const Decimal PRECISION_DECIMALE = 1E4M; //1E4M = 10 000
        private readonly Int64 _unites;
        private readonly Int32 _fractionDecimale;

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.Byte"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(Byte valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.SByte"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(SByte valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.Single"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(Single valeur)
        {
            return new Monnaie((Decimal)valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.Double"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(Double valeur)
        {
            return new Monnaie((Decimal)valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.Decimal"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(Decimal valeur)
        {
            return new Monnaie(valeur);
        }



        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.Int16"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(Int16 valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.Int32"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(Int32 valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.Int64"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(Int64 valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.UInt16"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(UInt16 valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.UInt32"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(UInt32 valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Effectue une conversion implicite 
        /// de <see cref="System.UInt64"/> vers <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de la conversion.</returns>
        public static implicit operator Monnaie(UInt64 valeur)
        {
            return new Monnaie(valeur);
        }

        /// <summary>
        /// Implemente l'operateur -.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Monnaie operator -(Monnaie valeur)
        {
            return valeur != null ? new Monnaie(-valeur._unites, -valeur._fractionDecimale) : new Monnaie(0);
        }

        /// <summary>
        /// Implemente l'operateur +.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Monnaie operator +(Monnaie gauche, Monnaie droite)
        {
            Monnaie gaucheNonNull = gauche ?? new Monnaie(0);
            Monnaie droiteNonNull = droite ?? new Monnaie(0);
            Int32 sommeFractions = gaucheNonNull._fractionDecimale + droiteNonNull._fractionDecimale;

            Int64 surplusFraction = 0;
            Int32 signeFraction = System.Math.Sign(sommeFractions);
            Int32 sommeFractionsAbsolue = System.Math.Abs(sommeFractions);

            // Si la somme des fractions est supérieure à la précision décimale,
            // on doit ajouter le surplus aux unités, et ramener la somme des 
            // fractions sous la précision décimale
            if (sommeFractionsAbsolue >= PRECISION_DECIMALE)
            {
                surplusFraction = signeFraction;
                sommeFractionsAbsolue -= (Int32)PRECISION_DECIMALE;
                sommeFractions = signeFraction * sommeFractionsAbsolue;
            }

            Int64 nouveauTotalUnites = gaucheNonNull._unites + droiteNonNull._unites + surplusFraction;

            // si on passe d'un nombre négatif à un nombre positif (ex: -10,4 + 20)
            // il faut enlever 1 aux unités et la somme des fractions sera 
            // égale à la précision décimal moins la somme des fractions en valeur
            // absolue
            if (signeFraction < 0 && System.Math.Sign(nouveauTotalUnites) > 0)
            {
                nouveauTotalUnites -= 1;
                sommeFractions = (Int32)PRECISION_DECIMALE - sommeFractionsAbsolue;
            }

            return new Monnaie(nouveauTotalUnites,
                             sommeFractions);
        }

        /// <summary>
        /// Implemente l'operateur -.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Monnaie operator -(Monnaie gauche, Monnaie droite)
        {
            return gauche + -droite;
        }

        /// <summary>
        /// Implemente l'operateur *.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Monnaie operator *(Monnaie gauche, Decimal droite)
        {
            return (gauche.ObtenirValeurDecimale() * droite);
        }

        /// <summary>
        /// Implemente l'operateur /.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Monnaie operator /(Monnaie gauche, Decimal droite)
        {
            return (gauche.ObtenirValeurDecimale() / droite);
        }

        /// <summary>
        /// Implemente l'operateur ==.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Boolean operator ==(Monnaie gauche, Monnaie droite)
        {
            // If both are null return true.
            if (((object)gauche == null) && ((object)droite == null))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)gauche == null) || ((object)droite == null))
            {
                return false;
            }

            return gauche.Equals(droite);
        }

        /// <summary>
        /// Implemente l'operateur !=.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Boolean operator !=(Monnaie gauche, Monnaie droite)
        {
            return !(gauche == droite);
        }

        /// <summary>
        /// Implemente l'operateur &gt;.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Boolean operator >(Monnaie gauche, Monnaie droite)
        {
            return gauche.CompareTo(droite) > 0;
        }

        /// <summary>
        /// Implemente l'operateur &lt;.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Boolean operator <(Monnaie gauche, Monnaie droite)
        {
            return gauche.CompareTo(droite) < 0;
        }

        /// <summary>
        /// Implemente l'operateur &gt;=.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Boolean operator >=(Monnaie gauche, Monnaie droite)
        {
            return gauche.CompareTo(droite) >= 0;
        }

        /// <summary>
        /// Implemente l'operateur &lt;=.
        /// </summary>
        /// <param name="gauche">La valeur de gauche.</param>
        /// <param name="droite">la valeur de droite.</param>
        /// <returns>Le résultat de l'opérateur.</returns>
        public static Boolean operator <=(Monnaie gauche, Monnaie droite)
        {
            return gauche.CompareTo(droite) <= 0;
        }

        /// <summary>
        /// Initialise une nouvelle instance du type <see cref="Monnaie"/>
        /// sans paramètres pour faire plaisir à NHibernate.
        /// </summary>
        public Monnaie()
        {
            _unites = 0;
            _fractionDecimale = 0;
        }

        /// <summary>
        /// Initialise une nouvelle instance du type <see cref="Monnaie"/>.
        /// </summary>
        /// <param name="valeur">La valeur.</param>
        public Monnaie(Decimal valeur)
        {
            VerifierValeur(valeur);

            _unites = (Int64)valeur;
            _fractionDecimale = (Int32)Decimal.Round((valeur - _unites) * PRECISION_DECIMALE);

            // Si la fraction arrondie est supérieure à la précision décimale, 
            // on augmente les unités et on ramène la fraction sous la 
            // précision décimale.
            if (_fractionDecimale >= PRECISION_DECIMALE)
            {
                _unites += 1;
                _fractionDecimale = _fractionDecimale - (Int32)PRECISION_DECIMALE;
            }
        }

        private Monnaie(Int64 unites, Int32 fraction)
        {
            _unites = unites;
            _fractionDecimale = fraction;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override Int32 GetHashCode()
        {
            return 207501131 ^ _unites.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override Boolean Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Monnaie))
            {
                return false;
            }

            Monnaie valeurComparee = (Monnaie)obj;
            return Equals(valeurComparee);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override String ToString()
        {
            return ObtenirValeurDecimale().ToString("C");
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public String ToString(String format)
        {
            return ObtenirValeurDecimale().ToString(format);
        }

        public static Monnaie Abs(Monnaie valeur)
        {
            return System.Math.Abs(valeur.ObtenirValeurDecimale());
        }


        #region Implementation of IEquatable<Money>
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="valeurComparee"></param>
        /// <returns></returns>
        public Boolean Equals(Monnaie valeurComparee)
        {
            if (((object)valeurComparee) == null)
            {
                return false;
            }

            return _unites == valeurComparee._unites &&
                   _fractionDecimale == valeurComparee._fractionDecimale;
        }

        #endregion

        #region Implementation of IComparable<Money>
        /// <summary>
        /// CompareTo
        /// </summary>
        /// <param name="valeurComparee"></param>
        /// <returns></returns>
        public Int32 CompareTo(Monnaie valeurComparee)
        {
            Int32 unitCompare = _unites.CompareTo(valeurComparee._unites);

            return unitCompare == 0
                       ? _fractionDecimale.CompareTo(valeurComparee._fractionDecimale)
                       : unitCompare;
        }

        #endregion

        #region Implementation of IFormattable
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public String ToString(String format, IFormatProvider formatProvider)
        {
            return ObtenirValeurDecimale().ToString(format, formatProvider);
        }

        #endregion

        #region Implementation of IConvertible
        /// <summary>
        /// GetTypeCode
        /// </summary>
        /// <returns></returns>
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }
        /// <summary>
        /// ToBoolean
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Boolean ToBoolean(IFormatProvider provider)
        {
            return _unites == 0 && _fractionDecimale == 0;
        }
        /// <summary>
        /// ToChar
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Char ToChar(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// ToSByte
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public SByte ToSByte(IFormatProvider provider)
        {
            return (SByte)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToByte
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Byte ToByte(IFormatProvider provider)
        {
            return (Byte)ObtenirValeurDecimale();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Int16 ToInt16(IFormatProvider provider)
        {
            return (Int16)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToUInt16
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public UInt16 ToUInt16(IFormatProvider provider)
        {
            return (UInt16)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToInt32
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Int32 ToInt32(IFormatProvider provider)
        {
            return (Int32)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToUInt32
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public UInt32 ToUInt32(IFormatProvider provider)
        {
            return (UInt32)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToInt64
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Int64 ToInt64(IFormatProvider provider)
        {
            return (Int64)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToUInt64
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public UInt64 ToUInt64(IFormatProvider provider)
        {
            return (UInt64)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToSingle
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Single ToSingle(IFormatProvider provider)
        {
            return (Single)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToDouble
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Double ToDouble(IFormatProvider provider)
        {
            return (Double)ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToDecimal
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Decimal ToDecimal(IFormatProvider provider)
        {
            return ObtenirValeurDecimale();
        }
        /// <summary>
        /// ToDateTime
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public String ToString(IFormatProvider provider)
        {
            return ObtenirValeurDecimale().ToString(provider);
        }
        /// <summary>
        /// ToType
        /// </summary>
        /// <param name="conversionType"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public Object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotSupportedException();
        }

        #endregion

        /// <summary>
        /// Valeur decimale.
        /// </summary>
        internal Decimal ObtenirValeurDecimale()
        {
            return _unites + _fractionDecimale / PRECISION_DECIMALE;
        }

        private static void VerifierValeur(Decimal valeur)
        {
            if (valeur < Int64.MinValue || valeur > Int64.MaxValue)
            {
                throw new ArgumentOutOfRangeException("valeur",
                                                      valeur,
                                                      "La valeur monétaire doit être comprise entre " +
                                                      Int64.MinValue + " et " +
                                                      Int64.MaxValue);
            }
        }
    }

    public static class MonnaieExtension
    {
        public static decimal ValeurDecimale(this Monnaie monnaie)
        {
            return monnaie == null ? decimal.Zero : monnaie.ObtenirValeurDecimale();
        }
    }

    /// <summary>
    /// Type de monaie
    /// </summary>
    public static class MonnaieLinq
    {
        /// <summary>
        /// methode pour sommer la monnaie
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static Monnaie Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, Monnaie> selector)
        {
            IEnumerable<Monnaie> monnaies = source.Select(selector);
            Monnaie num1 = new Monnaie(0);
            foreach (Monnaie num2 in monnaies)
                num1 += num2;
            return num1;
        }
    }
}
/* 
 Licensed under the Apache License, Version 2.0
    
 http://www.apache.org/licenses/LICENSE-2.0
 */

using System.Text;
using System.Xml.Serialization;

namespace ATMTECH.MidiBoardGame.Entites
{
    /* 
 Licensed under the Apache License, Version 2.0
    
 http://www.apache.org/licenses/LICENSE-2.0
 */
    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    [XmlRoot(ElementName = "name")]
    public class Name
    {
        [XmlAttribute(AttributeName = "sortindex")]
        public string Sortindex { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "usersrated")]
    public class Usersrated
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "average")]
    public class Average
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "bayesaverage")]
    public class Bayesaverage
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "stddev")]
    public class Stddev
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "median")]
    public class Median
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "rating")]
    public class Rating
    {
        [XmlElement(ElementName = "usersrated")]
        public Usersrated Usersrated { get; set; }
        [XmlElement(ElementName = "average")]
        public Average Average { get; set; }
        [XmlElement(ElementName = "bayesaverage")]
        public Bayesaverage Bayesaverage { get; set; }
        [XmlElement(ElementName = "stddev")]
        public Stddev Stddev { get; set; }
        [XmlElement(ElementName = "median")]
        public Median Median { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "stats")]
    public class Stats
    {
        [XmlElement(ElementName = "rating")]
        public Rating Rating { get; set; }
        [XmlAttribute(AttributeName = "minplayers")]
        public string Minplayers { get; set; }
        [XmlAttribute(AttributeName = "maxplayers")]
        public string Maxplayers { get; set; }
        [XmlAttribute(AttributeName = "minplaytime")]
        public string Minplaytime { get; set; }
        [XmlAttribute(AttributeName = "maxplaytime")]
        public string Maxplaytime { get; set; }
        [XmlAttribute(AttributeName = "playingtime")]
        public string Playingtime { get; set; }
        [XmlAttribute(AttributeName = "numowned")]
        public string Numowned { get; set; }
    }

    [XmlRoot(ElementName = "status")]
    public class Status
    {
        [XmlAttribute(AttributeName = "own")]
        public string Own { get; set; }
        [XmlAttribute(AttributeName = "prevowned")]
        public string Prevowned { get; set; }
        [XmlAttribute(AttributeName = "fortrade")]
        public string Fortrade { get; set; }
        [XmlAttribute(AttributeName = "want")]
        public string Want { get; set; }
        [XmlAttribute(AttributeName = "wanttoplay")]
        public string Wanttoplay { get; set; }
        [XmlAttribute(AttributeName = "wanttobuy")]
        public string Wanttobuy { get; set; }
        [XmlAttribute(AttributeName = "wishlist")]
        public string Wishlist { get; set; }
        [XmlAttribute(AttributeName = "preordered")]
        public string Preordered { get; set; }
        [XmlAttribute(AttributeName = "lastmodified")]
        public string Lastmodified { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "name")]
        public Name Name { get; set; }
        [XmlElement(ElementName = "yearpublished")]
        public string Yearpublished { get; set; }
        [XmlElement(ElementName = "image")]
        public string Image { get; set; }
        [XmlElement(ElementName = "thumbnail")]
        public string Thumbnail { get; set; }
        [XmlElement(ElementName = "stats")]
        public Stats Stats { get; set; }
        [XmlElement(ElementName = "status")]
        public Status Status { get; set; }
        [XmlElement(ElementName = "numplays")]
        public string Numplays { get; set; }
        [XmlAttribute(AttributeName = "objecttype")]
        public string Objecttype { get; set; }
        [XmlAttribute(AttributeName = "objectid")]
        public string Objectid { get; set; }
        [XmlAttribute(AttributeName = "subtype")]
        public string Subtype { get; set; }
        [XmlAttribute(AttributeName = "collid")]
        public string Collid { get; set; }
        [XmlElement(ElementName = "originalname")]
        public string Originalname { get; set; }
    }

    [XmlRoot(ElementName = "items")]
    public class BoardGameGeekJeu
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
        [XmlAttribute(AttributeName = "totalitems")]
        public string Totalitems { get; set; }
        [XmlAttribute(AttributeName = "termsofuse")]
        public string Termsofuse { get; set; }
        [XmlAttribute(AttributeName = "pubdate")]
        public string Pubdate { get; set; }
    }



}

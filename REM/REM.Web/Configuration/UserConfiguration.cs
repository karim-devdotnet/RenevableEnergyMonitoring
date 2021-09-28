using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

//https://www.jokecamp.com/blog/net-custom-configuration-section-collection-and-elements/
namespace REM.Web.Configuration
{
    public class UserElement: ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
        }

        [ConfigurationProperty("login", IsRequired = true)]
        public string Login
        {
            get { return (string)base["login"]; }
        }

        [ConfigurationProperty("pwd", IsRequired = true)]
        public string Password
        {
            get { return (string)base["pwd"]; }
        }
    }

    [ConfigurationCollection(typeof(UserElement))]
    public class UserElementCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "user";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName,
              StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly()
        {
            return false;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new UserElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((UserElement)(element)).Login;
        }

        public UserElement this[int idx]
        {
            get { return (UserElement)BaseGet(idx); }
        }
    }

    public class UserSection : ConfigurationSection
    {
        [ConfigurationProperty("users")]
        public UserElementCollection Users
        {
            get { return ((UserElementCollection)(base["users"])); }
            set { base["users"] = value; }
        }
    }
}
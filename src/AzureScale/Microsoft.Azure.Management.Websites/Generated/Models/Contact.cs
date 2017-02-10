// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.WebSites.Models
{
    using System.Linq;

    /// <summary>
    /// Contact information for domain registration. If 'Domain Privacy'
    /// option is not selected then the contact information is made publicly
    /// available through the Whois
    /// directories as per ICANN requirements.
    /// </summary>
    public partial class Contact
    {
        /// <summary>
        /// Initializes a new instance of the Contact class.
        /// </summary>
        public Contact() { }

        /// <summary>
        /// Initializes a new instance of the Contact class.
        /// </summary>
        /// <param name="email">Email address.</param>
        /// <param name="nameFirst">First name.</param>
        /// <param name="nameLast">Last name.</param>
        /// <param name="phone">Phone number.</param>
        /// <param name="addressMailing">Mailing address.</param>
        /// <param name="fax">Fax number.</param>
        /// <param name="jobTitle">Job title.</param>
        /// <param name="nameMiddle">Middle name.</param>
        /// <param name="organization">Organization.</param>
        public Contact(string email, string nameFirst, string nameLast, string phone, Address addressMailing = default(Address), string fax = default(string), string jobTitle = default(string), string nameMiddle = default(string), string organization = default(string))
        {
            AddressMailing = addressMailing;
            Email = email;
            Fax = fax;
            JobTitle = jobTitle;
            NameFirst = nameFirst;
            NameLast = nameLast;
            NameMiddle = nameMiddle;
            Organization = organization;
            Phone = phone;
        }

        /// <summary>
        /// Gets or sets mailing address.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "addressMailing")]
        public Address AddressMailing { get; set; }

        /// <summary>
        /// Gets or sets email address.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets fax number.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets job title.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "jobTitle")]
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nameFirst")]
        public string NameFirst { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nameLast")]
        public string NameLast { get; set; }

        /// <summary>
        /// Gets or sets middle name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "nameMiddle")]
        public string NameMiddle { get; set; }

        /// <summary>
        /// Gets or sets organization.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "organization")]
        public string Organization { get; set; }

        /// <summary>
        /// Gets or sets phone number.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Email == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Email");
            }
            if (NameFirst == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "NameFirst");
            }
            if (NameLast == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "NameLast");
            }
            if (Phone == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Phone");
            }
            if (this.AddressMailing != null)
            {
                this.AddressMailing.Validate();
            }
        }
    }
}

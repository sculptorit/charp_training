using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName && LastName == other.LastName);
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "FirstName = " + FirstName + "\n" + "Lastname = " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if ((FirstName.CompareTo(other.FirstName) == 0) && (LastName.CompareTo(other.LastName) == 0))
            {
                return 0;
            }

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return 1;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }   
}

using ChiquinhoTec.GerenciadorContratacao.Common;

namespace ChiquinhoTec.GerenciadorContratacao.Register.Domain.Entities
{
    //
    // Summary:
    //     /// Class responsible for the entity. ///
    //
    public class Address : BaseEntity
    {
        public Address() {}

        public Address(string postalCode, string state, string city, string district, string street, int streetNumber, string complement, bool primaryAddress, Person person)
        {
            PostalCode = postalCode;
            State = state;
            City = city;
            District = district;
            Street = street;
            StreetNumber = streetNumber;
            Complement = complement;
            PrimaryAddress = primaryAddress;
            Person = person;
        }

        public string PostalCode { get; private set; }

        public string State { get; private set; }

        public string City { get; private set; }

        public string District { get; private set; }

        public string Street { get; private set; }

        public int StreetNumber { get; private set; }

        public string Complement { get; private set; }

        public bool PrimaryAddress { get; private set; }

        public virtual Person Person { get; private set; }

        public void UpdatePrimaryAddress(bool value)
            => PrimaryAddress = value;

        public void Update(string postalCode, string state, string city, string district, string street, int streetNumber, string complement, bool primaryAddress)
        {
            PostalCode = postalCode;
            State = state;
            City = city;
            District = district;
            Street = street;
            StreetNumber = streetNumber;
            Complement = complement;
            PrimaryAddress = primaryAddress;
        }
    }
}
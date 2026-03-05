using Connectly.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Connectly.Domain.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        
        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new DomainEmailInvalidException("Email inválido");

            Address = address.Trim().ToLower();

            if (Address.Length < 5)
                throw new DomainEmailInvalidException("Email menor que 5");

            if(!EmailRegex().IsMatch(Address))
                throw new DomainEmailInvalidException("Email inválido");
        }

        public string Address { get; } = string.Empty;
        public Verification Verification { get; private set; } = new();

        public void ResendVerification()
        {
            Verification = new Verification();
        }

        public static implicit operator string(Email email)
        {
            return email.ToString()!;
        }

        public static implicit operator Email(string address)
        {
            return new(address);
        }

        public override string ToString()
        {
            return Address.Trim().ToLower();
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}

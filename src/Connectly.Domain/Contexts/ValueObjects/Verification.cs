using Connectly.Domain.Exceptions;

namespace Connectly.Domain.ValueObjects
{
    public class Verification : ValueObject
    {
        public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();
        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
        public DateTime? VerifiedAt { get; private set; } = null!;
        public bool IsActive => VerifiedAt != null && ExpiresAt == null;

        public void Verify(string code)
        {
            if (IsActive)
                throw new DomainVerificationException("Esse item já foi ativado");

            if (ExpiresAt < DateTime.UtcNow)
                throw new DomainVerificationException("Este código já expirou");

            if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new DomainVerificationException("Código de verificação inválido");

            ExpiresAt = null!;
            VerifiedAt = DateTime.UtcNow;
        }
    }
}

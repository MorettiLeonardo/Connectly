using FluentValidation;

namespace Connectly.Application.Handlers.Posts.Requests.Validation
{
    public class ToggleLikeRequestValidator : AbstractValidator<ToggleLikeRequest>
    {
        public ToggleLikeRequestValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty()
                .NotNull();    

            RuleFor(x => x.PostId)
                .NotEmpty()
                .NotNull();
        }
    }
}

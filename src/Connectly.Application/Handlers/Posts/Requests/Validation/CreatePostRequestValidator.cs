
using FluentValidation;

namespace Connectly.Application.Handlers.Posts.Requests.Validation
{
    internal class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content is required.")
                .MaximumLength(280).WithMessage("Content cannot exceed 280 characters.")
                .MinimumLength(3).WithMessage("Content must be at least 3 characters.");

            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty();
        }
    }
}

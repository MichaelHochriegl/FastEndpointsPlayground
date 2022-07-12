using FluentValidation;

namespace Contract.Blogs.Create;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(Constants.BlogTitleMinLength)
            .MaximumLength(Constants.BlogTitleMaxLength);

        RuleFor(x => x.Content)
            .NotEmpty()
            .MinimumLength(Constants.BlogContentMinLength);
    }
}
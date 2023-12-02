using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Errors;

namespace JobResearchSystem.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var message = failures.Select(x => x.PropertyName + ":" + x.ErrorMessage).FirstOrDefault();

                    //throw new ValidationException(message);
                    throw new ValidationException(failures);

                    //var validationErrorResponse = new ApiValidationErrorResponse() { Errors = failures.Select(x => x.PropertyName + ":" + x.ErrorMessage).ToList() };

                    //return new BadRequestObjectResult(validationErrorResponse);
                }
            }
            return await next();
        }
    }
}

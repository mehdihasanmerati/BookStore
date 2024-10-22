using BookStore.DAL.DbContexts;
using BookStore.Model.Frameworks;
using MediatR;

namespace BookStore.BusinessLogic.Frameworks
{
    public abstract class BaseApplicationServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
    where TRequest : IRequest<ApplicationServiceResponse<TResult>>
    {
        protected readonly BookDbContext _context;
        private ApplicationServiceResponse<TResult> _response = new ApplicationServiceResponse<TResult> { };
        protected BaseApplicationServiceHandler(BookDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationServiceResponse<TResult>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await HandleRequest(request, cancellationToken);
            return _response;
        }

        protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

        public void AddError(string error)
        {
            _response.AddError(error);
        }

        public void AddResult(TResult result) => _response.Result = result;
    }
}

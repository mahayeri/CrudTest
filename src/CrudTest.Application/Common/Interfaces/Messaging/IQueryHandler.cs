using ErrorOr;
using MediatR;

namespace CrudTest.Application.Common.Interfaces.Messaging;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ErrorOr<TResponse>>
    where TQuery : IQuery<TResponse>
{
}

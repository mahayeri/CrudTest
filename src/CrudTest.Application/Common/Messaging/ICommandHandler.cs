using ErrorOr;
using MediatR;

namespace CrudTest.Application.Common.Messaging;
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, ErrorOr<TResponse>>
    where TCommand : ICommand<TResponse>
{
}

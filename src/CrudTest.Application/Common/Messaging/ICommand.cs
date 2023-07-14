using ErrorOr;
using MediatR;

namespace CrudTest.Application.Common.Messaging;

public interface ICommand<TResponse> : IRequest<ErrorOr<TResponse>> { }

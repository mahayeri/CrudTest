using ErrorOr;
using MediatR;

namespace CrudTest.Application.Common.Interfaces.Messaging;
public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>> { }

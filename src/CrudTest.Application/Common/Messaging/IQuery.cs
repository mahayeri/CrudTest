using ErrorOr;
using MediatR;

namespace CrudTest.Application.Common.Messaging;
public interface IQuery<TResponse> : IRequest<ErrorOr<TResponse>> { }

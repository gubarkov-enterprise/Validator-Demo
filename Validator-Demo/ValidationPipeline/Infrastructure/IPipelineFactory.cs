using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Infrastructure
{
    public interface IPipelineFactory<out TInput, in TContext> where TContext : IEnumerable<IValidationObjectAdapter<TInput>>
    {
        IPipelineService<TInput, TContext> Build(LinkedListNode<Pipeline> node);
    }
}
using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline
{
    public interface IPipelineService<out TInput, in TContext>
        where TContext : IEnumerable<IValidationObjectAdapter<TInput>>
    {
        void RunPipe(TContext context);
        Pipeline Rule { get; }
    }
}
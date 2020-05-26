using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline
{
    public abstract class ValidatorPipe<TInput, TContext> : IPipelineService<TInput, TContext>
        where TContext : IEnumerable<IValidationObjectAdapter<TInput>>
    {
        private readonly IPipelineService<TInput, TContext> _nextStep;


        protected TContext Context { get; set; }


        protected ValidatorPipe(IPipelineFactory<TInput, TContext> factory,
            LinkedListNode<Pipeline> node)
        {
            if (node != null)
                _nextStep = factory.Build(node);
        }

        protected virtual bool CanExecute => true;

        public virtual void RunPipe(TContext context)
        {
            Context = context;

            if (CanExecute)
                context.ForEach(Validate);

            _nextStep?.RunPipe(context);
        }

        public abstract Pipeline Rule { get; }

        protected abstract void Validate(IValidationObjectAdapter<TInput> input);
    }
}
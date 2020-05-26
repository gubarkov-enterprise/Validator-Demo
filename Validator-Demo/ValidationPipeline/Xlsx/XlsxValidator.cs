using System.Collections.Generic;
using System.Linq;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx
{
    public abstract class XlsxValidator<TInput, TContext> : ValidatorPipe<TInput, TContext>
        where TContext : IEnumerable<IValidationObjectAdapter<TInput>>
    {
        protected XlsxValidator(IPipelineFactory<TInput, TContext> factory, LinkedListNode<Pipeline> node) :
            base(factory, node)
        {
            if (node != null && node.List.ToArray().Any(Pipeline =>
                    Pipeline == Pipeline.REQUIRED ||
                    Pipeline == Pipeline.XOR))
                OptionalValueWarningDisabled = true;
        }

        protected bool OptionalValueWarningDisabled { get; }


        protected override bool CanExecute => ColumnValid();

        protected virtual bool ColumnValid() => true;

        protected virtual void Fail((string value, int rowIndex) cell, ValidationFail failType,
            FailLevel level = FailLevel.Critical)
        {
        }
    }
}
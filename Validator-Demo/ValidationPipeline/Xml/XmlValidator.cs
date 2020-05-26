using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;

namespace Validator_Demo.ValidationPipeline.Xml
{
    public abstract class XmlValidator : ValidatorPipe<string, XmlValidationContext>
    {
        protected XmlValidator(IPipelineFactory<string, XmlValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        private FailLevel FailLevel =>
            Context.Field
                .GetCustomAttributes<ValidationFailLevelAttribute>()
                .FirstOrDefault(attribute => attribute.Rule == Rule)
                .Out(out var failConfig) == null
                ? FailLevel.Critical
                : failConfig.Level;

        protected virtual void Fail(ValidationFail fail)
            => Context.Report.Add(Context.Field, Rule, FailLevel, fail);
    }
}
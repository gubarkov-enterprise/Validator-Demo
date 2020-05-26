using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Pipes
{
    public sealed class RequiredXmlPipe : XmlValidator
    {
        public RequiredXmlPipe(IPipelineFactory<string, XmlValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.REQUIRED;

        protected override void Validate(IValidationObjectAdapter<string> input)
        {
            if (string.IsNullOrEmpty(input.Value))
                Fail(ValidationFail.VALUE_MISSING);
        }
    }
}
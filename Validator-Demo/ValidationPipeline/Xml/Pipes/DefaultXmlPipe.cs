using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Pipes
{
    public sealed class DefaultXmlPipe : XmlValidator
    {
        public override Pipeline Rule => Pipeline.DEFAULT;

        public DefaultXmlPipe(IPipelineFactory<string, XmlValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        protected override void Validate(IValidationObjectAdapter<string> input)
        {
        }
    }
}
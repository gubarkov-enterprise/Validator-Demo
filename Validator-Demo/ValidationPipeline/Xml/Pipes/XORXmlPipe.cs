using System;
using System.Collections.Generic;
using System.Linq;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Pipes
{
    // ReSharper disable once InconsistentNaming
    public class XORXmlPipe : XmlValidator
    {
        public XORXmlPipe(IPipelineFactory<string, XmlValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.XOR;

        private Func<IValidationObjectAdapter<string>, bool> XorExists => adapter =>
            Context.AttributeProvider.XOR.All(xorField => !string.IsNullOrEmpty(adapter[xorField]));

        protected override void Validate(IValidationObjectAdapter<string> adapter)
        {
            if (string.IsNullOrEmpty(adapter.Value) && !XorExists(adapter))
                Fail(ValidationFail.XOR_FAIL);
        }
    }
}
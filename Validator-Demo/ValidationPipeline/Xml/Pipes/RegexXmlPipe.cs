using System.Collections.Generic;
using System.Text.RegularExpressions;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Pipes
{
    public class RegexXmlPipe : XmlValidator
    {
        public RegexXmlPipe(IPipelineFactory<string, XmlValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.REGEX;

        protected override void Validate(IValidationObjectAdapter<string> input)
        {
            if (string.IsNullOrEmpty(input.Value))
            {
                Fail(ValidationFail.OPTIONAL_VALUE_MISSING);
                return;
            }

            if (!new Regex(Context.AttributeProvider.CellPattern).IsMatch(input.Value))
                Fail(ValidationFail.REGEX_PATTERN_FAIL);
        }
    }
}
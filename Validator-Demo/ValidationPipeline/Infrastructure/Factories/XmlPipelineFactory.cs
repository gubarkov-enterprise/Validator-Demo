using System;
using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Xml;
using Validator_Demo.ValidationPipeline.Xml.Pipes;

namespace Validator_Demo.ValidationPipeline.Infrastructure.Factories
{
    public class XmlPipelineFactory : IPipelineFactory<string, XmlValidationContext>
    {
        public IPipelineService<string, XmlValidationContext> Build(
            LinkedListNode<Pipeline> node)
        {
            switch (node.Value)
            {
                case Pipeline.REQUIRED:
                    return new RequiredXmlPipe(this, node.Next);
                case Pipeline.REGEX:
                    return new RegexXmlPipe(this, node.Next);
                case Pipeline.XOR:
                    return new XORXmlPipe(this, node.Next);
                case Pipeline.DEFAULT:
                    return new DefaultXmlPipe(this, node.Next);
                default:
                    throw new Exception($"Pipe for type {node?.Value.ToString()} not found");
            }
        }
    }
}
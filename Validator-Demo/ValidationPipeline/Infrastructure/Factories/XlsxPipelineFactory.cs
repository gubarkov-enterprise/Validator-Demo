using System;
using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Xlsx;
using Validator_Demo.ValidationPipeline.Xlsx.Pipes;

namespace Validator_Demo.ValidationPipeline.Infrastructure.Factories
{
    public class XlsxPipelineFactory : IPipelineFactory<(string value, int rowIndex), XlsxValidationContext>
    {
        public IPipelineService<(string value, int rowIndex), XlsxValidationContext> Build(
            LinkedListNode<Pipeline> node)
        {
            switch (node.Value)
            {
                case Pipeline.REQUIRED:
                    return new RequiredPipe(this, node.Next);
                case Pipeline.REGEX:
                    return new RegexPipe(this, node.Next);
                case Pipeline.XOR:
                    return new XORPipe(this, node.Next);
                case Pipeline.OR:
                    return new ORPipe(this, node.Next);
                case Pipeline.DEFAULT:
                    return new DefaultPipe(this, node.Next);
                case Pipeline.POSITIVE_NUMBER:
                    return new PositiveNumberPipe(this, node.Next);
                case Pipeline.ROUND:
                    return new RoundPipe(this, node.Next);
                default:
                    throw new Exception($"Pipe for type {node?.Value.ToString()} not found");
            }
        }
    }
}
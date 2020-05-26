using System;

namespace Validator_Demo.ValidationPipeline.Infrastructure.Attributes
{
    public class PipelineDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
    }
}
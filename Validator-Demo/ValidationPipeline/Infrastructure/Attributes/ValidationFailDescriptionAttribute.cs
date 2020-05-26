using System;

namespace Validator_Demo.ValidationPipeline.Infrastructure.Attributes
{
    public class ValidationFailDescriptionAttribute : Attribute
    {
        public string Description { get; set; }
    }
}
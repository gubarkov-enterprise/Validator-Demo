using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;

namespace Validator_Demo.ValidationPipeline.Xlsx.Report
{
    public class ValidationIncident
    {
        public ValidationIncident(ValidationFail validationFail, FailLevel failLevel)
        {
            ValidationFail = validationFail;
            Reason = ValidationFail.GetAttributeOfType<ValidationFailDescriptionAttribute>().Description;
            FailLevel = failLevel;
        }

        public ValidationIncident(ValidationFail validationFail, FailLevel failLevel, string reason)
        {
            ValidationFail = validationFail;
            FailLevel = failLevel;
            Reason = reason;
        }

        public ValidationFail ValidationFail { get; set; }
        public FailLevel FailLevel { get; set; }
        public string Reason { get; }
    }
}
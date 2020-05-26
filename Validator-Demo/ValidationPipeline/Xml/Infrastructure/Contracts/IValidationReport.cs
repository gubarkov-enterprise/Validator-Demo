using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure;

namespace Validator_Demo.ValidationPipeline.Xml.Infrastructure.Contracts
{
    public interface IValidationReport
    {
        void Add(PropertyInfo field, Pipeline pipe, FailLevel level, ValidationFail fail);
    }
}
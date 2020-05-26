using System.Collections.Generic;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Infrastructure.
    Contracts
{
    public interface IXmlValidatorDataProvider<TInput>
    {
        IEnumerable<ValidationObjectAdapter<string>> Values(PropertyInfo field);
    }
}
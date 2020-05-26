using Validator_Demo.ValidationPipeline.Xml.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Report.
    Contracts
{
    public interface ITypedXmlValidatorDataProvider<TInput,out TModel> : IXmlValidatorDataProvider<TInput>
    {
        TModel CurrentObject { get; }
    }
}
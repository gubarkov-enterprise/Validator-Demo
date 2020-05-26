using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Xml.Infrastructure.Contracts;
using Validator_Demo.ValidationPipeline.Xml.Report.Models;

namespace Validator_Demo.ValidationPipeline.Xml.Report.Contracts
{
    public interface ITypedReport<TModel> : IValidationReport
    {
        IEnumerable<ValidationObject<TModel>> InvalidObjects { get; }
    }
}
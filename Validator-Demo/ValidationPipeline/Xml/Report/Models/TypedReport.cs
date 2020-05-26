using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Xml.Report.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Report.Models
{
    public class XmlReport<TModel> : ITypedReport<TModel>
    {
        private readonly ITypedXmlValidatorDataProvider<string, TModel> _provider;
        private readonly IList<ValidationObject<TModel>> _invalidObjects = new List<ValidationObject<TModel>>();

        public IEnumerable<ValidationObject<TModel>> InvalidObjects => _invalidObjects;

        public XmlReport(ITypedXmlValidatorDataProvider<string, TModel> provider)
        {
            _provider = provider;
        }

        public void Add(PropertyInfo field, Pipeline pipe, FailLevel level, ValidationFail fail)
        {
            var existing = _invalidObjects.FirstOrDefault(o => Equals(o.Object, _provider.CurrentObject));
            if (existing != null)
            {
                existing.InvalidFields.Add(new InvalidFieldData(field, pipe, level, fail));
            }
            else
            {
                _invalidObjects.Add(new ValidationObject<TModel>(_provider.CurrentObject, field, pipe, level, fail));
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;
using Validator_Demo.ValidationPipeline.Xml.Report.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml.Infrastructure.Impl
{
    public class XmlValidatorDataProvider<TInput, TModel> : ITypedXmlValidatorDataProvider<TInput, TModel>
    {
        protected readonly List<PropertyInfo> DefinedProperties;

        protected IEnumerable<TModel> Data { get; }

        public XmlValidatorDataProvider(IEnumerable<TModel> data)
        {
            Data = data;

            DefinedProperties = DeterminateProperties();
        }

        private List<PropertyInfo> DeterminateProperties()
            => typeof(TModel)
                .WhereContainsAttribute<ValidationColumnAttribute>()
                .ToList();

        private TModel _currentObject;

        public TModel CurrentObject => _currentObject;

        public IEnumerable<ValidationObjectAdapter<string>> Values(PropertyInfo field)
        {
            if (DefinedProperties.Contains(field))
            {
                foreach (var model in Data)
                {
                    _currentObject = model;


                    var adapter =
                        new ValidationObjectAdapter<string>(selector => GetPropertyValue(model, selector),
                            GetPropertyValue(model, field.Name));

                    yield return adapter;
                }
            }

            string GetPropertyValue(TModel model, string fieldSelector) =>
                model.GetType().GetProperty(fieldSelector)?.GetValue(model)?.ToString() ?? string.Empty;
        }
    }
}
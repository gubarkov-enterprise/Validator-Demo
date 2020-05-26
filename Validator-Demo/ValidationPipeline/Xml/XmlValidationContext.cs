using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;
using Validator_Demo.ValidationPipeline.Xml.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xml
{
    public class XmlValidationContext : IEnumerable<IValidationObjectAdapter<string>>
    {
        public XmlValidationContext(PropertyInfo field,
            IAttributeDataProvider attributeProvider, IXmlValidatorDataProvider<string> dataProvider,
            IValidationReport report)
        {
            Field = field;
            AttributeProvider = attributeProvider;
            DataProvider = dataProvider;
            Report = report;
        }

        public PropertyInfo Field { get; set; }

        public IValidationReport Report { get; set; }

        public IAttributeDataProvider AttributeProvider { get; set; }

        public IXmlValidatorDataProvider<string> DataProvider { get; set; }


        public IEnumerator<IValidationObjectAdapter<string>> GetEnumerator() =>
            DataProvider.Values(Field).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
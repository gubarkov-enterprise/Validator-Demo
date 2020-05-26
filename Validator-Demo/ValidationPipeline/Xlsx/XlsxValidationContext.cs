using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;
using Validator_Demo.ValidationPipeline.Xlsx.Infrastructure.Contracts;
using Validator_Demo.ValidationPipeline.Xlsx.Report;

namespace Validator_Demo.ValidationPipeline.Xlsx
{
    public sealed class XlsxValidationContext : IEnumerable<IValidationObjectAdapter<(string value, int rowIndex)>>
    {
        public XlsxValidationContext(XlsxValidationReport report, IAttributeDataProvider attributeProvider,
            IXlsxValidatorDataProvider dataProvider, PropertyInfo field)
        {
            Report = report;
            AttributeProvider = attributeProvider;
            DataProvider = dataProvider;
            Field = field;
        }

        public XlsxValidationReport Report { get; set; }
        public IAttributeDataProvider AttributeProvider { get; set; }
        public IXlsxValidatorDataProvider DataProvider { get; set; }

        public PropertyInfo Field { get; set; }

        public IEnumerator<IValidationObjectAdapter<(string value, int rowIndex)>> GetEnumerator()
        {
            return DataProvider
                .ColumnCells(Field.Name)
                .Select(tuple =>
                    new ValidationObjectAdapter<(string value, int rowIndex)>(selector =>
                            throw new NotImplementedException()
                        , tuple))
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
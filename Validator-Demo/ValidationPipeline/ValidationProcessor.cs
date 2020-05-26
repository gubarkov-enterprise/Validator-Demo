using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;
using Validator_Demo.ValidationPipeline.Xlsx;
using Validator_Demo.ValidationPipeline.Xlsx.Infrastructure.Contracts;
using Validator_Demo.ValidationPipeline.Xlsx.Report;
using Validator_Demo.ValidationPipeline.Xml;
using Validator_Demo.ValidationPipeline.Xml.Report.Contracts;
using Validator_Demo.ValidationPipeline.Xml.Report.Models;

namespace Validator_Demo.ValidationPipeline
{
    public class ValidationProcessor<TInput, TContext> where TContext : class, IEnumerable<IValidationObjectAdapter<TInput>>
    {
        private PropertyInfo[] RequiredProperties<TModel>()
            => typeof(TModel)
                .WhereContainsAttribute<ValidationColumnAttribute>()
                .ToArray();


        private readonly IPipelineFactory<TInput, TContext> _pipelineFactory;

        private Func<Pipeline[], Action<TContext>>
            ExecutePipe => sequence => context =>
            _pipelineFactory
                .Build(new LinkedList<Pipeline>(sequence).First)
                .RunPipe(context);


        private Attr FieldAttribute<Attr>(PropertyInfo field) where Attr : Attribute
            => field.GetCustomAttribute<Attr>();

        public ValidationProcessor(IPipelineFactory<TInput, TContext> factory)
        {
            _pipelineFactory = factory;
        }

        public XlsxValidationReport ValidateXlsx<TModel>(IXlsxValidatorDataProvider provider)
        {
            var validationReport = new XlsxValidationReport(provider.RecognizedFields);

            RequiredProperties<TModel>().ForEach(field =>
            {
                var attribute = FieldAttribute<ValidationColumnAttribute>(field);
                var context = new XlsxValidationContext(validationReport,
                    FieldAttribute<ValidationColumnAttribute>(field),
                    provider, field) as TContext;

                ExecutePipe(attribute.ValidatePipeline)(context);

                if (provider.ColumnExist(field.Name))
                    validationReport.ModelFieldsValidationDescription.TryAdd(provider.ColumnIndex(field.Name),
                        attribute.GetPipelineDescription());
            }
            );
            return validationReport;
        }

        public ITypedReport<TModel> ValidateFeedXml<TModel>(ITypedXmlValidatorDataProvider<string, TModel> provider)
        {
            var report = new XmlReport<TModel>(provider);
            RequiredProperties<TModel>()
                .ForEach(field =>
                {
                    var attribute = FieldAttribute<ValidationColumnAttribute>(field);
                    var context = new XmlValidationContext(field, attribute, provider, report) as TContext;
                    ExecutePipe(attribute.ValidatePipeline)(context);
                });
            return report;
        }
    }
}
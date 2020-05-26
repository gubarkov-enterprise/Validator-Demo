using System.Collections.Generic;
using System.Reflection;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;

namespace Validator_Demo.ValidationPipeline.Xml.Report.Models
{
    public class ValidationObject<TModel>
    {
        public ValidationObject(TModel model, PropertyInfo field, Pipeline pipe, FailLevel level,
            ValidationFail fail)
        {
            Object = model;
            InvalidFields.Add(new InvalidFieldData(field, pipe, level, fail));
        }

        public TModel Object { get; set; }


        public List<InvalidFieldData> InvalidFields { get; set; } = new List<InvalidFieldData>();
    }

    public class InvalidFieldData
    {
        public InvalidFieldData(PropertyInfo field, Pipeline pipe, FailLevel level, ValidationFail fail)
        {
            Field = field;
            Fail = pipe;
            Level = level;
            Reason = fail.GetEnumMemberAttribute<ValidationFailDescriptionAttribute>().Description;
        }


        public PropertyInfo Field { get; set; }
        public Pipeline Fail { get; set; }
        public FailLevel Level { get; set; }
        public string Reason { get; set; }
    }
}
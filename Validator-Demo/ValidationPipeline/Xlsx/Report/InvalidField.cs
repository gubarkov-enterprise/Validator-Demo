using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;

namespace Validator_Demo.ValidationPipeline.Xlsx.Report
{
    public class InvalidField
    {
        public InvalidField(int rowIndex, string fieldName, int columnIndex,
            ValidationFail validationFail, FailLevel failLevel = FailLevel.Critical)
        {
            RowIndex = rowIndex;
            FieldName = fieldName;
            ColumnIndex = columnIndex;
            Incidents = new List<ValidationIncident>
            {
                new ValidationIncident(validationFail, failLevel)
            };
        }

        public InvalidField(int rowIndex, string fieldName, int columnIndex,
            ValidationFail validationFail, string replacedValue, FailLevel failLevel = FailLevel.Critical)
        {
            RowIndex = rowIndex;
            FieldName = fieldName;
            ColumnIndex = columnIndex;
            ReplacedValue = replacedValue;
            Incidents = new List<ValidationIncident>
            {
                new ValidationIncident(validationFail, failLevel)
            };
        }


        public int RowIndex { get; }
        public int ColumnIndex { get; set; }

        public List<ValidationIncident> Incidents { get; set; }


        public string FieldName { get; }
        public string ReplacedValue { get; set; }
    }
}
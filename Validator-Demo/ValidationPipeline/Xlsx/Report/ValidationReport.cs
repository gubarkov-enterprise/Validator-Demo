using System.Collections.Generic;
using System.Linq;

namespace Validator_Demo.ValidationPipeline.Xlsx.Report
{
    public class XlsxValidationReport
    {
        public XlsxValidationReport()
        {
        }

        public XlsxValidationReport(List<int> recognizedFields)
        {
            RecognizedFields = recognizedFields;
        }

        public bool Valid => !(InvalidFields.Any(pair =>
                                   pair.Value.Incidents.Any(incident => (int) incident.FailLevel > 1)) ||
                               Messages.Any());

        public Dictionary<(int rowIndex, int columnIndex), InvalidField> InvalidFields { get; set; } =
            new Dictionary<(int rowIndex, int columnIndex), InvalidField>();

        public List<string> Messages { get; set; } = new List<string>();

        public List<int> RecognizedFields { get; set; } = new List<int>();

        public Dictionary<int, string[]> ModelFieldsValidationDescription { get; set; } =
            new Dictionary<int, string[]>();

        public void ReportInvalidField(InvalidField field)
        {
            if (!InvalidFields.TryAdd((field.RowIndex, field.ColumnIndex), field))
            {
                InvalidFields[(field.RowIndex, field.ColumnIndex)].Incidents.AddRange(field.Incidents);
            }
        }
    }
}
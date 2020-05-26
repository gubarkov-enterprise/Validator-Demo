using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Validator_Demo.ValidationPipeline.Xlsx.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Infrastructure.Impl
{
    [Obsolete]
    public class XlsxValidatorDataProvider<T> : IXlsxValidatorDataProvider where T : class
    {
        private readonly DataSet _data;
        private readonly Dictionary<string, int> _columns;
        private readonly int _startRow;

        public XlsxValidatorDataProvider(DataSet data, Dictionary<string, int> columns, int startRow = 1)
        {
            _data = data;
            _columns = columns;
            _startRow = startRow;
        }

        public IEnumerable<(string value, int rowIndex)> ColumnCells(string column)
        {
            for (var rowIndex = _startRow; rowIndex < _data.Tables[0].Rows.Count; rowIndex++)
            {
                if (!_columns.ContainsKey(column.ToLower()))
                    yield break;
                var columnIndex = _columns[column.ToLower()];
                var row = _data.Tables[0].Rows[rowIndex][columnIndex].ToString();
                yield return (row, rowIndex + 1);
            }
        }

        public bool ColumnExist(string column)
        {
            return _columns.Any(pair => pair.Key.Equals(column, StringComparison.OrdinalIgnoreCase));
        }

        public int ColumnIndex(string column)
        {
            return _columns[column.ToLower()];
        }

        public string GetCell(int rowIndex, int columnIndex)
        {
            return _data.Tables[0].Rows[rowIndex - 1][columnIndex].ToString();
        }

        public List<int> RecognizedFields => _columns.Select(pair => pair.Value).ToList();
    }
}
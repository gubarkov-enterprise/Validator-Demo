using System;
using System.Collections.Generic;

namespace Validator_Demo.ValidationPipeline.Xlsx.Infrastructure.Contracts
{
    [Obsolete]
    public interface IXlsxValidatorDataProvider
    {
        IEnumerable<(string value, int rowIndex)> ColumnCells(string column);
        bool ColumnExist(string column);
        int ColumnIndex(string column);
        string GetCell(int rowIndex, int columnIndex);
        List<int> RecognizedFields { get; }
    }
}
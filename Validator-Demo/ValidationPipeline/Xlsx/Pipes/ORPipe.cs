using System;
using System.Collections.Generic;
using System.Linq;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Pipes
{
    // ReSharper disable once InconsistentNaming
    public sealed class ORPipe : WholeSaleXlsxValidator
    {
        private Func<int, string, string> GetColumnValue => (rowIndex, columnName) =>
            Context.DataProvider.GetCell(rowIndex, Context.DataProvider.ColumnIndex(columnName));

        private Func<bool> CurrentColumnExist => () => Context.DataProvider.ColumnExist(Context.Field.Name);

        public ORPipe(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.OR;

        protected override void Validate(IValidationObjectAdapter<(string value, int rowIndex)> input)
        {
            if (CurrentColumnExist())
            {
                if (CurrentValueDefined())
                {
                    return;
                }

                if (!OrValuesDefined())
                {
                    Fail(input.Value, ValidationFail.XOR_FAIL);
                    return;
                }
            }

            if (OrValuesDefined())
                return;

            Fail(input.Value, ValidationFail.XOR_FAIL);

            string CurrentColumnCellValue() => GetColumnValue(input.Value.rowIndex, Context.Field.Name);

            bool OrValuesDefined() =>
                Context.AttributeProvider.OR.All(or => Context.DataProvider.ColumnExist(or)) &&
                Context.AttributeProvider.OR.All(or =>
                    !string.IsNullOrEmpty(GetColumnValue(input.Value.rowIndex, or)));

            bool CurrentValueDefined() => !string.IsNullOrEmpty(CurrentColumnCellValue());
        }

        protected override bool ColumnValid()
        {
            if (CurrentColumnExist() ||
                Context.AttributeProvider.XOR.All(xor => Context.DataProvider.ColumnExist(xor))
            )
                return true;

            if (Context.AttributeProvider.XOR.Any(xor => !Context.DataProvider.ColumnExist(xor)))
            {
                Context.Report.Messages.Add(
                    $"Столбец {Context.Field.Name} или {Context.AttributeProvider.XOR} должен быть указан");
            }

            return false;
        }
    }
}
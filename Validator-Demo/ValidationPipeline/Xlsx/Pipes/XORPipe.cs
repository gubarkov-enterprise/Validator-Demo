using System;
using System.Collections.Generic;
using System.Linq;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Pipes
{
    // ReSharper disable once InconsistentNaming
    public sealed class XORPipe : WholeSaleXlsxValidator
    {
        private Func<int, string, string> GetColumnValue => (rowIndex, columnName) =>
            Context.DataProvider.GetCell(rowIndex, Context.DataProvider.ColumnIndex(columnName));

        private Func<bool> CurrentColumnExist => () => Context.DataProvider.ColumnExist(Context.Field.Name);

        public XORPipe(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.XOR;

        protected override void Validate(IValidationObjectAdapter<(string value, int rowIndex)> input)
        {
            if (CurrentColumnExist())
            {
                if (CurrentValueDefined())
                {
                    if (XorValuesDefined())
                        Fail(input.Value, ValidationFail.XOR_VALUES_WARNING, FailLevel.Warning);
                    return;
                }

                if (!XorValuesDefined())
                {
                    Fail(input.Value, ValidationFail.XOR_FAIL);
                    return;
                }
            }

            if (XorValuesDefined())
                return;

            Fail(input.Value, ValidationFail.XOR_FAIL);

            string CurrentColumnCellValue() => GetColumnValue(input.Value.rowIndex, Context.Field.Name);

            bool XorValuesDefined() =>
                Context.AttributeProvider.XOR.All(xor => Context.DataProvider.ColumnExist(xor)) &&
                Context.AttributeProvider.XOR.All(xor =>
                    !string.IsNullOrEmpty(GetColumnValue(input.Value.rowIndex, xor)));

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
using System;
using System.Linq;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Infrastructure.Attributes
{
    /// <inheritdoc />
    /// <summary>
    /// Атрибут валидации
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidationColumnAttribute : Attribute, IAttributeDataProvider
    {
        /// <summary>
        /// Идентифицирует столбец по регулярному выражению
        /// <remarks>
        /// Используется только совместно с конвеером валидации
        /// </remarks>
        /// </summary>
        public string ColumnPattern { get; set; } = ".*";

        /// <summary>
        /// Указывает на индекс строки, в которой находится заголовок. По умолчанию значение равно 0
        /// </summary>
        public int ColumnRowIndex { get; set; } = 0;

        /// <summary>
        /// Задаёт регулярное выражение для ячейки
        /// <remarks>
        /// Используется только совместно с конвеером валидации
        /// </remarks>
        /// </summary>
        public string CellPattern { get; set; } = string.Empty;

        /// <summary>
        /// Указывает ячейку в таблице, для которого применима логическая операция
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public string[] XOR { get; set; }
        public string[] OR { get; set; }

        /// <summary>
        /// Конвеер валидации, указывается в порядке выполнения
        /// </summary>
        public Pipeline[] ValidatePipeline { get; set; } = new[] {Pipeline.DEFAULT};

        public string[] GetPipelineDescription()
        {
            return ValidatePipeline.Select(pipeline =>
                    (pipeline, pipeline.GetAttributeOfType<PipelineDescriptionAttribute>().Description))
                .Select(tuple =>
                {
                    switch (tuple.pipeline)
                    {
                        case Pipeline.REQUIRED:
                            break;
                        case Pipeline.REGEX:
                            return string.Format(tuple.Description, CellPattern);
                        case Pipeline.XOR:
                            return string.Format(tuple.Description, XOR);
                        case Pipeline.OR:
                            return string.Format(tuple.Description, OR);
                    }

                    return tuple.Description;
                })
                .ToArray();
        }
    }
}
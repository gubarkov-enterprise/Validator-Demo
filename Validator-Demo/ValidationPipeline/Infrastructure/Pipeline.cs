
using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;

namespace Validator_Demo.ValidationPipeline.Infrastructure
{
    public enum Pipeline
    {
        /// <summary>
        /// Положительное число
        /// </summary>
        [PipelineDescription(Description = "Значение должно быть положительным числом или нулём")]
        // ReSharper disable once InconsistentNaming
        POSITIVE_NUMBER,

        /// <summary>
        /// Столбец и значения должны быть указаны
        /// </summary>
        [PipelineDescription(Description = "Обязательный столбец")]
        // ReSharper disable once InconsistentNaming
        REQUIRED,

        /// <summary>
        /// Базовая валидация ячейки используя регулярное выражение. Должен быть указан параметр Pattern атрибута
        /// </summary>
        [PipelineDescription(Description = "Значение ячейки должно соответствовать формату: {0}")]
        // ReSharper disable once InconsistentNaming
        REGEX,

        /// <summary>
        /// Указывает, что к полю необходимо применить логическую операцию.
        /// <remarks>
        /// Используется совместно с полем XOR аттрибута
        /// </remarks>
        /// </summary>
        [PipelineDescription(Description =
            "Выбранный столбец взаимоисключащий со столбцом {0}. Наличение значения в одном из двух столбцов обязательно")]
        // ReSharper disable once InconsistentNaming
        XOR,

        [PipelineDescription(Description =
            "Наличие значения в одном из двух столбцов обязательно, значения не взаимоисключающие")]
        // ReSharper disable once InconsistentNaming
        OR,

        /// <summary>
        /// Округляет значения для представления
        /// </summary>
        [PipelineDescription(Description = "Значение округлено")]
        // ReSharper disable once InconsistentNaming
        ROUND,

        // ReSharper disable once InconsistentNaming
        [PipelineDescription(Description = "Опциональный столбец")]
        DEFAULT
    }
}
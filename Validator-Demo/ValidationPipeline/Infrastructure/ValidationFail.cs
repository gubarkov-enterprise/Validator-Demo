using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;

namespace Validator_Demo.ValidationPipeline.Infrastructure
{
    public enum ValidationFail
    {
        [ValidationFailDescription(Description = "Ячейка должна содержать значение")]
        // ReSharper disable once InconsistentNaming
        VALUE_MISSING,

        [ValidationFailDescription(Description = "Значение было округлено")]
        // ReSharper disable once InconsistentNaming
        VALUE_ROUNDED,

        [ValidationFailDescription(Description = "Не указано значение опциональной ячейки")]
        // ReSharper disable once InconsistentNaming
        OPTIONAL_VALUE_MISSING,

        [ValidationFailDescription(Description = "Обязательный столбец отсутствует")]
        // ReSharper disable once InconsistentNaming
        COLUMN_MISSING,

        [ValidationFailDescription(Description = "Ячейка не соответсвует формату")]
        // ReSharper disable once InconsistentNaming
        REGEX_PATTERN_FAIL,

        [ValidationFailDescription(Description = "Значение ячейки и её альтернативной ячейки отсутствует")]
        // ReSharper disable once InconsistentNaming
        XOR_FAIL,

        [ValidationFailDescription(Description = "Указаны оба значения взаимоисключающих столбцов")]
        // ReSharper disable once InconsistentNaming
        XOR_VALUES_WARNING,

        [ValidationFailDescription(Description = "Значение не является положительным числом")]
        // ReSharper disable once InconsistentNaming
        NOT_POSITIVE_NUMBER
    }
}
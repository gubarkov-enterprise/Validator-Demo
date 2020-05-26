namespace Validator_Demo.ValidationPipeline.Infrastructure.Contracts
{
    public interface IAttributeDataProvider
    {
        /// <summary>
        /// Задаёт регулярное выражение для ячейки
        /// </summary>
        string CellPattern { get; set; }

        /// <summary>
        /// Указывает ячейку в таблице, для которого применима логическая операция
        /// </summary>
        // ReSharper disable once InconsistentNaming
        string[] XOR { get; set; }
        string[] OR { get; set; }
    }
}
using System;

namespace Validator_Demo.ValidationPipeline.Infrastructure.Contracts
{
    public interface IValidationObjectAdapter<out TInput>
    {
        TInput Value { get; }
        TInput this[string property] { get; }
    }

    public class ValidationObjectAdapter<TInput> : IValidationObjectAdapter<TInput>
    {
        private readonly Func<string, TInput> _fieldSelector;

        public ValidationObjectAdapter(Func<string, TInput> fieldSelector, TInput value)
        {
            _fieldSelector = fieldSelector;
            Value = value;
        }

        public TInput Value { get; }

        public TInput this[string property] => _fieldSelector(property);
    }
}
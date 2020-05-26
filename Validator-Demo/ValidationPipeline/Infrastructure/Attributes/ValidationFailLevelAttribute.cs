using System;

namespace Validator_Demo.ValidationPipeline.Infrastructure.Attributes
{
    /// <summary>
    /// Коррелирует правила валидации и степень ошибки
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ValidationFailLevelAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule">Правила, для которого задается степень ошибки</param>
        /// <param name="level">Степень ошибки</param>
        public ValidationFailLevelAttribute(Pipeline rule, FailLevel level)
        {
            Rule = rule;
            Level = level;
        }

        public Pipeline Rule { get; set; }
        public FailLevel Level { get; set; }
    }
}
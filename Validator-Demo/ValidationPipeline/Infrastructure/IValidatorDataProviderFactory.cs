using System.IO;
using Validator_Demo.ValidationPipeline.Xlsx.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Infrastructure
{
    public interface IValidatorDataProviderFactory
    {
        IXlsxValidatorDataProvider CreateProvider<T>(UploadFiletype source, Stream data, int rowStart) where T : class;
    }
}
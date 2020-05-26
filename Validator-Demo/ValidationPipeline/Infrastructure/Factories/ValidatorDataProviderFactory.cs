namespace Validator_Demo.ValidationPipeline.Infrastructure.Factories
{
    //public class ValidatorDataProviderFactory : IValidatorDataProviderFactory
    //{
    //    private Func<string, string, bool> IsMatch => (pattern, target) => new Regex(pattern).IsMatch(target);

    //    private Dictionary<string, int> ToDictionary(IEnumerable<(KeyValuePair<string, int> column, bool exists)> pairs)
    //        => new Dictionary<string, int>(pairs.Where(tuple => tuple.exists)
    //            .Select(tuple => tuple.column));

    //    public IXlsxValidatorDataProvider CreateProvider<T>(UploadFiletype source, Stream stream, int rowStart)
    //        where T : class
    //    {
    //        switch (source)
    //        {
    //            case UploadFiletype.Unknown:
    //                break;
    //            case UploadFiletype.YML:
    //                break;
    //            case UploadFiletype.EXCEL:
    //                using (var reader = ExcelReaderFactory.CreateReader(stream))
    //                    return new XlsxValidatorDataProvider<T>(reader.AsDataSet(),
    //                        DefaultColumnBehavior<T>(reader.AsDataSet()), rowStart);
    //            case UploadFiletype.CSV:
    //                break;
    //        }

    //        throw new Exception($"no data provider found for {source} extension");
    //    }

    //    private Dictionary<string, int> DefaultColumnBehavior<T>(DataSet data)
    //    {
    //        return typeof(T)
    //            .WhereContainsAttribute<ValidationColumnAttribute>()
    //            .Select(ColumnSelector)
    //            .Map(ToDictionary);

    //        (KeyValuePair<string, int> column, bool exists) ColumnSelector(PropertyInfo field)
    //        {
    //            for (var columnIndex = 0; columnIndex < data.Tables[0].Rows[0].ItemArray.Length; columnIndex++)
    //            {
    //                var attribute = field.GetCustomAttribute<ValidationColumnAttribute>();
    //                if (IsMatch(
    //                    attribute.ColumnPattern,
    //                    data.Tables[0].Rows[attribute.ColumnRowIndex].ItemArray[columnIndex].ToString().ToLower()
    //                ))
    //                    return (new KeyValuePair<string, int>(field.Name.ToLower(), columnIndex), true);
    //            }

    //            return (default, false);
    //        }
    //    }
    //}
}
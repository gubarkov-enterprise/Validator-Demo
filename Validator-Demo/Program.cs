using System;
using System.Collections.Generic;
using ConsoleTables;
using Newtonsoft.Json;
using Validator_Demo.Models;
using Validator_Demo.ValidationPipeline;
using Validator_Demo.ValidationPipeline.Infrastructure.Factories;
using Validator_Demo.ValidationPipeline.Xml;
using Validator_Demo.ValidationPipeline.Xml.Infrastructure.Impl;
using Validator_Demo.ValidationPipeline.Xml.Report.Contracts;

namespace Validator_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var rawData = RetrieveDataMock();
            var report = Validate(rawData);

            DrawReport(report);

            Console.ReadKey();
        }

        private static void DrawReport(ITypedReport<Book> report) =>
            report.InvalidObjects.ForEach(entity =>
            {
                Console.WriteLine($"Object:{JsonConvert.SerializeObject(entity.Object)}");
                ConsoleTable
                    .From(entity.InvalidFields)
                    .Write(Format.Alternative);
            });

        private static List<Book> RetrieveDataMock() =>
            new List<Book>
            {
                new Book {Title = "Head First", AuthorSite = "https://someurl.ru"},
                new Book {Title = "Rapid Development", AuthorSite = ""},
                new Book {Title = "Any Richter", AuthorSite = "not url"},
                new Book {Title = "", AuthorSite = "https://anotherurl.ru"},
                new Book {Title = "", AuthorSite = ""},
            };

        private static ITypedReport<T> Validate<T>(List<T> rawData)
        {
            var factory = new XmlPipelineFactory();
            var provider = new XmlValidatorDataProvider<string, T>(rawData);
            var validator = new ValidationProcessor<string, XmlValidationContext>(factory);

            return validator.ValidateFeedXml(provider);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Core.src.Entity;

namespace EcomShop.Api.Helpers
{
    public static class CsvHelper
    {
        public static List<Category> ReadCategoriesFromCsv(string filePath)
        {
            var categories = new List<Category>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length == 4 && int.TryParse(values[0], out int id))
                    {
                        categories.Add(new Category
                        {
                            Id = id,
                            Name = values[1],
                            Description = values[2],
                            Image = values[3]
                        });
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data in CSV: {line}");
                    }
                }
            }

            return categories;
        }
    }

}
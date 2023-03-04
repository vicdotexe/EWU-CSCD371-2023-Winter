using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private List<string> _rows;
        private Dictionary<string, int> _indices;

        public SampleData(string filePath)
        {
            IEnumerable<string> lines = File.ReadLines(filePath);

            _rows = lines.Skip(1).ToList();

            int i = 0;
            _indices = lines.First().Split(",").ToDictionary(key => key, key => i++);
        }

        // 1.
        public IEnumerable<string> CsvRows => _rows;


        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows.Select(row => row.Split(",")[6]).Distinct().OrderBy(name => name);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => GetUniqueSortedListOfStatesGivenCsvRows().Aggregate((all, state) => $"{all},{state}");

        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select((row, index) =>
        {
            string[] split = row.Split(',');

            if (row.Split(',') is [string id, string first, string last, string email, string street, string city,
                string state, string zip])
            {
                Address address = new (street, city, state, zip);
                return new Person(first, last, address, email);
            }

            throw new FormatException($"Invalid format at row {index}");

        });

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => People.Where(person => filter(person.EmailAddress))
            .Select(person => (person.FirstName, person.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => People.Select(person => person.Address.State).Distinct()
            .OrderBy(state => state).Aggregate((all, state) => $"{all},{state}");

    }
}

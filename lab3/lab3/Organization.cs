using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace lab3
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        private readonly List<Worker> _workers = new List<Worker>();
        private double _totalSalary;

        /// <summary>
        /// Среднемесячная зарплата по организации
        /// </summary>
        public double TotalSalary
        {
            get 
            {
                return Math.Round(_totalSalary / (double)_workers.Count, 2);
            }
            set
            {
                _totalSalary = value;
            }
        }

        /// <summary>
        /// Добавить работника
        /// </summary>
        public void Add(Worker worker)
        {
            if (worker == null || worker.Type == WorkerType.None
                || string.IsNullOrEmpty(worker.Ident))
            {
                throw new ArgumentException(nameof(worker));
            }

            _workers.Add(worker);
            _totalSalary += worker.Salary;
        }

        /// <summary>
        /// Весь список работников
        /// </summary>
        public IEnumerable<Worker> GetWorkers()
        {
            return _workers;
        }


        private class BySalaryComparer : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                return x.Salary.CompareTo(y.Salary) != 0 ? y.Salary.CompareTo(x.Salary) : x.Name.CompareTo(y.Name);
            }
        }

        /// <summary>
        /// Отсортировать по зарплате
        /// </summary>
        public void SortBySalary()
        {
            _workers.Sort(new BySalaryComparer());
        }


        /// <summary>
        /// Сериализовать в XML-файл
        /// </summary>
        public void Toxml(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Worker>));

            using (var stream = File.OpenWrite(fileName))
            {
                serializer.Serialize(stream, _workers);
                stream.Flush();
            }
        }

        /// <summary>
        /// Десериализовать из ХML-файла
        /// </summary>
        public static Organization FromXml(string fileName)
        {
            var organization = new Organization();
            var serializer = new XmlSerializer(typeof(List<Worker>));

            using (var stream = File.OpenRead(fileName))
            {
                var workers = serializer.Deserialize(stream) as IEnumerable<Worker>;
                if (workers != null) organization._workers.AddRange(workers);
            }

            double total = 0;
            foreach (var worker in organization._workers)
                total += worker.Salary;
            organization.TotalSalary = total;

            return organization;
        }
    }

}

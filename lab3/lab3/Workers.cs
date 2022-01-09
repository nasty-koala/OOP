using System.Collections.Generic;
using System.Xml.Serialization;

namespace lab3
{
    public enum WorkerType
    {
        None,
        Director,
        Manager,
        Common
    }

    /// <summary>
    /// Базовый абстрактный класс 'Работник'
    /// </summary>
    [XmlInclude(typeof(HourlyWorker))]
    [XmlInclude(typeof(FixPayWorker))]
    public abstract class Worker
    {
        private static readonly Dictionary<WorkerType, double> _bonuses =  //премия
            new Dictionary<WorkerType, double>
            {
                [WorkerType.Director] = 5000,
                [WorkerType.Manager] = 3000,
                [WorkerType.Common] = 1000
            };

        protected WorkerType _workerType;
        protected string _name;
        protected double _bonus;

        protected Worker() { }

        protected Worker(WorkerType type, string ident, string name)
        {
            Type = type;
            Ident = ident;
            Name = name;
        }

        /// <summary>
        /// Тип работника (определяет размер премии)
        /// </summary>
        public WorkerType Type
        {

            get { return _workerType; }
            set
            {
                _workerType = value;
                _bonus = _bonuses[_workerType];
            }
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public string Ident { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Среднемесячная зарплата (переопределяется в наследниках)
        /// </summary>
        public abstract double Salary { get; }
    }



    /// <summary>
    /// Почасовая оплата
    /// </summary>
    public class HourlyWorker : Worker
    {
        private const double K = 20.8 * 8;

        public HourlyWorker() { }

        public HourlyWorker(WorkerType type, string ident, string name, double bet)
            : base(type, ident, name)
        {
            Bet = bet;
        }

        /// <summary>
        /// Почасовая ставка
        /// </summary>
        public double Bet { get; set; }

        public override double Salary
        {
            get { return K * Bet + _bonus; }
        }
    }



    /// <summary>
    /// Фиксированная оплата
    /// </summary>
    public class FixPayWorker : Worker
    {
        public FixPayWorker() { }

        public FixPayWorker(WorkerType type, string ident, string name, double fixSalary)
            : base(type, ident, name)
        {
            FixSalary = fixSalary;
        }

        /// <summary>
        /// Фиксированная зарплата
        /// </summary>
        public double FixSalary { get; set; }

        public override double Salary
        {
            get { return FixSalary + _bonus; }
        }
    }
}

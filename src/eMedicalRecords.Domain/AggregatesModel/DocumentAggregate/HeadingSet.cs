using System.Collections.Generic;
using eMedicalRecords.Domain.SeedWorks;

namespace eMedicalRecords.Domain.AggregatesModel.DocumentAggregate
{
    public class HeadingSet : Entity
    {
        private readonly List<Heading> _headings;
        private bool _isDefault;
        private string _name;
        
        public IReadOnlyCollection<Heading> Headings => _headings.AsReadOnly();

        protected HeadingSet()
        {
            _headings = new List<Heading>();
            _isDefault = false;
        }

        public HeadingSet(string name)
        {
            _name = name;
        }
        
        
    }
}
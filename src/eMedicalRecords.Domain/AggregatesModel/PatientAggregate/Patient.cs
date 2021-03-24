using System;
using eMedicalRecords.Domain.Events;
using eMedicalRecords.Domain.SeedWorks;

namespace eMedicalRecords.Domain.AggregatesModel.PatientAggregate
{
    public class Patient : Entity, IAggregateRoot
    {
        private string _identityNo;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private string _email;
        private string _phoneNumber;
        private DateTime _dateOfBirth;
        private bool _hasInsurance;
        private string _description;

        public PatientAddress PatientAddress { get; private set; }
        
        public IdentityType IdentityType { get; private set; }
        private int _identityTypeId;
        
        public string FullName => _lastName + ' ' + _middleName + ' ' + _firstName;

        protected Patient()
        {
            _hasInsurance = false;
        }

        public Patient(string identityNo, int identityTypeId, string firstName, string lastName, string middleName, string email, string phoneNumber,
            DateTime dateOfBirth, PatientAddress patientAddress, bool hasInsurance, string description)
        {
            _identityNo = identityNo;
            _identityTypeId = identityTypeId;
            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;
            _email = email;
            _phoneNumber = phoneNumber;
            _dateOfBirth = dateOfBirth;
            PatientAddress = patientAddress;
            _hasInsurance = hasInsurance;
            _description = description;
            
            AddPatientAddedDomainEvent(identityNo, email);
        }

        private void AddPatientAddedDomainEvent(string identityNo, string email)
        {
            var patientAddedDomainEvent = new PatientAddedDomainEvent(this, identityNo, email);
            AddDomainEvent(patientAddedDomainEvent);
        }

    }
}
using System.Data;

namespace FinalProject
{
    public class Student
    {        
        private string _phoneNumber;
        private string _email;
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (_phoneNumber == "")
                {
                    throw new ArgumentException("PhoneNumber should be filled in");
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email == "")
                {
                    throw new ArgumentException("Email should be filled in");
                }
            }
        }

        public Student(string lastName, string firstName, string patronymic, string phoneNumber, string email)
        {
            Id = IdGenerator.GetNextId();
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _email = email;
        }

        public override string ToString()
        {
            return $"{Id}. {LastName} {FirstName} {Patronymic}, phone number: {_phoneNumber}, e-mail: {_email}";
        }
    }
}

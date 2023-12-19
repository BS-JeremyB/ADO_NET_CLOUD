using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXO_ADO_NET_CLOUD.Entities
{
    public class Student
    {
        public Student(string firstName, string lastName, DateTime birthDate, int yearResult, int sectionId, bool active)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            YearResult = yearResult;
            SectionId = sectionId;
            Active = active;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int YearResult { get; set; }
        public int SectionId { get; set; }
        public bool Active { get; set; }


        public override string ToString()
        {
            return $"Id : {Id}\n" +
                   $"Prenom : {FirstName}\n" +
                   $"Nom : {LastName}\n" +
                   $"Date de Naissance : {BirthDate}\n" +
                   $"Note : {YearResult}\n" +
                   $"Section : {SectionId}\n" +
                   $"Status : {Active}";
        }
    }
}

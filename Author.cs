using System;

namespace LibrarySystem.Models
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Author(string firstName, string lastName, DateTime? dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > 200)
                throw new ArgumentException("First name cannot be empty and must be less than 200 characters");

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > 200)
                throw new ArgumentException("Last name cannot be empty and must be less than 200 characters");

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}

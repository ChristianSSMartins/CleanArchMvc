using System;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        // Properties 
        public string? Name { get; private set; }
        public ICollection<Product>? Products { get; set; }

        // Constructors
        public Category(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        // Public Methods
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        // Private Methods
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");
            Name = name;
        }
    }
}

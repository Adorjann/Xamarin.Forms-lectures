using System;

namespace FirstMobileApp.Models
{
    public class Note
    {
        public Note(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new InvalidOperationException(nameof(title));
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new InvalidOperationException(nameof(description));
            }
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
    }
}
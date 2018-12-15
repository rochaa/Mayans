using System;
using System.Collections.Generic;

namespace Mayans.Domain._Base
{
    public class DomainException : ArgumentException
    {
        public List<string> Messages { get; set; }

        public DomainException(List<string> messages) : base (string.Join(" --- ", messages))
        {
            Messages = messages;
        }

        internal void WithMessage(object word1Invalid)
        {
            throw new NotImplementedException();
        }
    }
}
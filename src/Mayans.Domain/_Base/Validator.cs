using System.Collections.Generic;
using System.Linq;

namespace Mayans.Domain._Base
{
    public class Validator
    {
        private List<string> messages;

        public Validator()
        {
            messages = new List<string>();
        }

        public static Validator New()
        {
            return new Validator();
        }

        public Validator When(bool haveError, string message)
        {
            if (haveError)
                messages.Add(message);
            
            return this;
        }

        public void ShootExceptionExists()
        {
            if (messages.Any())
                throw new DomainException(messages);
        }
    }
}
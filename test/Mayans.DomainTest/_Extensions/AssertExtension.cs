using Mayans.Domain._Base;
using Xunit;

namespace Mayans.DomainTest._Extensions
{
    public static class AssertExtension
    {
        public static void WithMessage(this DomainException exception, string message)
        {
            if (exception.Messages.Contains(message))
                Assert.True(true);
            else
                Assert.False(true, $"Expected message '{message}'");
        }
    }
}
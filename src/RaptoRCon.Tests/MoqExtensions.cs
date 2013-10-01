using Moq.Language;
using Moq.Language.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaptoRCon.Tests
{
    public static class MoqExtensions
    {
        public static IReturnsResult<TMock> ReturnsAsync<TMock, TResult>(
            this IReturns<TMock, Task<TResult>> setup, TResult value)
            where TMock : class
        {
            return setup.Returns(Task.FromResult(value));
        }
    }
}

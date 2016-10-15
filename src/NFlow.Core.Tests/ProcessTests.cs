using System.Threading.Tasks;
using NUnit.Framework;

namespace NFlow.Core.Tests
{
    [TestFixture]
    internal class ProcessTests
    {
        [Test]
        public async Task StartAsyncn()
        {
            var process = new Process();

            var task = process.RunAsync();

            task.Wait();

        }
    }
}

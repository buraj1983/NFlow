using System;
using System.Threading.Tasks;

namespace NFlow.Core
{
    public interface IProcess<TResult> where TResult : ProcessResult
    {
        Guid Id { get; }

        Task<TResult> RunAsync();
    }

    public enum ProcessStatus
    {
        Completed = 1,

        //Faulted
        //Canceled
        //Closed
        //Completed
    }
}
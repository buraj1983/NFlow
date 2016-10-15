using System;
using System.Activities;
using System.Activities.Statements;
using System.Threading.Tasks;

namespace NFlow.Core
{
    public class Process<TProcessResult> : IProcess<TProcessResult> where TProcessResult : ProcessResult
    {
        public Process(Guid processId)
        {
            Id = processId;
        }

        public Process() : this(Guid.NewGuid())
        {
        }

        public Guid Id { get; }

        public Task<TProcessResult> RunAsync()
        {
            var tcs = new TaskCompletionSource<TProcessResult>();

            var workflow = new WorkflowApplication(
                new Delay() { Duration = new InArgument<TimeSpan>((c) => new TimeSpan(0, 0, 15))}
            );

            workflow.Completed = args =>
            {
                tcs.SetResult(new ProcessResult() as TProcessResult);
            };
            workflow.Idle = args =>
            {
                //tcs.SetResult(new ProcessResult() as TProcessResult);
            };
            workflow.Aborted = args =>
            {
                tcs.SetResult(new ProcessResult() as TProcessResult);
            };

            return Task.Factory.FromAsync(workflow.BeginRun, workflow.EndRun, null).ContinueWith((t) =>
            {
                //if (t.IsFaulted)
                //    return new TProcessResult();
                return tcs.Task.Result;
            });
        }
        
    }
}

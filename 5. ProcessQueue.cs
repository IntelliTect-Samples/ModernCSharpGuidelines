using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernCSharpGuidelines;


public class WorkerQueue
{
    public WorkerQueue(Queue<Action> actions)
    {
        // GUIDELINE
        // 👍 CONSIDER using System.ArgumentNullException.ThrowIfNull() to validate non-nullable parameters.
        ArgumentNullException.ThrowIfNull(actions);
        Actions = actions;
    }
    public Queue<Action> Actions { get; } = new();

    // GUIDELINE
    // 👍 CONSIDER declaring local functions and anonymous factions as static
    public IEnumerable<Action> NonNullActions =>
        Actions.Where(static item => item is not null);
    public void Process()
    {
        // Using property pattern matching rather than 
        // is not null or the null-conditional operator (?.)
        // Note: "Actions.Dequeue() is not null action" won't complie
        if (Actions.Dequeue() is { } action) 
        {
            
            Task.Factory.StartNew(() => action.Invoke());
        }
    }
}

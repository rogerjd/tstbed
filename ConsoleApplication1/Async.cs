using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /* basic principle of async design:
     * 1 - write your methods synchronously
     * 2 - replace synchronous method calls with asynchronous (GetTaskAsync) method
     *      calls and await them.   async  await
     * 3 - except for "top-level" methods (typically event handler for UI controls),
     *      upgrade your asynchronous methods' return type to Task or Task<TResult>
     *      so that they're awaitable.
     */

    class Async
    {
    }
}

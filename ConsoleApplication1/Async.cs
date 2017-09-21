using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
     *      
     * 4 - Such a method, defined by using the async modifier
     * 5 - await operator, the await operator is applied to a task in an asynchronous method
     */

    static class AsyncTst
    {
        public static void Test()
        {
            Sync();
            Async();
        }

        private static void Sync()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    SyncCall();
                }
                Console.WriteLine(i);
            }
        }

        private static void Async()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                {
                    AsyncCall();
                }
                Console.WriteLine(i);
            }
        }

        private static void SyncCall()
        {
            Console.WriteLine("Start sync");
            Thread.Sleep(3000);  //Block
            Console.WriteLine("End");
        }

        private static async void AsyncCall()
        {
            Console.WriteLine("Start async");
            //await Thread.Sleep(3000);  //Block.  This doesnt work, needs Task
            await Task.Delay(3000);
            Console.WriteLine("End");
        }
    }
}

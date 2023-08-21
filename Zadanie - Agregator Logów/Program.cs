

using System.Linq;
using System.Security;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Logs
{

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var logs = new List<(string IP, string user, int duration)>();

            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine().Split();
                logs.Add((inputs[0], inputs[1], int.Parse(inputs[2])));
            }

            var result = logs
                .GroupBy(x => x.user)
                .Select(x => (user: x.Key, duration: x.Sum(y => y.duration), ips: x.Select(y => y.IP).Distinct().OrderBy(y => y)))
                .OrderBy(x => x.user);

            foreach(var r in result)
            {
                Console.WriteLine($"{r.user}: {r.duration} [{string.Join(", ", r.ips)}]");
            }




        }

    }
}








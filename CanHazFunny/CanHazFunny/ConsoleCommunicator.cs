using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class ConsoleCommunicator : ICommunicator
    {
        public void Communicate(string message)
        {
            Console.WriteLine(message);
        }
    }
}

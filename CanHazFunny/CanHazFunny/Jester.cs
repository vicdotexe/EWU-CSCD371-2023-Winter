using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IJokeService _jokeService;
        private readonly ICommunicator _communicator;
        public Jester(IJokeService jokeService, ICommunicator communicator)
        {
            _jokeService = jokeService;
            _communicator = communicator;
        }

        public void TellJoke()
        {
            var joke = _jokeService.GetJoke();
            while(joke.Contains("Chuck Norris"))
            {
                joke = _jokeService.GetJoke();
            }
            _communicator.Communicate(joke);
        }
    }
}

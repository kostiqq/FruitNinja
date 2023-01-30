using Infrastructure.States;
using Services;

namespace Infrastructure
{
    public class Game
    {
        public StateMachine StateMachine;
        private AllServices _allServices;
        
        public Game()
        {
            StateMachine = new StateMachine(_allServices);
        }
    }
}
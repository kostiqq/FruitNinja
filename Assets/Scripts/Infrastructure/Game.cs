using Infrastructure.States;

namespace Infrastructure
{
    public class Game
    {
        public StateMachine StateMachine;

        public Game()
        {
            StateMachine = new StateMachine();
        }
    }
}
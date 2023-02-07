using Infrastructure.States;
using Services;
using Services.ServiceLocator;

namespace Infrastructure
{
    public class Game
    {
        public StateMachine StateMachine;

        public Game(ServiceLocator<IService> serviceLocator)
        {
            StateMachine = new StateMachine(serviceLocator);
        }
    }
}
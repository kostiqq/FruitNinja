using Infrastructure.States;
using Services;
using Services.ServiceLocator;

namespace Infrastructure
{
    public class Game
    {
        public StateMachine StateMachine;

        private SceneLoader _sceneLoader;
        public Game(ServiceLocator<IService> serviceLocator, ProjectConfig configsHandler)
        {
            _sceneLoader = new SceneLoader();
            StateMachine = new StateMachine(serviceLocator, configsHandler, _sceneLoader);
        }
    }
}
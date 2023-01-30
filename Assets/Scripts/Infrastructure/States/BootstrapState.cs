using Services;
using Services.Factory;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly AllServices _services;
        
        public BootstrapState(StateMachine stateMachine, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _services = allServices;
            RegisterServices();
        }
        
        public void Enter()
        {
            _stateMachine.Enter<MainMenuState>();
        }

        private void RegisterServices()
        {
            _services.Register<IGameFactory>( new GameFactory());
        }

        public void Exit()
        {
            
        }
    }
}
using Services;
using Services.ServiceLocator;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ServiceLocator<IService> _services;
        
        public BootstrapState(StateMachine stateMachine, ServiceLocator<IService> allServices)
        {
            _stateMachine = stateMachine;
            _services = allServices;
        }
        
        public void Enter()
        {
            _stateMachine.Enter<MainMenuState>();
        }
        

        public void Exit()
        {
            
        }
    }
}
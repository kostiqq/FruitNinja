namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly StateMachine _stateMachine;

        public BootstrapState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public void Enter()
        {
            RegisterServices();
            _stateMachine.Enter<MainMenuState>();
        }

        private void RegisterServices()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}
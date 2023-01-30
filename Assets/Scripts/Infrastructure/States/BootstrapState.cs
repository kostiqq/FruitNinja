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
        }

        private void RegisterServices()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            
        }
    }
}
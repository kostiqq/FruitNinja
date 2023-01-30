namespace Infrastructure.States
{
    public class MainMenuState : IState
    {
        private StateMachine _stateMachine;

        public MainMenuState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        public void Enter()
        {
            //todo spawn UI;
            _stateMachine.Enter<PlayModeState>();
        }

        public void Exit()
        {
            
        }
    }
}
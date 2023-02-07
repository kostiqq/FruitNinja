namespace Infrastructure.States
{
    public class PlayModeState : IState
    {
        private readonly StateMachine _stateMachine;
        
        public PlayModeState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}
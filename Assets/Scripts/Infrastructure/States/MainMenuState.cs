namespace Infrastructure.States
{
    public class MainMenuState : IState
    {
        private StateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        
        public MainMenuState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            
        }
        
        public void Enter()
        {
                
            //_stateMachine.Enter<PlayModeState>();
        }

        public void Exit()
        {
            
        }
    }
}
namespace Infrastructure.States
{
    public class MainMenuState : IState
    {
        private StateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        
        public MainMenuState(StateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(0);
        }

        public void Exit()
        {
            
        }
    }
}
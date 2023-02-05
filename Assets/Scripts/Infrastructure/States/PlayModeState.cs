using Services;
using Services.Factory;

namespace Infrastructure.States
{
    public class PlayModeState : IState
    {
        private readonly AllServices _allServices;

        public PlayModeState(StateMachine stateMachine, AllServices services)
        {
            _allServices = services;
        }

        public void Enter()
        {
        }

        public void Exit()
        {
            
        }
    }
}
using Infrastructure.States;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private Game _game;
    
        void Start()
        {
            _game = new Game();
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}
using Infrastructure.States;
using UnityEngine;
using Utils;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private Game _game;

        public static Bootstrapper Instance;

        private void Awake()
        {
            _game = new Game();
            _game.StateMachine.Enter<BootstrapState>();
        }
    }
}
using Infrastructure.States;
using StaticData;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private SpawnerSettings _spawnerSettings;
        public SpawnerSettings GetSpawnerSettings => _spawnerSettings;
        
        private Game _game;

        public static Bootstrapper Instance;
        private void Awake()
        {
            if(Instance != null)
                Destroy(gameObject);

            Instance = this;
        }

        private void Start()
        {
            _game = new Game();
            _game.StateMachine.Enter<BootstrapState>();
        }


    }
}
using GameActors.Spawner;
using GameInput;
using Services;
using Services.CutterService;
using Services.Factory;
using Services.Progress;
using Services.ServiceLocator;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ProjectConfig configsHandler;
        [SerializeField] private Camera gameCamera;

        private ServiceLocator<IService> _serviceLocator;
        
        private void Awake()
        {
            InitializeServices();
            CreateCoreObjects();
        }

        private void InitializeServices()
        {
            _serviceLocator = new ServiceLocator<IService>();
            var progressService = new ProgressService(configsHandler.PlayerConfig);
            var gameFactory = new GameFactory(_serviceLocator);
            var cutterService = new CutterService(gameFactory);
            _serviceLocator.Register(gameFactory);
            _serviceLocator.Register(cutterService);
            _serviceLocator.Register(progressService);
        }
        
        private void CreateCoreObjects()
        {
            InputHandler inputHandler = new GameObject("InputHandler").AddComponent<InputHandler>();
            inputHandler.Construct(configsHandler.InputConfig, gameCamera);
            
            InputTrail inputTrail = new GameObject("InputTrail").AddComponent<InputTrail>();
            inputTrail.Construct(inputHandler, _serviceLocator.Get<GameFactory>().LoadInputTrail());
            
            CollisionTracker collisionTracker = new CollisionTracker(inputHandler, 
                _serviceLocator.Get<GameFactory>(), _serviceLocator.Get<CutterService>());

            Transform poolTransform = new GameObject("ObjectPool").transform;
            InteractableObjectsPool objectsPool = new InteractableObjectsPool(_serviceLocator.Get<GameFactory>(), 10, poolTransform);
            
            GameView gameView = _serviceLocator.Get<GameFactory>().LoadGameView();
            GameLoop loop = new GameObject("GameLoop").AddComponent<GameLoop>();
            loop.Construct(_serviceLocator.Get<ProgressService>(), gameView);
            
            FruitBuilder fruitBuilder = new FruitBuilder(configsHandler.FruitConfigs.ToArray());
            GameComplicator complicator = new GameObject("GameComplicator").AddComponent<GameComplicator>();
            complicator.Construct(configsHandler.ComplexityConfig);

            SpawnerController.Instance.Construct(complicator, objectsPool, fruitBuilder);
        }
    }
}
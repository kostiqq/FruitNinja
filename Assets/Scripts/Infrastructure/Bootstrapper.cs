using Services;
using Services.ServiceLocator;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private ProjectConfig configsHandler;

        private ServiceLocator<IService> _serviceLocator;

        private Game _game;


        public void Start()
        {
            Input.multiTouchEnabled = false;
            Application.targetFrameRate = 60;
        }
    }
}
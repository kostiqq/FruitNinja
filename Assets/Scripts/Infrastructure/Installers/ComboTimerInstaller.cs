using ScriptableObjects;
using Services;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ComboTimerInstaller : MonoInstaller
    {
        [SerializeField] private ComboTimerConfig timerConfig;
        
        public override void InstallBindings()
        {
            Container.
                Bind<IComboTimer>().
                To<ComboTimer>().
                AsSingle().
                WithArguments(timerConfig).NonLazy();
        }
    }
}
using UnityEngine;
using Zenject;

public class HealthViewInstaller : MonoInstaller
{
    [SerializeField] private HealthView healthView;
    public override void InstallBindings()
    {
        Container
            .Bind<HealthView>().FromComponentInHierarchy();
    }
}
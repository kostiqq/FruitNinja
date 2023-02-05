using GameActors.InteractableObjects;

namespace Services.Factory
{
    public interface IGameFactory : IService
    {
        public InteractableObject LoadInteractableObject();
    }
}
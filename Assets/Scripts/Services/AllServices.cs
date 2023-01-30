namespace Services
{
    public class AllServices
    {
        private static AllServices _instance;
        
        public static AllServices Container => _instance ??= new AllServices();

        public void Register<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService GetSingle<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService>
        {
            public static TService ServiceInstance;
        }
    }
}
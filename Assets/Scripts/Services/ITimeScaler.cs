namespace Services
{
    public interface ITimeScaler
    {
        public float TimeScale { get; }

        public void FreezeBoard();
    }
}
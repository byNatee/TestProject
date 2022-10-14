namespace Interfaces
{
    public interface IUpdate
    {
        public void Attach(IUpdatable updatable);
        public void Detach(IUpdatable updatable);
    }
}
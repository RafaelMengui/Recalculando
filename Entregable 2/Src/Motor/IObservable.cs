namespace Proyecto.Motor
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
    }
}
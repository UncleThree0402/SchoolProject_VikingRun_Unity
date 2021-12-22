namespace Interface
{
    public interface IObservable
    {
        void Attach(IObserver observer);
        void Notify();
    }
}
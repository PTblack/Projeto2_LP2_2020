namespace Project2_LP2_2020.GameEngine
{
    // Interface to be implemented by observer subjects
    public interface IObserver<T>
    {
        void Notify(T notification);
    }
}
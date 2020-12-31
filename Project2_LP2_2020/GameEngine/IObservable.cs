using System.Collections.Generic;

namespace Project2_LP2_2020.GameEngine
{
    // Interface to be implemented by observable subjects
    public interface IObservable<T>
    {
        void RegisterObserver(
            IEnumerable<T> whatToObserve, IObserver<T> observer);
        void RemoveObserver(T whatToObserve, IObserver<T> observer);
        void RemoveObserver(IObserver<T> observer);
    }
}
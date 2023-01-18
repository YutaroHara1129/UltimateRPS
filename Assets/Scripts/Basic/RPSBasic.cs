using System;
using System.Collections.Generic;

namespace RPSBasic
{
    public enum handsign
    {
        rock,
        paper,
        scissors
    }

    public interface IBasicObserver<T>{
        void OnRecieved(T value);
    }
    public interface IBasicDisposable<T>
    {
        void Subscrive(IBasicObserver<T> observer);
        void UnSubscrive(IBasicObserver<T> observer);
        void SendMessage(T value);
        void Dispose();
    }
    public class BasicObserver<T> : IBasicObserver<T>
    {
        public Action<T> action;
        public void OnRecieved(T value)
        {
            action(value);
        }
    }
    public class BasicSubject<T> : IBasicDisposable<T>
    {
        private List<IBasicObserver<T>> _observers = new List<IBasicObserver<T>>();

        public void Subscrive(IBasicObserver<T> observer)
        {
            _observers.Add(observer);
        }
        public void UnSubscrive(IBasicObserver<T> observer)
        {
            _observers.Remove(observer);
        }
        public void SendMessage(T value)
        {
            foreach (var observer in _observers) observer.OnRecieved(value);
        }
        public void Dispose()
        {
            _observers.Clear();
        }
    }
}
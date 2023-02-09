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
    public enum result
    {
        win,
        draw,
        lose
    }
    public enum score
    {
        s,
        a,
        b,
        c
    }
    public enum phase
    {
        title,
        select,
        battle,
        result
    }

    public interface IBasicObserver
    {
        void OnRecieved();
    }
    public interface IBasicObserver<T>{
        void OnRecieved(T value);
    }
    public interface IBasicDisposable
    {
        void Subscrive(IBasicObserver observer);
        void UnSubscrive(IBasicObserver observer);
        void SendMessage();
        void Dispose();
    }
    public interface IBasicDisposable<T>
    {
        void Subscrive(IBasicObserver<T> observer);
        void UnSubscrive(IBasicObserver<T> observer);
        void SendMessage(T value);
        void Dispose();
    }
    public class BasicObserver : IBasicObserver
    {
        public Action action;
        public void OnRecieved()
        {
            action();
        }
    }
    public class BasicObserver<T> : IBasicObserver<T>
    {
        public Action<T> action;
        public void OnRecieved(T value)
        {
            action(value);
        }
    }
    public class BasicSubject : IBasicDisposable
    {
        private List<IBasicObserver> _observers = new List<IBasicObserver>();

        public void Subscrive(IBasicObserver observer)
        {
            _observers.Add(observer);
        }
        public void UnSubscrive(IBasicObserver observer)
        {
            _observers.Remove(observer);
        }
        public void SendMessage()
        {
            foreach (var observer in _observers) observer.OnRecieved();
        }
        public void Dispose()
        {
            _observers.Clear();
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
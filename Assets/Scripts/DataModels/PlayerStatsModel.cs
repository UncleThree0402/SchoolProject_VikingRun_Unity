using System.Collections.Generic;
using Interface;

public class PlayerStatsModel : IObservable
{
    private List<IObserver> _Observers;

    private bool _isAlive;

    private int scores = 0;
    
    private float survivalTime = 0;

    public PlayerStatsModel()
    {
        _Observers = new List<IObserver>();
        _isAlive = true;
    }


    public bool IsAlive
    {
        get => _isAlive;
        set
        {
            _isAlive = value;
            Notify();
        }
    }

    public int Scores
    {
        get => scores;
        set
        {
            scores = value;
            Notify();
        }
    }
    
    public float Time
    {
        get => survivalTime;
        set
        {
            survivalTime = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        _Observers.Add(observer);
    }

    public void Notify()
    {
        foreach (var observer in _Observers)
        {
            observer.UpdateData(this);
        }
    }
}

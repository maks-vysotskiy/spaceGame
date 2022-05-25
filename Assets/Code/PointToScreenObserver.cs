using System;
using UnityEngine;
using UnityEngine.UI;
internal sealed class PointToScreenObserver: MonoBehaviour
{
    [SerializeField] private Text _textPointOnScreen;
    private int _points = 0;
    public void Add(IPointOnHit target)
    {
        target.OnHitEnemy += PointOnScreen;
    }
    public void Remove(IPointOnHit target)
    {
        target.OnHitEnemy -= PointOnScreen;
    }
    private void PointOnScreen()
    {
        _points++;
        _textPointOnScreen.text = $"Points: {_points}";
    }
}


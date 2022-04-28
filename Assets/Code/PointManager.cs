using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


internal sealed class PointManager: MonoBehaviour
{
    [SerializeField] private Text _pointText;
    private PointInterpreter _pointInterpreter;

    private int _point;

    private void Start()
    {
        _pointInterpreter = new PointInterpreter();
        _point = 0;
    }
            
    public void AddPoint(int point)
    {
        _point += point;
        RefreshTextUI();
    }

    private void RefreshTextUI()
    {
        var text = _pointInterpreter.Interpreter(_point);
        _pointText.text = text;
    }


}


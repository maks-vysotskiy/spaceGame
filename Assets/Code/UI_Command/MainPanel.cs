using System;
using UnityEngine;


internal sealed class MainPanel : BaseUI
{
    public override void Cancel()
    {
        gameObject.SetActive(false);
    }

    public override void Execute()
    {
        gameObject.SetActive(true);
    }
}


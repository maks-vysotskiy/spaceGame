using System;
using UnityEngine;
using UnityEngine.SceneManagement;


internal sealed class BtnBack : BaseUI
{
    public override void Cancel()
    {
        
    }

    public override void Execute()
    {
       if(transform.parent.gameObject)
        {
            transform.parent.gameObject.SetActive(false);
        }    
    }
}


using System;
using UnityEngine;
using UnityEngine.SceneManagement;


internal sealed class BtnRestart : BaseUI
{
    public override void Cancel()
    {
        
    }

    public override void Execute()
    {
       if(transform.parent.gameObject)
        {
            SceneManager.LoadScene(0);
            
        }    
    }
}


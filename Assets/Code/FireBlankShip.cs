using UnityEngine;
using Object = UnityEngine.GameObject;
internal class FireBlankShip : IFireShip
{
    private readonly string _message;
        
    public FireBlankShip(string message)
    {
        _message = message;
    }
    public void Fire(bool isFire)
    {
        if (isFire)
        {
            Debug.Log(_message);
        }
    }
}


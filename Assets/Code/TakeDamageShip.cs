using UnityEngine;
using Object = UnityEngine.GameObject;
internal class TakeDamageShip : ITakeDamage
{
    private float _hp;

    public TakeDamageShip(float hp)
    {
        _hp = hp;
    }
    public void TakeDamage(Object damageObject)
    {
        if(_hp<=0)
        {
            Object.Destroy(damageObject);
        }
        else
        {
            _hp--;
        }
    }
}


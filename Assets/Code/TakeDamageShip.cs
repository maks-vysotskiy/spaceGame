using UnityEngine;
using Object = UnityEngine.GameObject;
internal class TakeDamageShip : ITakeDamageShip
{
    private float _hp;
    private Player _player;

    public TakeDamageShip(Player player, float hp)
    {
        _player = player;
        _hp = hp;
    }

    public float GetHp()
    {
        return _hp;
    }

    public void TakeDamage(Object damageObject)
    {
        if (damageObject.CompareTag("Enemy"))
        {
            if (_hp <= 1)
            {
                Object.Destroy(_player.gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }


}


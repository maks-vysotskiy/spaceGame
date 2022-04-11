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
        if (damageObject.tag == "Enemy")
        {
            if (_hp <= 1)
            {
                Object.Destroy(damageObject);
                Object.Destroy(_player.gameObject);
            }
            else
            {
                Object.Destroy(damageObject);
                _hp--;
            }
        }
    }


}


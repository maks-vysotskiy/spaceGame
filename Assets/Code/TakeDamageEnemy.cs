using UnityEngine;
using Object = UnityEngine.GameObject;
internal class TakeDamageEnemy : ITakeDamageEnemy
{
    private float _hp;
    private Enemy _enemy;
    private int _bonusPoint = 501;

    public TakeDamageEnemy(Enemy enemy, float hp)
    {
        _enemy = enemy;
        _hp = hp;
    }

    public void RefreshHp(float hp)
    {
        _hp = hp;
    }

   public void TakeDamage(Object damageObject)
    {
        if (damageObject.CompareTag("Border"))
        {
            _enemy.EnemyPool.ReturnToPool(_enemy);
            _enemy.DependencyInjectionHealth(3);
        }
        else if (damageObject.CompareTag("Bullet"))
        {
            if (_hp <= 1)
            {
                _enemy.EnemyPool.ReturnToPool(_enemy);
                _enemy.DependencyInjectionHealth(3);
                _enemy._pointManager.AddPoint(_bonusPoint);
            }
            else
            {
                _hp--;
            }
        }
        else if(damageObject.CompareTag("Player"))
        {
            _enemy.EnemyPool.ReturnToPool(_enemy);
            _enemy.DependencyInjectionHealth(3);
        }
    }


}


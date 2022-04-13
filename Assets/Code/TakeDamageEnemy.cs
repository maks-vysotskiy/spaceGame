﻿using UnityEngine;
using Object = UnityEngine.GameObject;
internal class TakeDamageEnemy : ITakeDamageEnemy
{
    private float _hp;
    private Enemy _enemy;

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
        if (damageObject.tag == "Border")
        {
            _enemy.EnemyPool.ReturnToPool(_enemy);
            _enemy.DependencyInjectionHealth(3);
        }
        else if (damageObject.tag == "Bullet")
        {
            if (_hp <= 1)
            {
                _enemy.EnemyPool.ReturnToPool(_enemy);
                _enemy.DependencyInjectionHealth(3);
            }
            else
            {
                _hp--;
            }
        }
        else if(damageObject.tag == "Player")
        {
            _enemy.EnemyPool.ReturnToPool(_enemy);
            _enemy.DependencyInjectionHealth(3);
        }
    }


}


using System;
using UnityEngine;
using Object = UnityEngine.GameObject;
internal class TakeDamageEnemy : ITakeDamageEnemy, IPointOnHit
{
    private float _hp;
    private Enemy _enemy;
    private int _bonusPoint = 501;
    private PointToScreenObserver _pointObserver;

    public event Action OnHitEnemy = delegate { };

    public TakeDamageEnemy(Enemy enemy, float hp, PointToScreenObserver pointObserver)
    {
        _enemy = enemy;
        _hp = hp;
        _pointObserver = pointObserver;
        _pointObserver.Add(this);
    }

    

    public void HitToEnemy()
    {
        OnHitEnemy.Invoke();
    }

    public void RefreshHp(float hp)
    {
        _hp = hp;
    }

   public void TakeDamage(Object damageObject)
    {
        //if (damageObject.CompareTag("Border"))
        if(damageObject.TryGetComponent(out Border component))
        {
            _enemy.EnemyPool.ReturnToPool(_enemy);
            _enemy.DependencyInjectionHealth(3);
        }

        else if (damageObject.CompareTag("Bullet"))
        {
            if (_hp <= 1)
            {
                _enemy.EnemyPool.ReturnToPool(_enemy);
                HitToEnemy();
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
            HitToEnemy();
            _enemy.DependencyInjectionHealth(3);
        }
    }


}


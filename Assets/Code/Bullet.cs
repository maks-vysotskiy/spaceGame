using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

internal abstract class Bullet : MonoBehaviour
{
    private BulletPool _bulletPool=null;
    private Transform _rootPool;
    public Transform RootPool
    {
        get
        {
            if(_rootPool==null)
            {
                var find = GameObject.Find(NameManager.POOL_PLAYER_BULLET).transform;
                _rootPool = find == null ? null : find.transform;
            }
            return _rootPool;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Border")
        {
            Debug.Log("Border!");
            _bulletPool.ReturnToPool(this);            
        }
    }

    public void GetPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }
}


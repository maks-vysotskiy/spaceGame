using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

internal sealed class BulletPool
{
    private readonly HashSet<Bullet> _bulletPool;
    private readonly int _capasityPool;
    private readonly Transform _gunPosition;
    private Transform _rootPool;

    public BulletPool(int capasity, string typeBullet, Transform gunPosition)
    {
        _bulletPool = new HashSet<Bullet>();
        _capasityPool = capasity;
        _gunPosition = gunPosition;

        if (!_rootPool)
        {
            _rootPool = new GameObject(NameManager.POOL_PLAYER_BULLET).transform;
        }
        CreatePool(_capasityPool, typeBullet);
    }

    public Bullet TakeBullet()
    {
        var bullet = _bulletPool.FirstOrDefault(a => !a.gameObject.activeSelf);
        bullet.GetPool(this);
        return ActiveBullet(bullet);
    }

    private void CreatePool(int capasity, string typeBullet)
    {
        var bullet = Resources.Load<Laser>("Laser");
        for (int i = 0; i < capasity; i++)
        {
            var instantiate = Object.Instantiate(bullet);
            ReturnToPool(instantiate);
            _bulletPool.Add(instantiate);
        }
    }

    public void ReturnToPool(Bullet bullet)
    {
        var transformObj = bullet.gameObject.transform;
        transformObj.localPosition = Vector3.zero;
        transformObj.localRotation = Quaternion.identity;
        transformObj.gameObject.SetActive(false);
        transformObj.SetParent(_rootPool);
    }

    private Bullet ActiveBullet(Bullet bullet)
    {
        var transformObj = bullet.gameObject.transform;
        transformObj.localPosition = _gunPosition.position;
        transformObj.localRotation = _gunPosition.rotation;
        bullet.gameObject.SetActive(true);
        bullet.transform.SetParent(null);

        return bullet;
    }


}


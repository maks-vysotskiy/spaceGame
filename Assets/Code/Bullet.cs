using UnityEngine;

internal abstract class Bullet : MonoBehaviour
{
    private BulletPool _bulletPool = null;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
           _bulletPool.ReturnToPool(this);
        }
        else if(collision.CompareTag("Enemy"))
        {
            _bulletPool.ReturnToPool(this);

        }
    }

    public void GetPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }
}


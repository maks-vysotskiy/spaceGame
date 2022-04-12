using UnityEngine;
internal abstract class Enemy : MonoBehaviour
{
    public static IEnemyFactory Factory;

    private float _health = 3;
    private EnemyPool _enemyPool = null;
    private EnemyMove _move;

    private const string _resourcesAsteroid = "Asteroid";
    private const string _resourcesSpider = "Spider";

    private float _minSpeed = 1f;
    private float _maxSpeed = 2.5f;

    public float Speed
    {
        get
        {
            return Random.Range(_minSpeed, _maxSpeed);
        }
        private set { }
    }

    private void Start()
    {
        _move = new EnemyMove(Speed);
    }

    private void Update()
    {
        Move(transform);
    }

    public static Asteroid CreateAsteroidEnemy(float hp)
    {
        var enemy = Instantiate(Resources.Load<Asteroid>(_resourcesAsteroid));
        enemy.DependencyInjectionHealth(hp);
        return enemy;
    }

    public static Spider CreateSpiderEnemy(float hp)
    {
        var enemy = Instantiate(Resources.Load<Spider>(_resourcesSpider));
        enemy.DependencyInjectionHealth(hp);
        return enemy;
    }

    public void DependencyInjectionHealth(float hp)
    {
        _health = hp;
    }

    public void GetPool(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;
    }

    public void Move(Transform transform)
    {
        _move.Move(transform);
        Debug.Log(_health);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
             _enemyPool.ReturnToPool(this);
        }
        else if (collision.tag == "Bullet")
        {
            if (_health <= 1)
            {
                _enemyPool.ReturnToPool(this);
            }
            else
            {
                _health--;
            }
        }
    }


}


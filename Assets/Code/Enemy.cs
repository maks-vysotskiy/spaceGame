using System;
using UnityEngine;
internal abstract class Enemy : MonoBehaviour
{
    public static IEnemyFactory Factory;

    [SerializeField] private float _health = 3;
    

    private EnemyPool _enemyPool = null;
    private IMoveEnemy _move;
    private ITakeDamageEnemy _takeDamage;

    public PointManager _pointManager;
    private PointToScreenObserver _pointObserver;

    public EnemyPool EnemyPool
    {
        get
        {
            return _enemyPool;
        }
        
    }


    private const string _resourcesAsteroid = "Asteroid";
    private const string _resourcesSpider = "Spider";

    private float _minSpeed = 1f;
    private float _maxSpeed = 2.5f;

    public event Action OnHitEnemy = delegate { };

    public float Speed
    {
        get
        {
            return UnityEngine.Random.Range(_minSpeed, _maxSpeed);
        }
        private set { }
    }

    private void Start()
    {
        _pointManager = FindObjectOfType<PointManager>();
        _pointObserver = FindObjectOfType<PointToScreenObserver>();
       
        _move = new EnemyMove(Speed);
        _takeDamage = new TakeDamageEnemy(this, _health, _pointObserver);
               
    }

    private void Update()
    {
        _move.Move(transform);

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
        _takeDamage.RefreshHp(hp);
    }

    public void GetPool(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _takeDamage.TakeDamage(collision.gameObject);

    }

    public void HitToEnemy()
    {
        OnHitEnemy.Invoke();
    }
}


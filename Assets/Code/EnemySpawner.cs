using UnityEngine;
internal sealed class EnemySpawner
{
    private readonly EnemyPool _enemyPool;
    private readonly Transform[] _transforms;

    private float _time = 0;
    private float _timeSpawn = 5;
    

    private const string _resourcesAsteroid = "Asteroid";
    private const string _resourcesSpider = "Spider";

    public EnemySpawner(EnemyPool enemyPool, Transform[] transforms)
    {
        _enemyPool = enemyPool;
        _transforms = transforms;

    }

    public void SpawnEnemy(string EnemyType)
    {
        _time = _time + Time.deltaTime;
       
        if (_time >= _timeSpawn)
        {
            var enemy = _enemyPool.GetEnemy(EnemyType);
            _enemyPool.ActiveEnemy(enemy);

            var spawnTransform = Random.Range(0, _transforms.Length);
            enemy.transform.position = _transforms[spawnTransform].position;
            enemy.transform.rotation = _transforms[spawnTransform].rotation;

            _time = 0;
        }
    }

   




}


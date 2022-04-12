using UnityEngine;
internal sealed class GameStarter : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPlaces;
    private EnemySpawner _enemySpawner;
    private void Start()
    {
        _enemySpawner = new EnemySpawner(new EnemyPool(20), _spawnPlaces);
        
    }

    private void Update()
    {
        _enemySpawner.SpawnEnemy("Asteroid");
        
    }
}


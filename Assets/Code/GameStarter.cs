using System;
using UnityEngine;
internal sealed class GameStarter : MonoBehaviour
{

    private void Start()
    {
        Enemy.CreateSpiderEnemy(new Health(100.0f, 100.0f));


        IEnemyFactory Asteroidfactory = new AsteroidFactory();
        IEnemyFactory Spiderfactory = new SpiderFactory();
        Asteroidfactory.Create(new Health(100.0f, 100.0f));
        Spiderfactory.Create(new Health(100.0f, 100.0f));
                

        //var platform = new PlatformFactory().CreatePlatform(Application.platform);


    }
}


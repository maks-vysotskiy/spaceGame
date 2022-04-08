using System;
using UnityEngine;
internal sealed class GameStarter : MonoBehaviour
{
    private void Start()
    {
        Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f));
    }
}


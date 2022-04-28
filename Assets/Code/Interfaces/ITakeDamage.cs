using UnityEngine;
public interface ITakeDamageShip
{
    void TakeDamage(GameObject damageObject);
    float GetHp();
    void AddHp(float hp);
}


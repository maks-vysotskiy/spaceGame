using UnityEngine;
internal sealed class LaserRed: MonoBehaviour
{
    public LaserRed Prefab { get; set; }
    public Transform GunPlace { get; set; }
    public float Force { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
        else if (collision.tag == "Enemy")
        {
            Destroy(gameObject);

        }
    }
}


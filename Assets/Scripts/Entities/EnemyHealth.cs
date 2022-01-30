using Entities;
using UnityEngine.SceneManagement;

public class EnemyHealth : Health
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
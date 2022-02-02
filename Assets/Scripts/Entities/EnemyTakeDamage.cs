using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    [SerializeField] private GameObject cone;
    private PlayerAttack _playerAttack;
    private bool tookDamage = false;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        // if (collider.gameObject.CompareTag("AttackCone") && cone.activeSelf)
        if (collider.transform.parent.TryGetComponent(out _playerAttack) && cone.activeSelf)
        {
            enemyHealth.TakeDamage(_playerAttack.AttackStrength);
            tookDamage = true;
            enemyHealth.IsImmortal = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("AttackCone"))
        {
            tookDamage = false;
            enemyHealth.IsImmortal = false;
        }
    }
}
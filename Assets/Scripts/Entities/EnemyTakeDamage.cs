using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    private PlayerAttack playerAttack;
    [SerializeField] private GameObject cone;
    private bool canTakeDamage = false;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("AttackCone") && cone.activeSelf && !canTakeDamage)
        {
            StartCoroutine(TakeDamageSequence());
        }
    }

    private IEnumerator TakeDamageSequence()
    {
        enemyHealth.TakeDamage(playerAttack.damage);
        canTakeDamage = true;
        yield return new WaitForSeconds(0.2f);
        canTakeDamage = false;
    }
}
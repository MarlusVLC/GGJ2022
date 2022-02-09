using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject cone;
    [SerializeField] private Animator animator;
    public int damage = 1;
    [SerializeField] private float attackSpeed;
    private bool isAttacking;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }    

    private IEnumerator Attack()
    {
        animator.SetTrigger("Attack");  // starts animation
        isAttacking = true; // can't attack while attacking
        yield return new WaitForSeconds(attackSpeed - 0.2f);
        cone.SetActive(true);           // activates attack cone
        yield return new WaitForSeconds(0.2f);
        cone.SetActive(false);          // deactivates attack cone
        isAttacking = false;            // can attack again
    }
}

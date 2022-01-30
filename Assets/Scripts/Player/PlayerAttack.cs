using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject cone;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackSpeed;
    private bool isAttacking;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Attack());
        }

        if (isAttacking)
        {
            cone.SetActive(true);
        } 
        else
        {
            cone.SetActive(false);
        }
    }    

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackSpeed);
        isAttacking = false;
    }
}

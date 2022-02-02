using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject cone;
    [SerializeField] private Animator animator;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int attackStrength = 1;
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

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = value;
    }

    public int AttackStrength
    {
        get => attackStrength;
        set => attackStrength = value;
    }
}

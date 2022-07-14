using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour
{
    private Animator anim;
    public float attackTime;
    public float startTimeAttack;
    public int Damage;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask Enemies;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, Enemies);
                foreach (Collider2D damage2 in damage)
                {
                    damage2.GetComponent<enemycombat>().getdamage(Damage);
                }
                
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}

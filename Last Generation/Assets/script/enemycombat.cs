using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemycombat : MonoBehaviour
{
    private Animator anim;
    public float attackTime;
    public float startTimeAttack;
    public int Damage;
    public Transform attackLocation;
    public float attackRange;
    public LayerMask Enemies;
    public int health;
    public Slider slider;
    enemyatack Enemyatack;
    enemyatack speed;

    private void Start()
    {
        slider.maxValue = health;
        slider.value = health;
        anim = GetComponent<Animator>();
        Enemyatack = GetComponent<enemyatack>();
    }

    void Update()                 
    {
        encom();
    }
    void encom()
    {
        if (attackTime <= 0)
        {
            Collider2D[] player = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, Enemies);
            foreach (Collider2D player2 in player)
            {
                player2.GetComponent<movecharacter>().Takedamage(attackRange);
            }

            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
            anim.SetBool("Attack", false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }

    public void getdamage(int amount)
    {
        if (health - amount >= 0)
        {
            anim.SetTrigger("Hurt");
            anim.SetBool("Attack", false);
            slider.value = health;
            health -= amount;
        }

        else
        {
            health = 0;
            slider.value = 0;
            anim.SetBool("dead", true);
            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Enemyatack.followspeed = 0;
            Destroy(gameObject, 1);
        }
    }

}

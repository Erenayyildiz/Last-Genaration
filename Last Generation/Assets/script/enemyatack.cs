using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyatack : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    public float leftrightspeed;
    public float oldposition;

    public float distance;
    public Transform target;
    public float followspeed;
    enemycombat com;
    Animator anim;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        enemyAtack();
    }


    void EnemyMove()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * leftrightspeed, 1.0f));

        if (transform.position.x > oldposition)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if(transform.position.x < oldposition)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        oldposition = transform.position.x;

    }

    void enemyAtack()
    {           
        RaycastHit2D hitenemy = Physics2D.Raycast(transform.position, -transform.right, distance);

        if (hitenemy.collider != null)
        {
                Debug.DrawLine(transform.position, hitenemy.point, Color.red);
                anim.SetBool("Attack", true);
                enemyfollow();
        }
        else
        {
           Debug.DrawLine(transform.position, transform.position - transform.right * distance, Color.green);
           anim.SetBool("Attack", false);
           EnemyMove();
        }

    }

    void enemyfollow()
    {
        com = GetComponent<enemycombat>();
        Vector3 targetposition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.x);
        transform.position = Vector2.MoveTowards(transform.position, targetposition, followspeed * Time.deltaTime);
    }
}

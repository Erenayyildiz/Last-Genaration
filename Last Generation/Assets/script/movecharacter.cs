using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class movecharacter : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float health;
    public Slider slider;
    public GameObject restart;
    public GameObject apples;
    public GameObject apple;
    public float applelife;
    void Start()
    {
        apples.SetActive(true);
        apple.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        slider.maxValue = health;
        slider.value = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "apple")
        {
            if (health > 0 && health <= 100)
            {
                apples.SetActive(false);
                health += applelife;
                slider.value = health;
            }

            if (health >= 100)
            {
                health = 100;
            }
        }

        if (collision.gameObject.tag == "apples")
        {
            if (health > 0 && health <= 100)
            {
                apple.SetActive(false);
                health += applelife;
                slider.value = health;
            }

            if (health >= 100)
            {
                health = 100;
            }
        }


        if (health <= 0)
        {
            Time.timeScale = 0;
            restart.SetActive(true);
        }
    }


    public void Takedamage(float amount)
    {
        //anim.SetTrigger("Hurt");
        if (health - amount >= 0)
        {
            slider.value = health;
            health -= amount;
        }

        else
        {
            health = 0;
            slider.value = 0;
            Die();
        }

    }
    void Die()
    {
        anim.SetTrigger("Death");
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        //Destroy(gameObject, 2f);
    }

}

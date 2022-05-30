using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    public Image[] hearts;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    [Header("Hurt Sound")]
    [SerializeField] private AudioClip hurtSound;

    public int health = 5;

    public void Damage(int _damage)
    {
        hearts[health-1].enabled = false;
        health -= _damage;
        anim.SetTrigger("Hurt");
        SoundManager.instance.PlaySound(hurtSound);

        if(health == 0)
        {
            Die();
        }

    }
    


    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Spike"))
        {
            if(health > 0)
                {
                    Damage(1);
                    SoundManager.instance.PlaySound(hurtSound);

                }
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        GetComponent<Player>().enabled = false;
        SoundManager.instance.PlaySound(deathSound);

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}

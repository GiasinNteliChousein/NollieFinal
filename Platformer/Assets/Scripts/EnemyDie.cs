using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    
    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("hurting");

        if(currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("dying", true);
        SoundManager.instance.PlaySound(deathSound);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyPatrol>().enabled = false;
        this.enabled = false;
    }
}

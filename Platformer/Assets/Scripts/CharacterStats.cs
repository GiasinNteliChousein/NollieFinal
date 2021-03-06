using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    
    public Image[] hearts;

    public int health = 5;
    int maxHealth = 5;


    public void Damage(int amount)
    {
        hearts[health-1].enabled = false;
        health -= amount;
    }
    

    public void Regen(int amount)
    {
        health += amount;

        for(int i = 0 ; i <  health; i++)
        {
            hearts[i].enabled = true;
        }
    }

    public void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if(health > 0)
            {
                Damage(1);
            }
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            if(health < maxHealth)
            {
                Regen(1);
            }
        }
    }




}

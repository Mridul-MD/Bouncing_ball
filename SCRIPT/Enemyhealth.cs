using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyhealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int collisiondamage;
  
    private void Update()
    {
        
    if(health <= 0)
        {
         
            Destroy(gameObject);
        }
       
    }

   
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.name == "player")
        {
           
            collision.gameObject.GetComponent<playerscript>().TakeDamagePlayer(collisiondamage);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bullet : MonoBehaviour
{
    [SerializeField] float lifetime;
    [SerializeField] LayerMask whatIsSolid;
    public int damage;

    //[SerializeField] GameObject destroyEffect;


    private void Start()
    {
        Invoke("Destroyprojectile", lifetime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            
            collision.GetComponent<Enemyhealth>().TakeDamage(damage);
            Destroyprojectile();
        }

        //if (collision.IsTouchingLayers( whatIsSolid))
        //{
        //    Destroyprojectile();
        //    Debug.Log("Working");
        //}
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroyprojectile();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroyprojectile();
        }
    }


    void Destroyprojectile()
    {
        //Instantiate(destroyEffect,transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

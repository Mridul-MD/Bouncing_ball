using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class fireballscript : MonoBehaviour
{
    [SerializeField] int fdamage;
    private Transform playerobj;
    [SerializeField] float speed;
    private Vector2 target;
    //public int adddamage;

    private void Start()
    {
       
        playerobj = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerobj.position.x, playerobj.position.y);
        
    }
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, target, speed);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Destroyfireball();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            collision.gameObject.GetComponent<playerscript>().TakeDamagePlayer(fdamage);
            Destroyfireball();
        }
       
        //if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        //{
        //    Destroyfireball();
        //}
    }

    private void Destroyfireball()
    {
        Destroy(gameObject);
    }

    
}

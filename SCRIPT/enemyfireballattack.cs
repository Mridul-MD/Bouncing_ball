using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfireballattack : MonoBehaviour
{
    //[SerializeField] float playerDistance;
    [SerializeField] GameObject fireball;
    private GameObject player;
    private float distance;
    private float timer;

    //private fireballscript fireballscript;
    //[SerializeField] int adddamagetofireball;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //fireballscript = fireball.gameObject.GetComponent<fireballscript>();
        //fireballscript.adddamage = adddamagetofireball;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
       
        if (distance < 200)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {

                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
       Instantiate(fireball, transform.position, Quaternion.identity);
        
    }
}

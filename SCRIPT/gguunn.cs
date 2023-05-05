using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gguunn : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shotpoint;
    [SerializeField] float speed;

    private Vector2 difference;
    void Update()
    {
        Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        difference = mousepos - (Vector2)transform.position;
        transform.right = difference;

    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bulletIns = Instantiate(bullet, shotpoint.position, shotpoint.rotation);
            bulletIns.GetComponent<Rigidbody2D>().AddForce(bulletIns.transform.right * speed);
        }
    }

}

using UnityEngine;

public class moveobj : MonoBehaviour
{
    public float movementSpeed = 1f,lerpSpeed = 0.05f;
    Rigidbody2D rd;


    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movementSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(movementSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, movementSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, movementSpeed, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPosition.x, cursorPosition.y);
        }


        Vector2 position = new Vector2(0.0f, 0.0f);
        Vector2 cursorPosition1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position = Vector2.Lerp(transform.position, cursorPosition1, lerpSpeed);
        rd.MovePosition(position);

    }


}

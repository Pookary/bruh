 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(change != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
             transform.position + change * speed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name) {
            case "Potato":
                Score.scoreAmount += 1;
                Destroy(collision.gameObject);
                break;
            case "Potato2":
                Score.scoreAmount += 2;
                Destroy(collision.gameObject);
                break;
            case "Potato3":
                Score.scoreAmount += 3;
                Destroy(collision.gameObject);
                break;
        }
    }
}


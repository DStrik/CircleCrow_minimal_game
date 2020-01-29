using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movement_speed = 0.2f;
    public float rotation_speed = 100.0f;
    private bool up, down;
    public bool gravity_down;   // used for lose state
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0f, -9.8f);
        gravity_down = true;
        down = true;
        up = false;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            audioSource.Play();

            if(gravity_down)
            {
                Physics2D.gravity = new Vector2(0f, 9.8f);
                Camera.main.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                gravity_down = false;
            }
            else
            {
                Physics2D.gravity = new Vector2(0f, -9.8f);
                Camera.main.backgroundColor = new Color(0.1696f, 0.8773f, 0.8627f, 0.0f);
                gravity_down = true;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            MoveRight();
        }
        
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            Physics2D.gravity = new Vector2(0f, -9.8f);
            gravity_down = true;

            transform.position = new Vector3(0f, 0f, -0.8f);
            Camera.main.backgroundColor = new Color(0.1696f, 0.8773f, 0.8627f, 0.0f);
            Camera.main.orthographicSize = 7;
        }

        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void MoveRight()
    {
        Vector2 position = transform.position;
        position.x += movement_speed;
        transform.position = position;
        if (down)
        {
            transform.Rotate(0, 0, rotation_speed * Time.deltaTime);
        }
        if (up)
        {
            transform.Rotate(0, 0, -1 * rotation_speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Top")
        {
            up = true;
            down = false;
        }
        if (col.gameObject.tag == "Bottom")
        {
            down = true;
            up = false;
        }
    }
}

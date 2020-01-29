using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    private bool going_down = true;
    private float velocity = 0;
    public AudioSource caw;
    // Start is called before the first frame update
    void Start()
    {
        caw = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        if(going_down)
        {
            velocity -= 0.1f;
        }
        else
        {
            velocity += 0.1f;
        }
        
        position.y = velocity;
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        caw.Play();
        if (col.gameObject.tag == "Top")
        {
            going_down = true;
        }
        if (col.gameObject.tag == "Bottom")
        {
            going_down = false;
        }
    }
}

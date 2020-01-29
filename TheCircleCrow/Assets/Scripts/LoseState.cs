using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            var player = GameObject.FindWithTag("Player");
            
            // Should always work but will still have the check
            if(player != null)
            {
                PlayerController playerScript = player.GetComponent<PlayerController>();
                Physics2D.gravity = new Vector2(0f, -9.8f);
                playerScript.gravity_down = true;

                player.transform.position = new Vector3(0.0f, 0.0f, -0.8f);
                Camera.main.backgroundColor = new Color(0.1696f, 0.8773f, 0.8627f, 0.0f);
                Camera.main.orthographicSize = 7;
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    public GameObject ball;
    private bool win = false;
    private List<GameObject> winBalls = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {
            DestroyBalls();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Camera.main.orthographicSize = 26;
            if (!win)
            {
                win = true;
                StartCoroutine("SpawnBalls");
            }
        }
    }

    private IEnumerator SpawnBalls()
    {
        WaitForSeconds waitTime = new WaitForSeconds(0.3f);
        Vector2 position = transform.position;
        for (int i = 0; i < 50; i++)
        {
            if(!win) { break; }
            position.x += 0.3f;
            GameObject spawnBall = Instantiate(ball, transform.position, Quaternion.identity);
            spawnBall.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            winBalls.Add(spawnBall);

            yield return waitTime;
        }

        yield return null;
    }

    private void DestroyBalls()
    {
        if (win)
        {
            foreach (var winBall in winBalls)
            {
                Destroy(winBall);
            }
            win = false;
        }
    }
}

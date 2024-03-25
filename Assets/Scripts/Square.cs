using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-3f, 3f);
        float y = Random.Range(3f, 5f);
        transform.position = new Vector3(x, y, 0);

        float size = Random.Range(3f, 10f);
        transform.localScale = new Vector3(size, size, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
        { Destroy(gameObject); }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "balloon")
        //{
        //    gameManager.Instance.gameOver();
        //}

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }

    }

}

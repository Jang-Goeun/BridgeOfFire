using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    private Rigidbody2D rigid2D;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 떨어졌으면 제거
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EnableGravityAfterDelay(3f));
        }
    }

    IEnumerator EnableGravityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rigid2D.bodyType = RigidbodyType2D.Dynamic;
    }
}

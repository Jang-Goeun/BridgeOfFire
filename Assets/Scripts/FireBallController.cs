using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    public float speed = 5f;
    GameObject director;
    bool hasHit = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -90f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasHit) return;
        if (collision.gameObject.tag == "Player")
        {
            hasHit = true;

            GameDirector gd = this.director.GetComponent<GameDirector>();
            gd.decreaseHP();

            if (gd.GetHP() <= 0)
            {
                // ü�� 0: ���ӿ��� ���常
                gd.TriggerGameOver();
            }
            else
            {
                // Ÿ�� ���� ���
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                Destroy(gameObject, audio.clip.length);
            }

            // ���� ó�� (�ð��� ����)
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            if (gd.GetHP() <= 0)
            {
                Destroy(gameObject); // ���� ���� �ٷ� ����
            }
        }
    }
}

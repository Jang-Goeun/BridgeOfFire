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
                // 체력 0: 게임오버 사운드만
                gd.TriggerGameOver();
            }
            else
            {
                // 타격 사운드 재생
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                Destroy(gameObject, audio.clip.length);
            }

            // 공통 처리 (시각적 제거)
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }

            if (gd.GetHP() <= 0)
            {
                Destroy(gameObject); // 사운드 없이 바로 삭제
            }
        }
    }
}

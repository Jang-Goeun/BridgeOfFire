using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    public AudioClip gameClearSE;
    public AudioClip gameOverSE;
    AudioSource aud;

    bool isGameOver = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        float key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1f;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1f;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if(key != 0)
        {
            transform.localScale = new Vector3(key * 1.5f, 1.5f, 1);
        }

        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f;
        }

        if (!isGameOver && transform.position.y < -10f)
        {
            isGameOver = true;
            this.rigid2D.velocity = Vector2.zero;
            this.rigid2D.bodyType = RigidbodyType2D.Kinematic;
            StartCoroutine(GameOverCoroutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(GameClearCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        Time.timeScale = 1f;
        AudioSource bgmAud = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        bgmAud.Stop();
        this.aud.PlayOneShot(gameOverSE);
        yield return new WaitForSecondsRealtime(gameOverSE.length);
        bgmAud.Play();
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator GameClearCoroutine()
    {
        Time.timeScale = 1f;
        AudioSource bgmAud = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        bgmAud.Stop();
        this.aud.PlayOneShot(gameClearSE);
        yield return new WaitForSecondsRealtime(gameClearSE.length);
        bgmAud.Play();
        SceneManager.LoadScene("GameClear");
    }
}



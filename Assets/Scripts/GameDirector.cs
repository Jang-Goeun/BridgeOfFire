using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject HPText;
    GameObject generator;
    AudioSource aud;

    private float time = 60.0f;
    private int hp = 100;
    bool isGameOver = false;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.HPText = GameObject.Find("HP");
        this.generator = GameObject.Find("FireBallGenerator");
        this.aud = GetComponent<AudioSource>();
        this.HPText.GetComponent<TextMeshProUGUI>().text = "HP " + this.hp.ToString();
    }

    void Update()
    {
        if (isGameOver) return;

        this.time -= Time.deltaTime;

        if (this.time > 50)
            this.generator.GetComponent<FireBallGenerator>().SetParameter(3.0f);
        else if (this.time > 40)
            this.generator.GetComponent<FireBallGenerator>().SetParameter(2.5f);
        else if (this.time > 30)
            this.generator.GetComponent<FireBallGenerator>().SetParameter(2.0f);
        else if (this.time > 20)
            this.generator.GetComponent<FireBallGenerator>().SetParameter(1.5f);
        else if (this.time > 10)
            this.generator.GetComponent<FireBallGenerator>().SetParameter(1.0f);
        else
            this.generator.GetComponent<FireBallGenerator>().SetParameter(0.6f);

        this.timerText.GetComponent<TextMeshProUGUI>().text = "Time " + this.time.ToString("F1");

        if (this.time <= 0)
        {
            TriggerGameOver();
        }
    }

    public void decreaseHP()
    {
        this.hp -= 10;
        this.HPText.GetComponent<TextMeshProUGUI>().text = "HP " + this.hp.ToString();
    }

    public int GetHP()
    {
        return this.hp;
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        StartCoroutine(GameOverCoroutine());
    }

    IEnumerator GameOverCoroutine()
    {
        Time.timeScale = 1f;
        AudioSource bgmAud = GameObject.Find("BGMPlayer").GetComponent<AudioSource>();
        bgmAud.Stop();
        this.aud.Play();
        yield return new WaitForSecondsRealtime(this.aud.clip.length);
        bgmAud.Play();
        SceneManager.LoadScene("GameOver");
    }
}

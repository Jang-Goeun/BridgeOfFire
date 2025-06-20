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

    float time = 60.0f;
    int hp = 100;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.HPText = GameObject.Find("HP");
        this.generator = GameObject.Find("FireBallGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        this.time -= Time.deltaTime;

        if (this.time > 50)
        {
            this.generator.GetComponent<FireBallGenerator>().SetParameter(3.0f); 
        }
        else if (this.time > 40)
        {
            this.generator.GetComponent<FireBallGenerator>().SetParameter(2.5f);
        }
        else if (this.time > 30)
        {
            this.generator.GetComponent<FireBallGenerator>().SetParameter(2.0f);
        }
        else if (this.time > 20)
        {
            this.generator.GetComponent<FireBallGenerator>().SetParameter(1.5f);
        }
        else if (this.time > 10)
        {
            this.generator.GetComponent<FireBallGenerator>().SetParameter(1.0f);
        }
        else
        {
            this.generator.GetComponent<FireBallGenerator>().SetParameter(0.6f); 
        }


        this.timerText.GetComponent<TextMeshProUGUI>().text = "Time " + this.time.ToString("F1");
        this.HPText.GetComponent<TextMeshProUGUI>().text = "HP " + this.hp.ToString();

        if (time <= 0 || hp == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void decreaseHP()
    {
        this.hp -= 10;
    }
}

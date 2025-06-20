using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallGenerator : MonoBehaviour
{
    public GameObject FireBallPrefab;
    float span = 1.0f;
    float delta = 0f;

    public void SetParameter(float span)
    {
        this.span = span;
    }
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            GameObject fireBall = Instantiate(FireBallPrefab);
            float y = Random.Range(-4, 4);
            fireBall.transform.position = new Vector3(64, y, 0);
        }
    }
}

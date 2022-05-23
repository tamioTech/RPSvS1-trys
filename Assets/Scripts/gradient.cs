using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gradient : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    Color colorLerp;

    private void Start()
    {
        //GradientThis();
    }

    void Update()
    {
        //colorLerp = Color.Lerp(Color.yellow, Color.blue, Mathf.PingPong(Time.time, 1));
        //spriteRenderer.color = colorLerp;
    }

    private void GradientThis()
    {

        
    }
}
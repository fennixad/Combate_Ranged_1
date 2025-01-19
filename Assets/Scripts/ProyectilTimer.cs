using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilTimer : MonoBehaviour
{
    float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4)
        {
            Destroy(gameObject);
            timer = 0;
        }
    }
}

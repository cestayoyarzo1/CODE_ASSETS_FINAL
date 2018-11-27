using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    float lifeTime;
    float timer;
    void Start()
    {

    }

    void Update()
    {
        if (timer > lifeTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}

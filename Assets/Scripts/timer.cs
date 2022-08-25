using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float vrijeme = 0;

    void Update()
    {
        vrijeme += Time.deltaTime;
    }
}

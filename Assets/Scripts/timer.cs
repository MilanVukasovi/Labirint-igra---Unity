using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public float vrijeme = 0;

    void Update()
    {
        vrijeme += Time.deltaTime;
    }
}

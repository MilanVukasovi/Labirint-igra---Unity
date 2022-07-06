using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zid : MonoBehaviour
{
    public Celija[] celije;
    public void ObrisiZid()
    {
        Destroy(gameObject);
    }
}

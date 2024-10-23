using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestr : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}

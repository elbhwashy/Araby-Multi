using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _DontDestroyOnLoad : MonoBehaviour
{
    public bool dontDestroyOnLoad = true;


    private void Awake()
    { 
        DontDestroyOnLoad(this.gameObject);  
    }
}

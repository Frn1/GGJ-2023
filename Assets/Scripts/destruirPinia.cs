using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirPinia : MonoBehaviour
{
    public float liveTime = 3f;
    private void Start()
    {
        Destroy(gameObject, liveTime);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}

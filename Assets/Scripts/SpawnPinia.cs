using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPinia : MonoBehaviour
{
    public GameObject pinia;
    public float timer;
    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        countdown-=Time.deltaTime;  
        if (countdown<=0)
        {
           Instantiate(pinia,transform);
           countdown = timer;
        }
       
    }
}

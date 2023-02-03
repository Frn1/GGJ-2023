using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPinia : MonoBehaviour
{
    public GameObject pinia;
    public float timer;
    private float countdown;

    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = timer;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.enabled = false;
        countdown-=Time.deltaTime;  
        if (countdown<=0)
        {
           Instantiate(pinia,transform);
           countdown = timer;
        }
       
    }
}

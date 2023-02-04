using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPinia : MonoBehaviour
{
    public GameObject pinia;
    public float timer;
    public float liveTime = 3f;
    private float countdown;

    private SpriteRenderer _spriteRenderer;
    
    // Start is called before the first frame update
    private void Start()
    {
        countdown = timer;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        _spriteRenderer.enabled = false;
        countdown-=Time.deltaTime;  
        if (countdown<=0)
        {
           GameObject piniaGameObject = Instantiate(pinia, transform);
           piniaGameObject.GetComponent<destruirPinia>().liveTime = liveTime;
           countdown = timer;
        }
       
    }
}

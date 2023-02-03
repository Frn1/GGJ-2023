using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafFall : MonoBehaviour
{
    public Collider2D leaf;
    public SpriteRenderer sprite;
    public float fallTimer,regrowTimer;
    float countdownFall,countdonRegrow;
    bool startRegrow;

    // Start is called before the first frame update
    void Start()
    {
        startRegrow= false;
        countdownFall = fallTimer;
        countdonRegrow = regrowTimer;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        leaf = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownFall<=0)
        {
            leaf.isTrigger = true;
            sprite.color = Color.gray;
            leaf.enabled = false;
        }
        if(countdonRegrow<=0)
        {
            countdownFall = fallTimer;
            sprite.color = Color.green;
            leaf.isTrigger = false;
            leaf.enabled = true;
            startRegrow = false;
            countdonRegrow = regrowTimer;
        }
        if (startRegrow==true)
        {
            countdonRegrow -= Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Piña"))
        {
            countdownFall = 0;
        }
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        countdownFall -= Time.deltaTime;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Piña"))
            countdownFall = 0;
        startRegrow = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}

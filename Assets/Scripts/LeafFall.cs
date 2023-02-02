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
        }
        if(countdonRegrow<=0)
        {
            countdownFall = fallTimer;
            sprite.color = Color.green;
            leaf.isTrigger = false;
            startRegrow = false;
            countdonRegrow = regrowTimer;
        }
        if (startRegrow==true)
        {
            countdonRegrow -= Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer== LayerMask.NameToLayer("Player"))
        countdownFall -= Time.deltaTime;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pinia"))
            countdownFall = 0;
        startRegrow = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}

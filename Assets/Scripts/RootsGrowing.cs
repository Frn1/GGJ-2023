using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootsGrowing : MonoBehaviour
{
    public float rootingDelay;
    public float rootingDuration;
    private float delay;
    private float duration;
    public Jump2D movScript;
    public SpriteRenderer pjSprite;
    public float roots;
    public bool rooted;
    public int freeRequierment;
    
    // Start is called before the first frame update
    void Start()
    {
        rooted = false;
        delay = rootingDelay;
        duration = rootingDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            freeRequierment--;
            if (movScript.isGrounded)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                if(pjSprite.color == Color.white)
                    pjSprite.color = Color.green;
                duration -= Time.deltaTime;
                if (duration<0&&!rooted)
                {
                    rooted = true;
                    freeRequierment = 4;
                    movScript.jumpReducer = .3f;
                    if (pjSprite.color == Color.green)
                        pjSprite.color = Color.red;
                }
                
            }
            if (rooted && freeRequierment <= 0)
            {
                duration = rootingDuration;
                rooted = false;
                roots = 0;
            }
            if (rooted)
            {
                roots += Time.deltaTime;
            }
        }
        else if(freeRequierment<=0)
        {
            pjSprite.color = Color.white;
            delay = rootingDelay;
        }
        if (!rooted)
            movScript.jumpReducer = 1;
    }
}

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
    public float jumpReducer;
    public bool rooted;
    public int jumpsNeededToBreakRoots = 4;
    private int freeRequierment;
    public int rootsNeededForGameOver = 4;
    private PlayerSounds sounds;

    // Start is called before the first frame update
    void Start()
    {
        rooted = false;
        delay = rootingDelay;
        duration = rootingDuration;
        sounds = GetComponent<PlayerSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (roots >= rootsNeededForGameOver)
        {
            GameManager.instance.gameOver = true;
        }
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
                    freeRequierment = jumpsNeededToBreakRoots;
                    movScript.jumpReducer = jumpReducer;
                    if (pjSprite.color == Color.green)
                        pjSprite.color = Color.red;
                    sounds.RootingAudio();
                }
                
            }
            if (rooted && freeRequierment <= 0)
            {
                duration = rootingDuration;
                rooted = false;
                roots = 0;
                sounds.UnRootingAudio();
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
        {
            movScript.jumpReducer = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class RootsGrowing : MonoBehaviour
{
    public float rootingDelay;
    public float rootingDuration;
    private float delay;
    private float duration;
    public PlayerJumpController movScript;
    public SpriteRenderer pjSprite;
    public float roots;
    public float jumpReducer;
    public bool rooted;
    public int jumpsNeededToBreakRoots = 4;
    private int freeRequierment;
    public int rootsNeededForGameOver = 4;
    public Animator rootsAnimator;
    public SpriteRenderer rootsSpriteRenderer;

    private PlayerSounds sounds;
    
    [Header("Player Feedbacks")] 
    [SerializeField] private MMFeedbacks _rootedFeedbacks;
    [SerializeField] private MMFeedbacks _unrootedFeedbacks;
    
    private void Start()
    {
        rooted = false;
        delay = rootingDelay;
        duration = rootingDuration;
        sounds = GetComponent<PlayerSounds>();
    }
    
    private void Update()
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
                /*if(pjSprite.color == Color.white)
                    pjSprite.color = Color.green;*/
                
                duration -= Time.deltaTime;
                
                if (duration<0&&!rooted)
                {
                    rooted = true;
                    rootsSpriteRenderer.enabled = true;
                    rootsAnimator.SetBool("Rooted", rooted);
                    freeRequierment = jumpsNeededToBreakRoots;
                    movScript.jumpReducer = jumpReducer;
                    
                    /*if (pjSprite.color == Color.green)
                        pjSprite.color = Color.red;*/
                    
                    _rootedFeedbacks.PlayFeedbacks();
                    //sounds.RootingAudio();
                }
                
            }
            
            if (rooted && freeRequierment <= 0)
            {
                duration = rootingDuration;
                rooted = false;
                roots = 0;
                rootsAnimator.SetBool("Rooted", rooted);
                
                _unrootedFeedbacks.PlayFeedbacks();
                //sounds.UnRootingAudio();
            }
            
            if (rooted)
            {
                roots += Time.unscaledDeltaTime;
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
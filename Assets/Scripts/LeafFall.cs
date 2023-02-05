using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class LeafFall : MonoBehaviour
{
    public Collider2D leaf;
    public SpriteRenderer sprite;
    public float fallTimer,regrowTimer;
    private float countdownFall,countdonRegrow;
    private bool startRegrow;
    public AudioClip leafFallAudio;
    private bool fall;
    Color fadeout;

    [Header("Leaf Feedbacks")]
    [SerializeField] private MMFeedbacks _FallFeedback;

    // Start is called before the first frame update
    private void Start()
    {
        fadeout = Color.white;
        fadeout.a=1;
        startRegrow = false;
        countdownFall = fallTimer;
        countdonRegrow = regrowTimer;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        leaf = gameObject.GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        sprite.color = fadeout;
        if (countdownFall<=0&& !fall)
        {
            fall = true;
            leaf.isTrigger = true;
            //sprite.color = Color.gray;
            leaf.enabled = false;
            AudioManager.instance.PlaySfx(leafFallAudio);
        }
        if(countdonRegrow<=0)
        {
            countdownFall = fallTimer;
            fadeout.a = 1;
            leaf.isTrigger = false;
            leaf.enabled = true;
            startRegrow = false;
            countdonRegrow = regrowTimer;
            fall = false;
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
        if (other.gameObject.CompareTag("Player"))
        { 
            _FallFeedback.PlayFeedbacks();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        countdownFall -= Time.deltaTime;
        fadeout.a =countdownFall/fallTimer;

    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Piña"))
        { countdownFall = 0;
            fadeout.a = 0;
        }
        startRegrow = true;
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}

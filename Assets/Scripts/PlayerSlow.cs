
using UnityEngine;

public class PlayerSlow : MonoBehaviour
{
    public float MinVelocity = 1.4f;
    public float MaxSlow=30;
    private Rigidbody2D rigidbody2D;
    public PlayerMovementController test;
    public float timer = 1;
    public float OrgTimer;
    public SpriteRenderer Pj;
    public Sprite animacion;
    public Sprite orgsprite;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        OrgTimer = timer;
        orgsprite = Pj.sprite;
    }

    private void Update()
    {
        if (Mathf.Abs(rigidbody2D.velocity.x) < MinVelocity)
        {
            timer -= Time.deltaTime;
        }
        else
            timer = OrgTimer;
        if (timer <= 0 && test.accelTime <= MaxSlow)
        {
            test.accelTime += 5 * Time.deltaTime;
            Pj.sprite = animacion;
        }

        else if (timer >= OrgTimer)
        {
            test.accelTime = 1;
            Pj.sprite = orgsprite;
        }
    }
}
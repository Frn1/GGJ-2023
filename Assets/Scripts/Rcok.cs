using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rcok : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public Vector3 Mypos;
    float direccion;
    public bool izquierda;
    // Start is called before the first frame update
    void Start()
    {
        direccion = 1;
        Mypos = this.transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.AddForce(new Vector2(direccion, 0));
        if (transform.position.x <= (Mypos.x - 2))
        {
            direccion = 1;
        }
        else if (transform.position.x >= (Mypos.x + 2))
            direccion = -1;


    }
}

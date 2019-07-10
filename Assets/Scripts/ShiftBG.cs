using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftBG : MonoBehaviour
{
    private Rigidbody2D BG_Rigidbody;
    private BoxCollider2D Lenght_Object;

    float lenght;
    
    void Start()
    {

        BG_Rigidbody = GetComponent<Rigidbody2D>();
        Lenght_Object = GetComponent<BoxCollider2D>();

        BG_Rigidbody.velocity = new Vector2(GameControl.Instance.BG_Speed, 0);

        lenght = Lenght_Object.size.x;
    }

    void Update()
    {
        if (transform.position.x < -lenght)
        {
            RepeatingBackground();
        }
    }

    void RepeatingBackground()
    {
        transform.position = (Vector2)this.transform.position + (new Vector2(lenght * 2, 0));
    }
}

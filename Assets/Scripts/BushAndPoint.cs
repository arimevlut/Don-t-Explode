using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushAndPoint : MonoBehaviour
{
    private Rigidbody2D Bush_Rigidbody;

    void Start()
    {
        Bush_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Bush_Rigidbody.velocity = new Vector2(GameControl.Instance.BG_Speed, 0);
    }
}

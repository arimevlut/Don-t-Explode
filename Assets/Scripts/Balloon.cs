using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    Rigidbody2D Balloon_Rigidbody;

    [SerializeField]
    private GameObject Explode_Effect;

    [SerializeField]
    private GameObject Bubble_Exit_Point;

    [SerializeField]
    private GameObject Bubble;

    [SerializeField]
    private float Balloon_Air;

    void Start()
    {
        Balloon_Rigidbody = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameControl.Instance.Balloon_Move();
            Balloon_Move();
        }

        Balloon_Explode();
    }

    void Balloon_Move()
    {
        Balloon_Rigidbody.velocity = new Vector2(0, 0);
        Balloon_Rigidbody.AddForce(new Vector2(0, Balloon_Air));
        Instantiate(Bubble, Bubble_Exit_Point.transform.position, Quaternion.identity);
    }

    void Balloon_Explode()
    {
        if (GameControl.Instance.isGameOver)
        {
            Destroy(this.gameObject);
            GameObject e = Instantiate(Explode_Effect, transform.position, Quaternion.identity);
            Destroy(e.gameObject, 1f);
        } 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Point")
        {
            GameControl.Instance.Score();
        }
        if (other.tag == "Bush" || other.tag == "Cactus")
        {
            GameControl.Instance.Die();
        }
    }
}

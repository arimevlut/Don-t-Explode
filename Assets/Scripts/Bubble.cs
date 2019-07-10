using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    Rigidbody2D Bubble_Rigidbody;

    [SerializeField]
    private GameObject Explode_Effect;

    float Air_Force;

    void Start()
    {
        Bubble_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Bubble_Move();
        Bubble_Explode();
    }

    void Bubble_Move()
    {
        Air_Force = Random.Range(1f, 5f);
        Bubble_Rigidbody.AddForce(new Vector2(Air_Force * -1, 0));
    }

    void Bubble_Explode()
    {
        if (GameControl.Instance.isBubbleExplode)
        {
            Destroy(this.gameObject);
            GameObject e = Instantiate(Explode_Effect, transform.position, Quaternion.identity);
            Destroy(e.gameObject, 1f);
            GameControl.Instance.isBubbleExplode = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cactus" || other.tag == "Bush")
        {
            GameControl.Instance.Bubble_Explode();
        }

    }
}

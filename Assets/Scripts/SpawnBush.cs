using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBush : MonoBehaviour
{
    [SerializeField]
    private GameObject Bush_Object;

    [SerializeField]
    private int Bush_Count = 5;

    private GameObject[] Bush;

    int count = 0;
    float Current_Time = 0;
    float Bush_X_Axis;
    float Bush_Y_Axis;

    void Start()
    {
        Bush = new GameObject[Bush_Count];

        for (int i = 0; i < Bush.Length; i++)
        {
            Bush[i] = Instantiate(Bush_Object, new Vector2(-20,-20), Quaternion.identity);
        }
    }

    void Update()
    {
        Create_Bush();
    }

    void Create_Bush()
    {
        Current_Time += Time.deltaTime;
        if (Current_Time > 2f)
        {
            Current_Time = 0;
            Bush_X_Axis = 13f;
            Bush_Y_Axis = Random.Range(-1.4f, 1.4f);
            Bush[count].transform.position = new Vector2(Bush_X_Axis, Bush_Y_Axis);
            count++;
            if (count >= Bush.Length)
            {
                count = 0;
            }
        }
    }
}

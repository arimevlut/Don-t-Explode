using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Bubble;

    public Text Total_Point;

    float Current_Total_Point;

    void Update()
    {
        Current_Total_Point = PlayerPrefs.GetFloat("Point");
        Total_Point.text = "Highest Point : " + Current_Total_Point.ToString();
    }

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

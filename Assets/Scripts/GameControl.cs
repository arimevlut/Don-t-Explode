using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl Instance;

    public float BG_Speed = -2f;
    public bool isGameOver = false;
    public bool isBubbleExplode = false;

    int point = 0;
    float Current_Color_A;
    float Current_Time;
    float Highest_Point = 0;

    [SerializeField]
    private Image GameOver_Image;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text Warning_Text;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Current_Color_A = 0f;
        GameOver_Image.color = new Color(0f, 0f, 0f, Current_Color_A);

        Warning_Text.text = "----TAP ANYWHERE TO PLAY----";
        Time.timeScale = 0f;

        Highest_Point = PlayerPrefs.GetFloat("Point");
    }

    void Update()
    {
        if (isGameOver)
        {
            BackMenu();
        }
    }

    void BackMenu()
    {
        if (Current_Color_A <= 0.8f)
        {
            Current_Color_A += 0.005f;
            GameOver_Image.color = new Color(0, 0, 0, Current_Color_A);

            Current_Time += Time.deltaTime;
            if (Current_Time >= 2f)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Balloon_Move()
    {
        Warning_Text.text = "";
        Time.timeScale = 1f;
    }

    public void Score()
    {
        point++;
        scoreText.text = "Score : " + point.ToString();
        if (point > Highest_Point)
        {
            Highest_Point = point;
            PlayerPrefs.SetFloat("Point", Highest_Point);
        }
    }

    public void Die()
    {
        isGameOver = true;
    }

    public void Bubble_Explode()
    {
        isBubbleExplode = true;
    }
}

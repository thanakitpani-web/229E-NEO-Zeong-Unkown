using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;
    public int maxScore = 143; // จำนวนเหรียญทั้งหมด
    public GameObject winText;  
    public GameObject player;
    public GameObject restartButton;
    public GameObject RestartButton;
    public GameObject exitButton;
    public GameObject creditText;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        if (winText != null)
            winText.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);

        if (exitButton != null)
            exitButton.SetActive(false);

        if (RestartButton != null)
            RestartButton.SetActive(false);

        if (creditText != null)
            creditText.SetActive(false);
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

        if (score >= maxScore)
        {
            
            winText.SetActive(true);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            RestartButton.SetActive(true);
            creditText.SetActive(true);

            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            player.GetComponent<CarController>().enabled = false;
        }
    }
}
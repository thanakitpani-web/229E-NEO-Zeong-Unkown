using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TMP_Text timerText;
    public FallReset fallReset;

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        timerText.text = "Time: " + Mathf.Ceil(timeLeft);

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isGameOver = true;

            fallReset.GameOver();
        }
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            isGameOver = true;

            fallReset.GameOver();

            
            CarController car = fallReset.GetComponent<CarController>();
            if (car != null)
                car.enabled = false;

            
            Rigidbody rb = fallReset.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
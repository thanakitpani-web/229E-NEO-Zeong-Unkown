using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class FallReset : MonoBehaviour

{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public float fallY = -5f;
    public GameObject RestartButton;
    public GameObject gameOverText;
    public GameObject restartButton;

    public Transform spawnPoint;
    private Rigidbody rb;
    private bool isGameOver = false;


    void Start()
    {

        rb = GetComponent<Rigidbody>();

        // ซ่อน UI ตอนเริ่ม
        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);

        if (RestartButton != null)
            RestartButton.SetActive(false);
    }

    void Update()
    {

        if (!isGameOver && transform.position.y < fallY)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        isGameOver = true;


        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // แสดง UI
        if (gameOverText != null)
            gameOverText.SetActive(true);

        if (restartButton != null)
            restartButton.SetActive(true);

        if (RestartButton != null)
            RestartButton.SetActive(true);
       
        CarController car = GetComponent<CarController>();
        if (car != null)
        {
            car.enabled = true;
        }
    }


}

/*public void RestartGame()
{
    isGameOver = false;

    // รีตำแหน่ง
    transform.position = spawnPoint.position;
    transform.rotation = spawnPoint.rotation;

    // รีแรง
    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;

    // รีคะแนน
    if (ScoreManager.instance != null)
    {
        ScoreManager.instance.score = 0;
        ScoreManager.instance.scoreText.text = "Score: 0";
    }
    if (gameOverText != null)
        gameOverText.SetActive(false);

    if (restartButton != null)
        restartButton.SetActive(false);

    if (RestartButton != null)
        RestartButton.SetActive(false);
    CarController car = GetComponent<CarController>();
    if (car != null)
    {
        car.ResetCar();
    }
*/
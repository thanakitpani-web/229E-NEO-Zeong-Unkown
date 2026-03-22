using UnityEngine;

public class CarAutoFlip : MonoBehaviour
{
    public float flipForce = 5f;
    public float checkDelay = 2f;

    private float timer = 0f;

    void Update()
    {
        // ถ้ารถคว่ำ (หัวลง)
        if (Vector3.Dot(transform.up, Vector3.down) > 0.5f)
        {
            timer += Time.deltaTime;

            if (timer > checkDelay)
            {
                // พลิกกลับ
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
                transform.position += Vector3.up * 1f;

                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }
}
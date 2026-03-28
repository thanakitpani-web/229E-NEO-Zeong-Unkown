/*using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float acceleration = 10f;
    public float deceleration = 5f;
    public float turnSpeed = 100f;

    private float currentSpeed = 0f;
    public void ResetCar()
    {
        currentSpeed = 0f;
    }

    void Update()
    {
        // เดินหน้า
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        // ถอยหลัง
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
        else
        {
            // ไม่กดอะไร = ค่อยๆ ช้าลง
            if (currentSpeed > 0)
                currentSpeed -= deceleration * Time.deltaTime;
            else if (currentSpeed < 0)
                currentSpeed += deceleration * Time.deltaTime;
        }

        // จำกัดความเร็ว (ทั้งหน้าและหลัง)
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // หมุนรถ
        float turn = 0f;
        if (Input.GetKey(KeyCode.A)) turn = -1f;
        if (Input.GetKey(KeyCode.D)) turn = 1f;

        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

        // เคลื่อนที่
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }

}*/
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 30f;
    public float acceleration = 10f;
    public float deceleration = 5f;
    public float turnSpeed = 100f;

    private float currentSpeed = 0f;
    private float currentTurn = 0f; // ⭐ เพิ่ม

    public void ResetCar()
    {
        currentSpeed = 0f;
        currentTurn = 0f;
    }

    void Update()
    {
        // เดินหน้า / ถอย
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= acceleration * Time.deltaTime;
        }
        else
        {
            if (currentSpeed > 0)
                currentSpeed -= deceleration * Time.deltaTime;
            else if (currentSpeed < 0)
                currentSpeed += deceleration * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        // 🎯 เลี้ยวแบบสมูท
        float targetTurn = 0f;

        if (Input.GetKey(KeyCode.A)) targetTurn = -1f;
        if (Input.GetKey(KeyCode.D)) targetTurn = 1f;

        currentTurn = Mathf.Lerp(currentTurn, targetTurn, 5f * Time.deltaTime);

        transform.Rotate(0, currentTurn * turnSpeed * Time.deltaTime, 0);

        // เคลื่อนที่
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
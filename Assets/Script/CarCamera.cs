using UnityEngine;

public class CarCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 frontOffset = new Vector3(0, 3, -6); // ด้านหลังรถ
    public Vector3 backOffset = new Vector3(0, 3, 6); // ด้านหน้ารถ

    public float smoothTime = 0.1f;

    Vector3 velocity = Vector3.zero;
    Rigidbody rb;

    void Start()
    {
        rb = target.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 🔥 ตรวจว่ารถกำลังถอยหรือไม่
        float forwardSpeed = Vector3.Dot(rb.velocity, target.forward);

        Vector3 offset;

        if (forwardSpeed < 0) // ถอยหลัง
            offset = backOffset;
        else                  // วิ่งไปข้างหน้า
            offset = frontOffset;

        Vector3 desiredPosition = target.TransformPoint(offset);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref velocity,
            smoothTime
        );

        transform.LookAt(target);
    }
}
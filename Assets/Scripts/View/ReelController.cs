using UnityEngine;

public class ReelController : MonoBehaviour
{
    private float speed;
    private float targetSpeed;
    private float acceleration = 30f;
    private bool spinning;

    public void StartSpin()
    {
        targetSpeed = 800f;
        spinning = true;
    }

    public void StopSpin()
    {
        targetSpeed = 0f;
    }

    private void Update()
    {
        if (!spinning) return;

        speed = Mathf.MoveTowards(speed, targetSpeed, acceleration * Time.deltaTime);
        transform.Rotate(Vector3.down * speed * Time.deltaTime);

        if (speed == 0f && targetSpeed == 0f)
        {
            spinning = false;
            Debug.Log("Reel fully stopped");
        }
    }
}
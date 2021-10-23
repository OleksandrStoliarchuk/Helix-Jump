using UnityEngine;

public class RotateTower : MonoBehaviour
{
    private float speedRotate = 30f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * speedRotate * Time.deltaTime;
                var rotateTowerY = transform.eulerAngles.y - torque;
                transform.rotation = Quaternion.Euler(0, rotateTowerY, 0);
            }                
        }
    }
}

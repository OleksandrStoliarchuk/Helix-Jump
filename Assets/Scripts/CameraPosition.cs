using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private float _localBallPosY = 3;
    private Ball _ball;

    private void Awake()
    {
        _ball = FindObjectOfType<Ball>();
        CameraPos();
    }

    private void Update()
    {
        if (_ball.Local.y < -_localBallPosY || _ball.Local.y > _localBallPosY)
            CameraPos();
    }

    private void CameraPos()
    {
        float yCameraPos = _ball.transform.position.y + 1.5f;
        var cameraPos = new Vector3(0, yCameraPos, -3.5f);
        var cameraRotate = Quaternion.Euler(30, 0, 0);
        transform.position = cameraPos;
        transform.rotation = cameraRotate;
    }
}

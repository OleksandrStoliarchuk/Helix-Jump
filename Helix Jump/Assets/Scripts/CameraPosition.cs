using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject tower, ball;

    private void Awake()
    {
        tower = GameObject.Find("GameController");

        ball = GameObject.Find("Ball(Clone)");
        CamPos();
    }

    private void Update()
    {
        if (ball.GetComponent<Ball>().local.y < -3f || ball.GetComponent<Ball>().local.y > 3f)
            CamPos();
    }

    private void CamPos()
    {
        transform.position = new Vector3(0, ball.transform.position.y + 1f, -3.5f);
        transform.rotation = Quaternion.Euler(30, 0, 0);
    }
}

using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject beam, startPlatform, finishPlatform;
    public GameObject[] platforms;
    public Ball ball;
    public float level;
    [HideInInspector]
    public GameObject _beam, _startPlatform, _finishPlatform, _platforms;

    private void Awake()
    {
        Tower();
    }

    private void Tower()
    {
        level = Random.Range(10, 30);

        CreateBeam();
        CreateStartPlatform();
        CreateFinishPlatform();
        CreateBall();

        Vector3 pos = _beam.transform.position;
        pos.y = 1;
        pos.y -= _beam.transform.localScale.y;

        for (int i = 3; i < level; i++)
        {
            CreatePlatforms(platforms[Random.Range(0, platforms.Length)], ref pos, Quaternion.Euler(0, Random.Range(0, 360), 0), _beam);
        }
    }

    private void CreateBeam()
    {
        _beam = Instantiate(beam, Vector3.zero, Quaternion.identity);
        _beam.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        _beam.transform.localScale = new Vector3(1, level / 2, 1);
    }

    private void CreateStartPlatform()
    {
        _startPlatform = Instantiate(startPlatform, _beam.transform);
        _startPlatform.transform.position = new Vector3(_beam.transform.position.x, _beam.transform.position.y + level/2 - 2, _beam.transform.position.z);
        ScalePlatform(_startPlatform);
    }

    private void CreateFinishPlatform()
    {
        _finishPlatform = Instantiate(finishPlatform, _beam.transform);
        _finishPlatform.transform.position = new Vector3(_beam.transform.position.x, _beam.transform.position.y - level / 2, _beam.transform.position.z);
        ScalePlatform(_finishPlatform);
    }

    private void CreatePlatforms(GameObject platform, ref Vector3 pos, Quaternion rotate, GameObject parent)
    {
        _platforms = Instantiate(platform, pos, rotate, parent.transform);
        pos.y += 1;
        ScalePlatform(_platforms);
    }

    private void ScalePlatform(GameObject platform)
    {
        platform.transform.localScale = new Vector3(1, 2 / level, 1);
    }

    private void CreateBall()
    {
        Instantiate(ball, new Vector3(0, _startPlatform.transform.position.y + 1f, -0.85f), Quaternion.identity);
    }
}

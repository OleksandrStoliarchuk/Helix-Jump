using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static bool IsPlay;
    [SerializeField] private Button nextLevel;
    [SerializeField] private GameObject beam, startPlatform, finishPlatform;
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private Ball ball;
    private float _countPlatforms; 
    private GameObject _beam, _startPlatform;

    private void Awake()
    {
        IsPlay = true;
        SpawnTower();
    }

    private void Update()
    {
        if(!IsPlay)
            nextLevel.gameObject.SetActive(true);
    }

    private void SpawnTower()
    {
        int minCountPlatforms = 10;
        int maxCountPlatforms = 30;
        _countPlatforms = Random.Range(minCountPlatforms, maxCountPlatforms);

        SpawnBeam();
        SpawnStartPlatform();
        SpawnFinishPlatform();
        SpawnBall();

        Vector3 pos = _beam.transform.position;
        pos.y = 1;
        pos.y -= _beam.transform.localScale.y;

        int startSpawnPlatform = 3;
        for (int i = startSpawnPlatform; i < _countPlatforms; i++)
        {
            float minYRotate = 0;
            float maxYRotate = 360;
            float yRangeRotate = Random.Range(minYRotate, maxYRotate);
            var rotatePlatform = Quaternion.Euler(0, yRangeRotate, 0);
            int indexPlatforms = Random.Range(0, platforms.Length);
            SpawnPlatforms(platforms[indexPlatforms], ref pos, rotatePlatform, _beam);
        }
    }

    private void SpawnBeam()
    {
        float minYRotate = 0;
        float maxYRotate = 360;
        float yRangeRotate = Random.Range(minYRotate, maxYRotate);
        _beam = Instantiate(beam, Vector3.zero, Quaternion.identity);
        _beam.transform.rotation = Quaternion.Euler(0, yRangeRotate, 0);
        _beam.transform.localScale = new Vector3(1, _countPlatforms / 2, 1);
    }

    private void SpawnStartPlatform()
    {
        _startPlatform = Instantiate(startPlatform, _beam.transform);
        var beamPosition = _beam.transform.position;
        _startPlatform.transform.position = new Vector3(beamPosition.x, beamPosition.y + _countPlatforms / 2 - 2, beamPosition.z);
        SetScalePlatform(_startPlatform);
    }

    private void SpawnFinishPlatform()
    {
        var _finishPlatform = Instantiate(finishPlatform, _beam.transform);
        var beamPosition = _beam.transform.position;
        _finishPlatform.transform.position = new Vector3(beamPosition.x, beamPosition.y - _countPlatforms / 2, beamPosition.z);
        SetScalePlatform(_finishPlatform);
    }

    private void SpawnPlatforms(GameObject platform, ref Vector3 pos, Quaternion rotate, GameObject parent)
    {
        float yDistanceBetweenPlatforms = 1;
        var _platforms = Instantiate(platform, pos, rotate, parent.transform);
        pos.y += yDistanceBetweenPlatforms;
        SetScalePlatform(_platforms);
    }

    // Set scalePlatform depending on the scaleTower
    private void SetScalePlatform(GameObject platform)
    {
        float scalePlatformYDependingOnTheScaleTower = 2;
        float scalePlatformY = scalePlatformYDependingOnTheScaleTower / _countPlatforms;
        Vector3 scalePlatform = new Vector3(1, scalePlatformY, 1);
        platform.transform.localScale = scalePlatform;
    }

    private void SpawnBall()
    {
        float spawnPosY = _startPlatform.transform.position.y + 0.5f;
        float spawnPosZ = -0.85f;
        Vector3 spawnPos = new Vector3(0, spawnPosY, spawnPosZ);
        Instantiate(ball, spawnPos, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private int _levelCont;
    [SerializeField] private float _adittionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _startPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatfrom _finishPlatform;

    private float _startAndFinishAdditionalScale = 0.05f;

    public float BeamScaleY => _levelCont + _startAndFinishAdditionalScale + _adittionalScale/2;

    private void Awake()
    {
        Build();
    }

    private void Build() 
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(3, BeamScaleY, 3);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.lossyScale.y - _adittionalScale;

        SpawnStartPlatform(_startPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCont/1.9f; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0,Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 3.5f; 
    }

    private void SpawnStartPlatform(Platform startPlatform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(startPlatform, spawnPosition, Quaternion.Euler(0,0,0), parent);
        spawnPosition.y -= 3.5f;
    }
}

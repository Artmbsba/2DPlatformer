using System;
using UnityEngine;

[RequireComponent(typeof(DistanceDetection))]
public class SpawnerPoint : MonoBehaviour
{
    private DistanceDetection _distanceDetection;
    private bool _isSpawned = false;

    public event Action<SpawnerPoint> GiveSpawnCommand;

    public bool IsSpawned => _isSpawned;

    private void Awake()
    {
        _distanceDetection = GetComponent<DistanceDetection>();
    }

    private void OnEnable()
    {
        _distanceDetection.TargetCameUpForSpawning += GiveCommand;
    }

    private void OnDisable()
    {
        _distanceDetection.TargetCameUpForSpawning -= GiveCommand;
    }

    private void GiveCommand()
    {
        if (_isSpawned == false)
        {
            GiveSpawnCommand?.Invoke(this);

            _isSpawned = true;
        }
    }
}
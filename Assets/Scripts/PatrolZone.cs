using UnityEngine;

[RequireComponent(typeof(SpawnerPoint))]
public class PatrolZone : PatrolPoint
{
    [SerializeField] private Enemy _enemyPrefab;

    private SpawnerPoint _spawnerPoint;

    public Enemy EnemyPrefab => _enemyPrefab;

    private void Awake()
    {
        _spawnerPoint = GetComponent<SpawnerPoint>();
    }
}
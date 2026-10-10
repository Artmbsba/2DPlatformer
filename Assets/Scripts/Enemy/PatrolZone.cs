using UnityEngine;

public class PatrolZone : SpawnerPoint
{
    [SerializeField] private Enemy _enemyPrefab;

    public Enemy EnemyPrefab => _enemyPrefab;        
}
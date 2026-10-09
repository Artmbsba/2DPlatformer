using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnerPoint[] _spawnerPoints;

    private void OnEnable()
    {
        foreach (SpawnerPoint spawnerPoint in _spawnerPoints)
            spawnerPoint.GiveSpawnCommand += Spawn;
    }

    private void OnDisable()
    {
        foreach (SpawnerPoint spawnerPoint in _spawnerPoints)
            spawnerPoint.GiveSpawnCommand -= Spawn;
    }

    private void Spawn(Transform transformSpawnerPoint)
    {
        if (transformSpawnerPoint.TryGetComponent<PatrolZone>(out PatrolZone patrolZone))
            SpawnEnemy(patrolZone);
        else if (transformSpawnerPoint.TryGetComponent<CoinPoint>(out CoinPoint coinPoint))
            SpawnCoin(coinPoint);
    }

    private void SpawnEnemy(PatrolZone patrolZone)
    {
        Enemy newEnemy = Instantiate(patrolZone.EnemyPrefab, patrolZone.transform.position, Quaternion.identity);

        newEnemy.SetPatrolZone(patrolZone);
    }

    private void SpawnCoin(CoinPoint coinPoint)
    {
        Instantiate(coinPoint.CoinPrefab, coinPoint.transform.position, Quaternion.identity);
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        int pointCount = transform.childCount;
        _spawnerPoints = new SpawnerPoint[pointCount];

        for (int i = 0; i < pointCount; i++)
            _spawnerPoints[i] = transform.GetChild(i).GetComponent<SpawnerPoint>();
    }
#endif
}

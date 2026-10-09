using UnityEngine;

[RequireComponent(typeof(SpawnerPoint))]
public class CoinPoint : PatrolPoint
{
    [SerializeField] private Coin _coinPrefab;

    private SpawnerPoint _spawnerPoint;

    public Coin CoinPrefab => _coinPrefab;

    private void Awake()
    {
        _spawnerPoint = GetComponent<SpawnerPoint>();
    }
}
using UnityEngine;

public class CoinPoint : SpawnerPoint
{
    [SerializeField] private Coin _coinPrefab;

    public Coin CoinPrefab => _coinPrefab;
}
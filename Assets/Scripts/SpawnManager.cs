using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private int _spawningInterval;
    [SerializeField] private Transform _spawnersHandler;
    private Transform[] _spawners;
    private Coroutine _spawnRoutine;

    private void Start()
    {
        _spawners = new Transform[_spawnersHandler.childCount];

        for (int i = 0; i < _spawnersHandler.childCount; i++)
        {
            _spawners[i] = _spawnersHandler.GetChild(i);
        }

        _spawnRoutine = StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var interval = new WaitForSeconds(2);

        for (int i = 0; i < _spawners.Length; i++)
        {
            Instantiate(_enemy, _spawners[i].position, Quaternion.identity);
            Debug.Log("Spawned");

            if (i == _spawners.Length)
            {
                i = 0;
                Debug.Log("Reset");
            }

            yield return interval;
        }
    }
}

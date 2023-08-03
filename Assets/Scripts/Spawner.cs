using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
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

        _spawnRoutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var interval = new WaitForSeconds(2);

        for (int i = 0; i < _spawners.Length; i++)
        {
            Instantiate(_enemy, _spawners[i].position, Quaternion.identity);

            if (i == _spawners.Length-1)
            {
                i = -1;
            }

            yield return interval;
        }
    }
}

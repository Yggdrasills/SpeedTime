using System.Collections;
using UnityEngine;

namespace SpeedTime.Game
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints = null;
        [SerializeField] private GameObject[] _prefabs = null;
        [SerializeField] private float _minSpawnTime = 1f;
        [SerializeField] private float _maxSpawnTime = 2.5f;
        private int _lastPoint = -1;

        private void Start()
        {
            StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {            
            while (true)
            {
                int enemyIndex = Random.Range(0, _prefabs.Length);
                int spawnIndex = GetRandomSpawnIndex();

                Instantiate(_prefabs[enemyIndex], _spawnPoints[spawnIndex].position, Quaternion.identity, null);

                yield return new WaitForSeconds(Random.Range(_minSpawnTime, _maxSpawnTime));
            }
        }

        private int GetRandomSpawnIndex()
        {
            int newPointIndex = Random.Range(0, _spawnPoints.Length);

            while (newPointIndex == _lastPoint)
            {
                newPointIndex = Random.Range(0, _spawnPoints.Length);
            }
            _lastPoint = newPointIndex;

            return newPointIndex;
        }
    }
}
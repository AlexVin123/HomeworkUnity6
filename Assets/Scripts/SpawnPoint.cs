using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _gameObjectForSpawn;
    [SerializeField] private float _timeToSpawn;

    private WaitForSeconds _timer;
    private GameObject _gameObjectOnScene;
    private bool _isSpawn;

    private void Start()
    {
        _timer = new WaitForSeconds(_timeToSpawn);
        Spawn();
        _isSpawn = true;
        StartCoroutine(ControlSpawn());
    }

    private IEnumerator ControlSpawn()
    {
        while(true)
        {
            if (_isSpawn == false)
            {
                yield return _timer;
                Spawn();
                _isSpawn = true;
            }
            else if (_gameObjectOnScene == null)
            {
                _isSpawn = false;
            }

            yield return null;
        }        
    }

    private void Spawn()
    {
        _gameObjectForSpawn.transform.position = transform.position;
        _gameObjectOnScene = Instantiate(_gameObjectForSpawn);
    }
}

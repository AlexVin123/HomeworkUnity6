using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _timeToSpawn;

    private float _timer;
    private GameObject _gameObjectOnScene;
    private bool isSpawn;

    private void Start()
    {
        Spawn();
        isSpawn = true;
    }

    private void Update()
    {
        if (isSpawn == false)
        {
            if (_timer >= _timeToSpawn)
            {
                Spawn();
                isSpawn = true;
                _timer = 0;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }
        else if (_gameObjectOnScene == null)
        {
            isSpawn = false;
        }
    }

    private void Spawn()
    {
        if (_gameObject != null)
        {
            _gameObject.transform.position = transform.position;
            _gameObjectOnScene = Instantiate(_gameObject);
        }            
    }
}

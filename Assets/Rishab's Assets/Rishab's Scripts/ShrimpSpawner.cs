using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrimpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject FlyingShrimp;
    [SerializeField] private GameObject SwimmingShrimp;
    private float _spawnTime = 5f;

    void Start()
    {
        // hi
    }

    void Update()
    {
        // When beat is current call spawnflyingshrimp or spawnswimmingshrimp
        _spawnTime -= Time.deltaTime;
        if (_spawnTime < 0)
        {
            SpawnSwimmingShrimp();
            SpawnFlyingShrimp();
            _spawnTime = 4f;
        }
    }

    void SpawnFlyingShrimp()
    {
        Vector2 location = Camera.main.ViewportToWorldPoint(new Vector2(0.75f, 0.1f));
        GameObject flyingShrimp = (GameObject)Instantiate(FlyingShrimp);
        flyingShrimp.transform.position = location;
    }
    
    void SpawnSwimmingShrimp()
    {
        Vector2 location = Camera.main.ViewportToWorldPoint(new Vector2(1f, 0.25f));
        GameObject swimmingShrimp = (GameObject)Instantiate(SwimmingShrimp);
        swimmingShrimp.transform.position = location;
    }
}

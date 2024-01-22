using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwimmingShrimpController : MonoBehaviour
{

    private float _tempoX;
    private float _initialSpeed;
    private float _timeStamp;

    void Start()
    {
        _tempoX = 240f / 60f;
        _initialSpeed = _tempoX;
        _timeStamp = ShrimpSpawner.Instance.CurrentTimeStamp;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - _tempoX * Time.deltaTime, position.y);
        transform.position = position;

        if (transform.position.x < -3f)
            Destroy(gameObject);

        if (_timeStamp - 0.1f <= GameMusicManager.Instance.Audio.time && GameMusicManager.Instance.Audio.time <= _timeStamp + 0.2f)
        {
            PlayerController.Instance.LowerAttackable = true;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ScoreHolder.Instance.Score += 10;
                Destroy(gameObject);
                PlayerController.Instance.LowerAttackable = false;
            }
        }
        if (transform.position.x < 959f) _tempoX = _initialSpeed * 2;
        if (transform.position.x < 945) Destroy(gameObject);
    }
}

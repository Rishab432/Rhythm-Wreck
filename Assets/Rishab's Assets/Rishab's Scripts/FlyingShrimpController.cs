using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShrimpController : MonoBehaviour
{
    private float _tempoX;
    private float _jumpHeight = 400f;
    private Rigidbody2D _rb;
    private float _timeStamp;

    void Start()
    {
        _tempoX = 120f / 60f;
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(0f, _jumpHeight));
        _timeStamp = ShrimpSpawner.Instance.CurrentTimeStamp;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - _tempoX * Time.deltaTime, position.y);
        transform.position = position;

        if (_timeStamp - 0.1f <= GameMusicManager.Instance.Audio.time && GameMusicManager.Instance.Audio.time <= _timeStamp + 0.2f)
        {
            PlayerController.Instance.UpperAttackable = true;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ScoreHolder.Instance.Score += 10;
                Destroy(gameObject);
                PlayerController.Instance.UpperAttackable = false;
            }
        }
        if (transform.position.y < 535) Destroy(gameObject);
    }
}

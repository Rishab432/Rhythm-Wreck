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
    private SpriteRenderer[] _spriteRenderers;

    void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _tempoX = 120f / 60f;
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(0f, _jumpHeight));
        _timeStamp = ShrimpSpawner.Instance.CurrentTimeStamp;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.Instance.Paused)
        {
            foreach (SpriteRenderer spriteRenderer in _spriteRenderers)
            {
                if (!spriteRenderer.enabled) break;
                spriteRenderer.enabled = false;
            }
        }
        else
        {
            foreach (SpriteRenderer spriteRenderer in _spriteRenderers)
            {
                if (spriteRenderer.enabled) break;
                spriteRenderer.enabled = true;
            }
        }

        Vector2 position = transform.position;
        position = new Vector2(position.x - _tempoX * Time.deltaTime, position.y);
        transform.position = position;

        if (PlayerController.Instance.Guiders && _timeStamp - 0.2f <= GameMusicManager.Instance.Audio.time)
        {
            foreach (SpriteRenderer renderer in _spriteRenderers)
            {
                renderer.color = Color.yellow;
            }
        }
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
        if (GameMusicManager.Instance.Audio.time > _timeStamp + 0.2f)
        {
            foreach (SpriteRenderer renderer in _spriteRenderers)
            {
                renderer.color = Color.white;
            }
        }
        if (transform.position.y < 535) Destroy(gameObject);
    }
}

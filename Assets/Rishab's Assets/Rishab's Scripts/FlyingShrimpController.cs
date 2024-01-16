using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShrimpController : MonoBehaviour
{
    private float _tempoX;
    public float JumpHeight = 400f;
    private Rigidbody2D _rb;
    public float Peak = 5f;

    void Start()
    {
        _tempoX = 120f / 60f;
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(0f, JumpHeight));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - _tempoX * Time.deltaTime, position.y);
        transform.position = position;
        if (959 < transform.position.x && transform.position.x < 961)
        {
            PlayerController.Instance.UpperAttackable = true;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Destroy(gameObject);
                Debug.Log("nice swipe!");
                PlayerController.Instance.UpperAttackable = false;
            }
        }
        if (transform.position.y < 535) Destroy(gameObject);
    }
}

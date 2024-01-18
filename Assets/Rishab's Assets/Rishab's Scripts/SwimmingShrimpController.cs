using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwimmingShrimpController : MonoBehaviour
{

    private float _tempoX;
    private float _initialSpeed;

    void Start()
    {
        _tempoX = 120f / 60f;
        _initialSpeed = _tempoX;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x - _tempoX * Time.deltaTime, position.y);
        transform.position = position;

        if (transform.position.x < -3f)
            Destroy(gameObject);

        if (959f < transform.position.x && transform.position.x < 961f)
        {
            PlayerController.Instance.LowerAttackable = true;
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Destroy(gameObject);
                Debug.Log("nice swipe!");
                PlayerController.Instance.LowerAttackable = false;
            }
        }
        if (transform.position.x < 959f) _tempoX = _initialSpeed * 2;
        if (transform.position.x < 945) Destroy(gameObject);
    }
}

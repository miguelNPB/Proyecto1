using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;
    [SerializeField] private bool _cicle;
    private Rigidbody2D _enemyRigidbody;
    private int i;
    private bool forward;
    
    void FixedUpdate()
    {
        if (_cicle)
        {
            if (i < _points.Length)
            {
                if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                {
                    Vector2 desiredPoint = Vector2.MoveTowards(_enemyRigidbody.position, _points[i].position, _speed * Time.deltaTime);
                    _enemyRigidbody.MovePosition(desiredPoint);
                }
                else
                    i++;
            }
            else
            {
                i = 0;
            }
        }
        else
        {
            if (i < _points.Length && forward)
            {
                if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                {
                    Vector2 desiredPoint = Vector2.MoveTowards(_enemyRigidbody.position, _points[i].position, _speed * Time.deltaTime);
                    _enemyRigidbody.MovePosition(desiredPoint);
                }
                else
                    i++;
            }
            else if (i > 0 && !forward)
            {
                if (Vector2.Distance(_enemyRigidbody.position, _points[i].position) > 0.1f)
                {
                    Vector2 desiredPoint = Vector2.MoveTowards(_enemyRigidbody.position, _points[i].position, _speed * Time.deltaTime);
                    _enemyRigidbody.MovePosition(desiredPoint);
                }
                else
                    i--;
            }
            else
            {
                forward = !forward;
                if (!forward)
                    i--;
            }
        }
    }
    void Start()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        i = 0;
        forward = true;
    }
}

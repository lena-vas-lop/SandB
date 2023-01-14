using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public GameObject HeadSnake;
    public Vector3 delta;
    public float Speed;
    private Vector3 _delta;
    private Vector3 _pos;
    private void Start()
    {
        _delta.x = HeadSnake.transform.position.x - delta.x;
        _pos=transform.position;
    }
    void Update()
    {
        _pos.x = HeadSnake.transform.position.x - _delta.x;
        transform.position = Vector3.MoveTowards(transform.position, _pos, Speed * Time.deltaTime);
    }
}

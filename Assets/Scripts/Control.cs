using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Rigidbody rb;
    public float SpeedSnake;
    public float SpeedRot;
    private Vector3 _m_position;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 Vector = new Vector3(SpeedSnake, 0f, 0f);
        rb.AddForce(Vector * Time.deltaTime, ForceMode.Acceleration);
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _m_position;
            Vector3 vector = new Vector3( 0f, 0f, delta.x *SpeedRot);
            rb.AddForce(vector,ForceMode.VelocityChange);
        }
        _m_position = Input.mousePosition;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera camera;

    public float speed;

    private Vector3 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
        Inputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Move()
    {

        mousePos.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
    }

    private void Rotate()
    {
        float zRot = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.localEulerAngles = Quaternion.Euler(0f,0f, zRot).eulerAngles;
    }
}

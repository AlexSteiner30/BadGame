using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;
    public Rigidbody2D rb;

    public float speed;

    private Vector3 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;

        transform.position = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
    }

    private void Rotate()
    {
        float zRot = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.localEulerAngles = Quaternion.Euler(0f,0f, zRot).eulerAngles;
    }
}

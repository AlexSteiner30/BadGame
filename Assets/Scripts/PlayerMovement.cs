using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    public Camera camera;
    public Rigidbody2D rb;

    public float speed;

    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Inputs();
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Inputs()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void Move()
    {
        transform.Translate((transform.up * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal")).normalized * speed * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        float zRot = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(0f,0f, zRot);
    }
}

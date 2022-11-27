using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform origin;
    public GameObject bullet;
    public float speed;
    public float zRot;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            GameObject bulletInstantiated = Instantiate(bullet, origin.position, Quaternion.identity);
            bulletInstantiated.transform.rotation = Quaternion.Euler(0, 0, zRot);

            yield return new WaitForSeconds(1f);
        }
    }

    public void Move(float yPos)
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed * yPos);

        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -screenBounds.y + 1, screenBounds.y - 1));
    }
}

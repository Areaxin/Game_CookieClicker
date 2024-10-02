using System;
using UnityEngine;

public class CookieParticle : MonoBehaviour
{
    public float speed = 5;

    private void Start()
    {
        Destroy(gameObject,3f);
    }

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}

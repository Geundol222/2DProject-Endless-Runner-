using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTransform : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Time.timeScale = 1.0f;
        player.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
        if (player.position.x > endPoint.position.x)
            player.position = endPoint.position;

    }
}

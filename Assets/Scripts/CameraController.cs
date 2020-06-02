using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float smooth;

    void FixedUpdate()
    {
        if(Player.position.y > transform.position.y)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, Player.position.y, -10), smooth * Time.fixedDeltaTime);
        }
    }
}

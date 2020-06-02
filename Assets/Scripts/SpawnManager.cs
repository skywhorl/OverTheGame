using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float Y = -8.0f;
    private float nextY = 5f;
    private float x1 = 0.0f;
    private float x2 = 10.0f;
    public GameObject Block_Red;
    public GameObject Block_Blue;
    public GameObject Block_Green;
    public GameObject Player_Space;
    public string playername;


    void Start()
    {
        Player_Space = GameObject.Find(playername);
    }


    void Update()
    {
        if (Player_Space.gameObject.transform.position.y > Y)
        {
            x1 = Random.Range(-13.0f, 2f);
            x2 = Random.Range(-2f, 13.0f);

            if (x2-x1 > 10f&&x2-x1<20f)
            {
                Y += 2.0f; // 플레이어가 올라오는 위치
                nextY += 6.0f; // 플레이어가 올라오는 위치만큼 미리 스폰할 자리
                Instantiate(Block_Blue, new Vector2(x1, nextY), Block_Blue.transform.rotation);
                Instantiate(Block_Green, new Vector2(x2, nextY), Block_Green.transform.rotation);
            }
        }

       
    }
}

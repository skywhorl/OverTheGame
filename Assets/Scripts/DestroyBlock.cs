using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    public GameObject Bottom;
    public GameObject Block;

    // 바닥과 블록 오브젝트 검색
    void Start()
    {
        Bottom = GameObject.Find("Bottom");
        Block = GameObject.Find("Block");
    }
    // 블록이 바닥의 아래로부터 거리가 5를 넘으면 오브젝트 지우기
    void Update()
    {
        if (Bottom.transform.position.y-5 > this.gameObject.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}

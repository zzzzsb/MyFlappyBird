using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 왼쪽으로 계속 이동하고 싶다.
// - 속력 
public class Pipe : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 계속 이동하고 싶다.
        // 2. 왼쪽으로
        // 이동공식
        // P = P0 + vt
        // 현재위치 = 이전위치 + 속도 * 시간
        // 내일의나 = 오늘의나 + 오늘한일 * 시간
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}

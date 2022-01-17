using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 위치를 왔다갔다 하면서 애니메이션 처리를 하고싶다.
// - 원래 위치
// - 움직일 위치
// - 움직일 시간
// - 현재 시간

public class Floor : MonoBehaviour
{
    // - 원래 위치
    Vector3 origin;
    // - 움직일 간격
    public float gapX;
    // - 움직일 시간
    public float moveTime;
    // - 현재 시간
    float currentTime;
    // - 현재 위치에 있는가?
    bool isOrigin;

    // Start is called before the first frame update
    void Start()
    {
        // 태어날 때 원래 위치를 기억하고싶다.
        origin = transform.position;
        isOrigin = true;
    }

    // Update is called once per frame
    void Update()
    {
        // 일정시간마다 위치를 왔다 갔다 하고싶다.
        // 1. 시간이 흐르다가
        currentTime += Time.deltaTime;
        // 2. 만약 현재시간이 움직일 시간이 되었다면
        if (currentTime > moveTime)
        {
            currentTime = 0;
            // 3. 위치를 바꾸고 싶다.
            // 현재 위치가 원래 위치였으면? 저쪽으로 보내고
            if (isOrigin == true)
            {
                transform.position = origin + Vector3.right * gapX;
                isOrigin = false;
            }
            // 현재 위치가 저쪽이었으면? 원래 위치로 보내고 싶다
            else
            {
                transform.position = origin;
                isOrigin = true;
            }
        }

    }
}

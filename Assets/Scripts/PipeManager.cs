using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일정시간마다 Pipe공장에서 Pipe를 생성하고 Y위치(-2.2~2.76)를 랜덤으로 정해주고 싶다. (대본)
// - 현재시간
// - 생성시간
// - 파이프공장
// - Y Min
// - Y Max
public class PipeManager : MonoBehaviour
{
    // 싱글톤
    public static PipeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // - 현재시간
    float currentTime;
    // - 생성시간
    public float createTime = 2;
    // - 파이프공장
    public GameObject pipeFactory;
    // - Y Min
    public float minY;
    // - Y Max
    public float maxY;

    public bool isDoing;

    // Start is called before the first frame update
    void Start()
    {
        isDoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (false == isDoing)
        {
            return;
        }        // 프로그래머 입장에서 바꾸
        // 현재시간이 흐르다가
        currentTime += Time.deltaTime;
        // 현재시간이 일정시간이 되면
        if (currentTime > createTime)
        {
            currentTime = 0;
            // Pipe공장에서 Pipe를 생성하고
            GameObject pipe = Instantiate(pipeFactory);
            // Y위치(-2.2~2.76)를 랜덤으로 정해주고 싶다.
            Vector3 pos = transform.position;
            pos.y = Random.Range(-2.2f, 2.76f);
            pipe.transform.position = pos;
        }

    }
}

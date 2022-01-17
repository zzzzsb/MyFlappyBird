using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 충돌 (영역에 닿은 애들을 없애기 위해!)
    // -> 물리적인 충돌(OnCollisionEnter2D) 
    // -> 감지 충돌 (OnTriggerEnter2D, 충돌체에 isTrigger가 체크되어야 한다.)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1. 부딪힌 애 이름이 Pipe1이라면
        if (other.name.Contains("Pipe1"))
        {
            // 2. 그 애의 부모 게임오브젝트를 파괴하고 싶다.
            Destroy(other.transform.parent.gameObject);
        }
        print(other.name);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

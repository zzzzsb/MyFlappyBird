using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 왼쪽 버튼을 누르면 위로 점프하고 싶다.
public class Bird : MonoBehaviour
{
    // 준비 상태
    // 게임 중 상태
    // 게임 오버 상태
    // 열거형 enum (하나의 자료형: State라는 자료형이 생김)
    enum State
    {
        Ready,
        Playing,
        GameOver
    }

    State state;

    // 점프 파워
    public float jumpPower = 6;
    Rigidbody2D rb;
    public float upAngle = 45f;
    public float downAngle = 120f;
    public float limitAngle = -90;

    // Start is called before the first frame update
    void Start()
    {
        //태어날 때 Rigidbody2D를 가져와서 사용하고 싶다.
        rb = GetComponent<Rigidbody2D>(); // 제네릭(?뭔지 알아오기)

        state = State.Ready;
        rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 상태머신 사용하기 ^-^(관리에 용이)
        if (state == State.Ready)
        {
            UpdateReady();
        }
        else if (state == State.Playing)
        {
            UpdatePlaying();
        }
        else if (state == State.GameOver)
        {
            UpdateGameOver();
        }
    }

    private void UpdateGameOver()
    {
        
    }

    private void UpdatePlaying()
    {
        //1. 마우스 왼쪽 버튼을 누르면
        if (Input.GetMouseButtonDown(0))
        {
            //2. 위로 점프하고 싶다. 그런데 물리엔진을 사용하고 싶다.
            //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpPower;
            rb.rotation = upAngle;
        }
        rb.rotation -= downAngle * Time.deltaTime;
        if (rb.rotation < limitAngle)
        {
            rb.rotation = limitAngle;
        }

        Debug.DrawLine(rb.transform.position, rb.transform.position + new Vector3(rb.velocity.x, rb.velocity.y, 0), Color.red);
    }

    // 버튼을 누르면 점프를 뛰면서 게임이 시작되게 하고싶다.
    private void UpdateReady()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //2. 위로 점프하고 싶다. 그런데 물리엔진을 사용하고 싶다.
            //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpPower;
            rb.rotation = upAngle;

            // 게임이 시작되게 하고싶다.
            state = State.Playing;
            rb.simulated = true;
            // 파이프 매니저도 일을 하게 하자.
            PipeManager.Instance.isDoing = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // 어딘가에 부딪혔다.
        // 게임오버 처리를 해야한다.
        Vector2 dir = new Vector2(-1, 1);
        dir.Normalize();
        rb.AddForce(dir * 5, ForceMode2D.Impulse);

        //print(other.gameObject.name);

        // 게임오버 처리를 하고싶다.
        state = State.GameOver;
        PipeManager.Instance.isDoing = false;

        // 게임오버 UI 출력
        ScoreManager.Instance.gameOverUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.Contains("Pipe"))
        {
            // 파이프를 넘어왔다. 점수를 1점 추가하고 싶다. (싱글톤/프로퍼티로 간단하게)
            ScoreManager.Instance.SCORE += 1;
            print("Trigger" + other.name);
            other.enabled = false;
        }
    }
}

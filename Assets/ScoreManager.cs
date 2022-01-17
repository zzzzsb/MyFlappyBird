using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    int score;
    public Text textScore;
    public GameObject gameOverUI;

    //프로퍼티
    public int SCORE
    {
        get { return score; }
        set {
            score = value;
            // 만약 score가 highScore보다 크다면
            if (score > highScore)
            {
                // highScore를 갱신하고 싶다.
                HIGHSCORE = score;
                // highScore저장(key-value방식)
                // 쓰기함수
                PlayerPrefs.SetInt("HIGHSCORE", HIGHSCORE);
            }
            textScore.text = score.ToString();
        }
    }

    int highScore;
    public Text texthighScore;

    //프로퍼티
    public int HIGHSCORE
    {
        get { return highScore; }
        set
        {
            highScore = value;
            texthighScore.text = highScore.ToString();
        }
    }
    /*
    public int GetScore(int value)
    {
        return score;
    }

    public void SetScore(int value)
    {
        score = value;
        textScore.text = score.ToString();
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        SCORE = 0;
        gameOverUI.SetActive(false);
        // 읽기함수
        HIGHSCORE = PlayerPrefs.GetInt("HIGHSCORE", 0); // 기본값 0
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickGameOver()
    {
        print("OnClickGameOver");
        // 재시작(현재 활성화된 씬의 이름을 가져옴 그씬을 다시 로드(자기자신 로드))
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

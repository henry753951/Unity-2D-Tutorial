using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
int score = 0;

[SerializeField]
TextMeshProUGUI scoreText;

[SerializeField]
TextMeshProUGUI GameOverScoreText;

    [SerializeField]
    GameObject GameOverUI;

    [SerializeField]
    GameObject GameStartUI;

    [SerializeField]
    PipeSpawner pipeSpawner;

    [SerializeField]
    GameObject bird;

[SerializeField]
AudioSource deathAudioSource;

[SerializeField]
AudioSource scoreAudioSource;

    public void ResetGame()
    {
        score = 0; // 分數歸零
        scoreText.text = score.ToString(); // 更新分數UI
        scoreText.enabled = false; // 隱藏分數UI
        GameOverUI.SetActive(false); // 隱藏結束畫面
        GameStartUI.SetActive(true); // 顯示開始畫面
        pipeSpawner.ResetPipe(); // 重置水管
        Time.timeScale = 0; // 暫停遊戲
        bird.transform.position = new Vector3(0, 0, 0); // 重置小鳥位置
    }

    public void StartGame()
    {
        GameStartUI.SetActive(false); // 隱藏開始畫面
        scoreText.enabled = true; // 顯示分數UI
        Time.timeScale = 1; // 開始遊戲
    }

    public void AddScore(int scoreToAdd)
    {
        scoreAudioSource.Play(); // 播放加分音效
        score += scoreToAdd; // 分數加上 scoreToAdd
        scoreText.text = score.ToString(); // 更新分數UI
    }

public void GameOver()
{
    deathAudioSource.Play(); // 播放死亡音效
    scoreText.enabled = false; // 隱藏分數UI
    GameOverUI.SetActive(true); // 顯示結束畫面
    GameOverScoreText.text = "Score : " + score.ToString(); // 更新結束畫面的分數
    Time.timeScale = 0; // 暫停遊戲
}

    public void CheckPassPipe(float birdX)
    {
        for (int i = 0; i < pipeSpawner.pipeList.Count; i++)
        {
            if (pipeSpawner.pipeList[i].transform.position.x < birdX)
            {
                // 如果還沒被計分，就加分
                if (!pipeSpawner.pipeList[i].GetComponent<Pipe>().isScored)
                {
                    AddScore(1);
                    pipeSpawner.pipeList[i].GetComponent<Pipe>().isScored = true;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update() { }
}

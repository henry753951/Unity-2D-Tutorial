using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // 管子組合的Prefab
    [SerializeField]
    GameObject pipePrefab;

    // 產生管子的間隔時間 和 計時器
    [SerializeField]
    float spawnInterval = 1.5f;
    float spawnTimer = 0f;

    // 管子的隨機gap range
    [SerializeField]
    Vector2 randomGap = new Vector2(4f, 5f);

    // 管子的隨機Y軸位置 range
    [SerializeField]
    Vector2 randomYRange = new Vector2(-2f, 2f);

    // 用來存放產生的管子
    public List<GameObject> pipeList = new List<GameObject>();

    // 管子掉落的位置
    [SerializeField]
    Transform pipeDropPos;

    // 管子產生的位置
    [SerializeField]
    Transform pipeSpawnPos;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        // 每隔 spawnInterval 秒產生一個管子
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f; // 計時器歸零
            // 產生一個管子
            GameObject pipe = Instantiate(pipePrefab, pipeSpawnPos.position, Quaternion.identity);
            // 設定管子的間隔
            pipe.GetComponent<Pipe>().setGapSize(Random.Range(randomGap[0], randomGap[1]));
            // 設定管子的位置
            pipe.GetComponent<Pipe>().randomYPos(randomYRange);
            // 將產生的管子加入到 pipeList 中
            pipeList.Add(pipe);
        }

        // 檢查 pipeList 中的管子是否超出螢幕左邊界，如果是，就刪除它
        for (int i = 0; i < pipeList.Count; i++)
        {
            if (pipeList[i].transform.position.x < pipeDropPos.position.x)
            {
                Destroy(pipeList[i]);
                pipeList.RemoveAt(i);
                i--;
            }
        }
    }

    public void ResetPipe()
    {
        // 刪除所有管子
        for (int i = 0; i < pipeList.Count; i++)
        {
            Destroy(pipeList[i]);
        }
        pipeList.Clear();
    }
}

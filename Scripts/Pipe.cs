using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    Vector2 PreviewRandomYRange = new Vector2(-2, 2);

    [SerializeField]
    float PreviewGapSize = 6f;

    // 拿來綁定上下水管 (因為這個腳本是在上下水管的媽媽，才可以一次控制上下兩個物件)
    [SerializeField]
    GameObject upPipe;

    [SerializeField]
    GameObject downPipe;

    public bool isScored = false;

    // 一個新的函式 (這邊設公開public是因為之後要從其他component調用這個方法)
    public void setGapSize(float gapSize)
    {
        // 如果上管子或下管子為空，就不執行下面的程式碼
        if (upPipe == null || downPipe == null)
        {
            return;
        }
        // 設定上下管子的間隔
        // 注意是 localPosition 這樣他位置會是相對於媽媽的位置，而不是在遊戲世界的絕對位置

        // x = 0 , y = gapSize / 2 , z = 0
        upPipe.transform.localPosition = new Vector3(0, gapSize / 2, 0);
        // x = 0 , y = -gapSize / 2 , z = 0
        downPipe.transform.localPosition = new Vector3(0, -gapSize / 2, 0);
    }

    public void randomYPos(Vector2 randomYRange)
    {
        // 隨機產生上下管子的位置
        float randomY = Random.Range(randomYRange.x, randomYRange.y);
        transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
    }

    // ON EDITOR MODE 參數改變時 在編輯模式下都可以執行
    void OnValidate()
    {
        setGapSize(PreviewGapSize);
        randomYPos(PreviewRandomYRange);
    }

    // Start is called before the first frame update
    // 當物件被建立後，底下每個 component 都會被執行一次 Start
    void Start() { }

    // Update is called once per frame
    void Update() { }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    // Fixed 是每固定時間都會執行一次 (如果只用Update()，會造成不同裝置不同FPS，而導致移動的速度不一致)
    void FixedUpdate()
    {
        // 管子向左移動
        transform.position += Vector3.left * 2f * Time.fixedDeltaTime;
    }
}

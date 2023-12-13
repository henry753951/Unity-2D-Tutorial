using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Example : MonoBehaviour
{
    [SerializeField]
    float variable1 = 5f;

    // 遊戲開始後，這個 component 被加載時，會執行一次
    void Start() { }

    // 在遊戲運行時，每一個 frame 都會執行一次
    void Update() { }

    // 在遊戲運行時，每一個固定時間間隔都會執行一次
    void FixedUpdate() { }

    // 在編輯模式下，調整參數時會執行一次
    void OnValidate() { }

    // 自訂函式 //

    // private 函式 (只能在這個 component 內部調用)
    void CustomPrivateFunction() { }

    // public 函式 (可以從其他 component 調用)
    public void CustomPublicFunction() { }
}

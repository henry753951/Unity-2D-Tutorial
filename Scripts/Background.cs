using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    MeshRenderer backgroundMaterial;

    [SerializeField]
    MeshRenderer groundMaterial;

    [SerializeField]
    float scrollSpeed = 0.5f;

    [SerializeField]
    float groundScrollSpeed = 0.5f;

    void Start() { }

    // Update is called once per frame
    void Update() { }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate()
    {
        // 背景向左移動
        backgroundMaterial.material.mainTextureOffset +=
            Vector2.right * scrollSpeed * Time.fixedDeltaTime;
        // 地板向左移動
        groundMaterial.material.mainTextureOffset +=
            Vector2.right * groundScrollSpeed * Time.fixedDeltaTime;
    }
}

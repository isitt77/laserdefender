using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material backgroundMaterial;

    void Awake()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        BackgroundOffset();
    }

    void BackgroundOffset()
    {
        offset = moveSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset += offset;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IrregularButton : MonoBehaviour
{
    private int count;
    void Awake()
    {
        // 设置阈值
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.1f;
        count = 0;
    }
    public void OnButtonClicked()
    {
        count++;
        Debug.Log("count  " + count);
    }
}

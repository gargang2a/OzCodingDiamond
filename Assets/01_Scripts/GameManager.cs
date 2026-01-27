using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stageCount;
    public TextMeshProUGUI stageCountText;
    public TextMeshProUGUI PlayerCountText;

    public void GetItem(int count)
    {
        PlayerCountText.text = count.ToString();
    }

    void Awake()
    {
        stageCountText.text += totalItemCount;
    }

    void Update()
    {
        
    }
}

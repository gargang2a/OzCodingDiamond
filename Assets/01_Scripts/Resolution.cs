using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60; // 프레임 고정
        int targetWidth = 1280; // 해상도 가로 크기 목표

        if (Screen.width > targetWidth) // 다운 스케일링
        {
            float ratio = (float)Screen.height / Screen.width;
            int targetHeight = (int)(targetWidth * ratio);
            Screen.SetResolution(targetWidth, targetHeight, true);
        }
    }
}
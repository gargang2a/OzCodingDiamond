using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60; // 프레임 고정

        // 가로모드 고정
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }
}
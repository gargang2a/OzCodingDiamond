using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] AudioClip finishSound;
    [SerializeField] AudioClip returnSound;
    [SerializeField] GameManager manager;
    [SerializeField] PlayerBall player;

    void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (manager.totalItemCount == player.itemCount)
            {
                AudioSource.PlayClipAtPoint(finishSound, transform.position);
                manager.stageCount++;
                Invoke(nameof(LoadNextStage), 0.7f);
            }
            else
            {
                AudioSource.PlayClipAtPoint(returnSound, transform.position);
                Invoke(nameof(ReloadScene), 0.7f);
            }
        }

        if (other.tag == "Zet")
        {
            if (manager.totalItemCount == player.itemCount)
            {
                AudioSource.PlayClipAtPoint(finishSound, transform.position);
                manager.stageCount++;
                Invoke(nameof(ReloadScene), 0.7f);
            }
            else
            {
                AudioSource.PlayClipAtPoint(returnSound, transform.position);
                Invoke(nameof(ReloadScene), 0.7f);
            }
        }
    }

    private void LoadNextStage()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int totalSceneCount = SceneManager.sceneCountInBuildSettings;
        
        if (nextSceneIndex >= totalSceneCount) // 루프 스테이지
        {
            nextSceneIndex = 0;
            manager.stageCount = 1;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Stage " + manager.stageCount );
    }
}

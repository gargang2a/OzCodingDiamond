using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFloor : MonoBehaviour
{
    [SerializeField] GameManager manager;
    [SerializeField] AudioClip returnSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(returnSound, transform.position);
            Invoke(nameof(LoadScene), 0.7f);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Stage " + manager.stageCount);
    }

}

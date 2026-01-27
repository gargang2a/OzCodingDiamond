using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{ 
    Transform playerTransform;
    Transform zetTransform;
    
    Vector3 baseOffset;
    [SerializeField]
    public Vector3 zetOffset;

    void Start()
    {
        

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        GameObject zetObject = GameObject.FindGameObjectWithTag("Zet");

        if (zetObject != null)
        {
            zetTransform = zetObject.transform;
        }

        if (playerTransform != null)
        {
            baseOffset = transform.position - playerTransform.position;
        }
        else if (playerTransform != null)
        {
            baseOffset = transform.position - zetTransform.position;
        }

    }

    void LateUpdate()
    {
        Transform currentTarget = null;
        Vector3 currentOffset = baseOffset;

        if (playerTransform != null && playerTransform.gameObject.activeSelf)
        {
            currentTarget = playerTransform;
        }
        else if (zetTransform != null)
        {
            currentTarget = zetTransform;
            currentOffset += zetOffset;
        }
 
        if (currentTarget != null)
        {
            transform.position = currentTarget.position + currentOffset ;
        }
    }
}

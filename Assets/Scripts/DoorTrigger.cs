using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    public UnityEvent actions;
    public Transform cameraToPosition;
    public Transform cameraFromPosition;
    private CameraObject mainCamera;
    void Start()
    {
        mainCamera = GameManager.instance.mainCamera.GetComponent<CameraObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            actions.Invoke();
        }
    }

    public void MoveCamera()
    {
        if(mainCamera.destinationPosition == cameraToPosition)
        {
            StartCoroutine(MoveCameraSmooth(cameraFromPosition));
        }
        else
        {
            StartCoroutine(MoveCameraSmooth(cameraToPosition));
        }

    }

    IEnumerator MoveCameraSmooth(Transform to)
    {
        mainCamera.destinationPosition = to;
        while(mainCamera.gameObject.transform.position != mainCamera.destinationPosition.position)
        {
            float step = .2f;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, mainCamera.destinationPosition.position, step);
            yield return new WaitForSeconds(.005f);
        }
    }
}

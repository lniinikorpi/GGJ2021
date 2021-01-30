using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    public UnityEvent actions;
    public Transform cameraToPosition;
    public Transform cameraFromPosition;
    public GameObject toLevel;
    public GameObject fromLevel;
    public Transform toTeleportLocation;
    public Transform fromTeleportLocation;
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

    public void ChangeLevel()
    {
        if(GameManager.instance.currentLevel == toLevel)
        {
            GameManager.instance.currentLevel = fromLevel;
            GameManager.instance.player.GetComponent<Player>().teleportLocation = fromTeleportLocation;
        }
        else
        {
            GameManager.instance.currentLevel = toLevel;
            GameManager.instance.player.GetComponent<Player>().teleportLocation = toTeleportLocation;
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

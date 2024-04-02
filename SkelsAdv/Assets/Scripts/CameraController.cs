using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform _player;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _player = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        cameraPlacement();
        cameraLookAt();
    }

    private void cameraPlacement()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y + 10, _player.position.z - 10);
    }

    private void cameraLookAt()
    {
        transform.LookAt(_player);
    }
}

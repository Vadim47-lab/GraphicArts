using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private GameObject _fireballPrefab;
    [SerializeField] private GameObject _spawnPoint;

    public float Speed = 8.0f;
    public float DistanceFromCamera = 5.0f;

    private void Update()
    {
        //Vector3 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 MousePosition = Input.mousePosition;
        MousePosition.z = DistanceFromCamera;

        Vector3 MouseScreenToWorld = Camera.main.ScreenToWorldPoint(MousePosition);

        Vector3 Position = Vector3.Lerp(transform.position, MouseScreenToWorld, 1.0f - Mathf.Exp(-Speed * Time.deltaTime));

        transform.position = Position;
        //transform.LookAt(MouseScreenToWorld);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_fireballPrefab, _spawnPoint.transform.position, transform.rotation);
        }
    }
}
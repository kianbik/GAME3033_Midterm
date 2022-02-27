using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;
    Vector2 inputVector = Vector2.zero;
    PlayerInput playerInput;
    // References
    public GameObject BodyPrefab;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        inputVector = playerInput.actions["Rotate"].ReadValue<Vector2>();
        float steerDirection = inputVector.x;
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

    }
}

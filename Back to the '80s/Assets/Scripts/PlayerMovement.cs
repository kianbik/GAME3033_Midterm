using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float DancerSpeed = 5;
    public int Gap = 10;
    public int initialGap = 70;
    Vector2 inputVector = Vector2.zero;
    PlayerInput playerInput;
    // References
    public GameObject followerPrefab;
    public PauseMenuScript pauseMenu;

    Rigidbody rigidbody;
    Animator playerAnimator;

    // Lists
    private List<GameObject> FollowAllongs = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.actions["Pause"].IsPressed())
        {
            pauseMenu.Pause();
        }
        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        inputVector = playerInput.actions["Rotate"].ReadValue<Vector2>();
        float steerDirection = inputVector.x;
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
        PositionsHistory.Insert(0, transform.position);
        int index = 0;
        foreach (var dancers in FollowAllongs)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap + initialGap, 0, PositionsHistory.Count - 1)];

            
            Vector3 moveDirection = point - dancers.transform.position;
            dancers.transform.position += moveDirection * DancerSpeed * Time.deltaTime;

          
            dancers.transform.LookAt(point);
           
            index++;
        }
        if (Mathf.Abs(rigidbody.velocity.y)>3)
        {
            playerAnimator.SetBool("IsFalling", true);
        }
    }

    public void GrowParty()
    {
       
        GameObject follower = Instantiate(followerPrefab);
        follower.gameObject.tag = "Follower";
        FollowAllongs.Add(follower);
   
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Dancer"))
        {
            GrowParty();
            Destroy(col.gameObject);
            
        }


    }
}

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Walk
    public float rotationSpeed = 10.0f; // movement rotation
    public float runMultiplier = 2.0f; // run
    private bool isRunning = false;

    private Animator animator;
    private Rigidbody rb;

    public Transform cam; // 카메라 Transform
    public Joystick joy;
    public AudioClip acp;
   
    float time;
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        time = 0;
    }
    // UI 버튼에 연결되는 메서드 (onClick에 연결)
    public void StartRunning()
    {
        isRunning = true;
    }

    // UI 버튼 해제용 (onPointerUp에 연결하면 좋음)
    public void StopRunning()
    {
        isRunning = false;
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // float h = joy.Horizontal;
        // float v = joy.Vertical;
        Vector3 inputDir = new Vector3(h, 0, v);

        bool isMoving = inputDir.sqrMagnitude > 0.01f;
        animator.SetBool("bMove", isMoving);
        
        // bool isRunning = Input.GetKey(KeyCode.LeftShift) && isMoving;
        animator.SetBool("bRun", isRunning);  // Animator에서 달리는 애니메이션도 설정 가능
        float currentSpeed = moveSpeed;
        if(isRunning)
        {
            currentSpeed *= runMultiplier;
        }
        else
        {
            currentSpeed = moveSpeed;
        }
        if (isMoving)
        {
             time += Time.deltaTime;
            if(isRunning){
                if(time>0.2f)
                {
                    GetComponent<AudioSource>().PlayOneShot(acp);
                    time = 0;
                }
                
            }
            else 
            {
                if(time>0.6f)
                {
                    GetComponent<AudioSource>().PlayOneShot(acp);
                    time = 0;
                }
            }
            // 카메라 기준으로 입력 방향 변환
            Vector3 camForward = cam.forward;
            Vector3 camRight = cam.right;
            camForward.y = 0;
            camRight.y = 0;
            camForward.Normalize();
            camRight.Normalize();

            Vector3 moveDir = camForward * v + camRight * h;

            // 부드러운 회전
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);

            // Rigidbody 이동
            rb.MovePosition(rb.position + moveDir.normalized * currentSpeed * Time.fixedDeltaTime);
        }
    }
}

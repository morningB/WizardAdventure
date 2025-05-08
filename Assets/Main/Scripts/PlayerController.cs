using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Walk
    public float rotationSpeed = 10.0f; // movement rotation
    public float runMultiplier = 2.0f; // run

    private Animator animator;
    private Rigidbody rb;

    public Transform cam; // 카메라 Transform

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(h, 0, v);

        bool isMoving = inputDir.sqrMagnitude > 0.01f;
        animator.SetBool("bMove", isMoving);
        
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && isMoving;
        animator.SetBool("bRun", isRunning);  // Animator에서 달리는 애니메이션도 설정 가능
        float currentSpeed = moveSpeed;
        if(isRunning)
        {
            currentSpeed *= runMultiplier;
        }
        if (isMoving)
        {
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

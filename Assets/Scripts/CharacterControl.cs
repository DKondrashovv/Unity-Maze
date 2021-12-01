using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed = 4.0f;//скорость перса
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;//гравитация 
    private Vector3 MoveDir = Vector3.zero;//Переменная движения игрока
    private CharacterController controller; //переменная содержащая компомнент CharacterController

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }


    void Update()
    {


        if (controller.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            MoveDir = transform.TransformDirection(MoveDir);
            MoveDir *= speed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            MoveDir.y = jumpSpeed;
        }
        MoveDir.y -= gravity * Time.deltaTime;
        controller.Move(MoveDir * Time.deltaTime);

    }




}

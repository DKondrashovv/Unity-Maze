using UnityEngine;
using System.Collections;
[AddComponentMenu("Camera-Control/MouseLook")]

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    };
    public RotationAxes axes = RotationAxes.MouseXAndY;
    //Чувствительность мыши
    public float sensitivityX = 2.0f;
    public float sensitivityY = 2.0f;
    [SerializeField] private float minimumX = -360.0f;
    public float maximumX = 360.0f;
    public float minimumY = -360.0f;
    public float maximumY = 360.0f;
    private float _rotationX = 0f;
    private float _rotationY = 0f;
    Quaternion originalRotation;
    void Start()
    {
      /*  if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }*/
        originalRotation = transform.localRotation;
    }
    public static float ClampAngle(float angle,float min,float max)
    {
        
        return Mathf.Clamp(angle, min, max);
    }
    void Update()
    {
        /*if (axes == RotationAxes.MouseXAndY)
        {
            _rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            _rotationY += Input.GetAxis("Mouse Y") * sensitivityY;

            _rotationX = ClampAngle(_rotationX, minimumX, maximumX);
            _rotationY = ClampAngle(_rotationY, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);
            transform.localRotation=originalRotation * xQuaternion * yQuaternion;

        }*/
        if (axes == RotationAxes.MouseX)
        {
            _rotationX += Input.GetAxis("Mouse X") * sensitivityX;
           // _rotationX = ClampAngle(_rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        else if(axes==RotationAxes.MouseY)
        {
            _rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            _rotationY = ClampAngle(_rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(-_rotationY ,Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
}

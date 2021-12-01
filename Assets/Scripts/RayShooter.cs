using System.Collections;
using UnityEngine;
public class RayShooter : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    GameObject hitObject = hit.transform.gameObject;
            //    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
            //    if (target != null)
            //    {
            //        target.ReactToHit();
            //    }
            //    else
            //    {
            //        StartCoroutine(SphereIndicator(hit.point));
            //    }
            //}
            if (Physics.SphereCast(ray, 0.5f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
               /* if (hitObject.GetComponent<PlayerCharacter>())
                {*/
                    if (_fireball == null)
                    {
                    Vector3 position = new Vector3(0, 0, 1.5f);
                    
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(position * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                        Destroy(_fireball, 1f);
                       
                }
               // }
            }
        }


    }
    void OnGUI()
    {
        int size = 15;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
    IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

}
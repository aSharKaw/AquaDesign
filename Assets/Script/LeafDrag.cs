using UnityEngine;

public class LeafDrag : MonoBehaviour
{

    private Ray _ray;
    [SerializeField]
    private LayerMask mask;


    Vector3 GetRay(Ray ray)
    {
        RaycastHit hit;
        //ray = new Ray(this.transform.position, Vector3.down);
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(this.transform.position, transform.forward, out hit, 10, mask))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private void Update()
    {
        Debug.DrawRay(_ray.origin, _ray.direction * 10, Color.red, 3);
    }

    void OnMouseDrag()
    {
        Vector3 objectPointInScreen
            = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        mousePointInWorld.z = this.transform.position.z;
        this.transform.position = mousePointInWorld;

        //_ray = new Ray(this.transform.position, Vector3.down);
        //Vector3 objectPointInScreen = Camera.main.WorldToScreenPoint(this.transform.position);

        //Vector3 mousePointInScreen
        //    = new Vector3(Input.mousePosition.x,
        //                  Input.mousePosition.y,
        //                  Input.mousePosition.z);

        //Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
        //mousePointInWorld.z = this.transform.position.z;
        //this.transform.position = mousePointInWorld;


        //this.transform.position = new Vector3(GetRay(_ray).x, GetRay(_ray).y, this.transform.position.z);
    }

    private void OnMouseUp()
    {
        _ray = new Ray(this.transform.position, Vector3.down);

        RaycastHit hit;
        //ray = new Ray(this.transform.position, Vector3.down);
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 10, mask))
        {
            this.transform.position = hit.point;
        }

        //this.transform.position = GetRay(_ray);
    }
}
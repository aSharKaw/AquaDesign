using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour {
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private LayerMask _mask;

    void Start()
    {
        if (this._camera == null)
        {
            _camera = Camera.main;
        }
    }

    Vector3 GetRay(/*Ray ray*/)
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1.0f, _mask))
        {
            return hit.point;
        }
        return new Vector3(0, 0, -100);
    }

    private void OnMouseDrag()
    {
        this.transform.position = GetRay(/*_ray*/);
    }



    private void OnMouseUp()
    {
        if (gameObject.transform.position == new Vector3(0, 0, -100))
        {
            Destroy(gameObject);
        }
    }

}

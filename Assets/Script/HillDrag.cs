using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillDrag : MonoBehaviour {
    [SerializeField]
    private Camera _camera;

    //Ray _ray;
    [SerializeField]
    private LayerMask mask;

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

        if (Physics.Raycast(ray, out hit, 1.0f, mask))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

    private void OnMouseDrag()
    {
        this.transform.position = GetRay(/*_ray*/);
    }

}

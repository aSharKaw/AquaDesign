using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private LayerMask _mask;

    private Vector3 GetRayHitPoint ( )
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay( Input.mousePosition );

        if (Physics.Raycast( ray, out hit, 1.0f, _mask ))
        {
            return hit.point;
        }
        return new Vector3( 0, 0, -100 );
    }

    private void OnMouseDrag ( )
    {
        this.transform.position = GetRayHitPoint(/*_ray*/);
    }

    private void OnMouseUp ( )
    {
        if (gameObject.transform.position == new Vector3( 0, 0, -100 ))
        {
            Destroy( gameObject );
        }
    }

    private void Start ( )
    {
        if (this._camera == null)
        {
            _camera = Camera.main;
        }
    }
}

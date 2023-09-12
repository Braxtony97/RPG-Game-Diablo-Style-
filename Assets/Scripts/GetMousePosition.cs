using Unity.VisualScripting;
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
    public Vector3 MousePositionVector;
    public Transform MousePositionTransform;

    [SerializeField] private LayerMask _LayerMaskGround;

    public void MousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, _LayerMaskGround))
        {
            //MousePositionTransform.position = new Vector3 (hit.point.x, hit.point.y, hit.point.z); 
            MousePositionVector = hit.point;
        }
        
    }
}

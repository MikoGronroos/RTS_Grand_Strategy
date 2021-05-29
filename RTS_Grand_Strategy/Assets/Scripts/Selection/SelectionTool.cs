using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionTool : MonoBehaviour
{

    [SerializeField] private LayerMask _valiableMask;

    private Camera _camera;

    private int fingerID = -1;

    private void Awake()
    {
        _camera = Camera.main;

#if !UNITY_EDITOR
     fingerID = 0; 
#endif
    }

    private void Update()
    {
        
        if (EventSystem.current.IsPointerOverGameObject(fingerID))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x, _camera.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, Mathf.Infinity);
            if (hit.transform != null)
            {
                if (hit.transform.TryGetComponent(out ISelectable selectable))
                {

                    selectable.Select();

                }
            }
        }
    }
}

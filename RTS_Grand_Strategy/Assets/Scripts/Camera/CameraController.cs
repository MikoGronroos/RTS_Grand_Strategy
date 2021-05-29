using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float minZoom = 35f;
    [SerializeField] private float maxZoom = 90f;
    [SerializeField] private float sensitivity = 10f;
    [SerializeField] private float zoomLerpSpeed = 10;

    private float _targetZoom;
    private Camera _camera;

    private Vector3 _dragOrigin;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {

        PanCamera();
        CameraZoom();

    }

    private void CameraZoom()
    {
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");

        _targetZoom -= scrollData * sensitivity;
        _targetZoom = Mathf.Clamp(_targetZoom, minZoom, maxZoom);

        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _targetZoom, Time.deltaTime * zoomLerpSpeed);
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _dragOrigin = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 difference = _dragOrigin - _camera.ScreenToWorldPoint(Input.mousePosition);

            _camera.transform.position += difference;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTubeController : MonoBehaviour
{
    [SerializeField] bool _update;
    [SerializeField] Transform _CreationPoint;
    [SerializeField] GameObject _WaterTubePrefab;

    private void Update()
    {
        if (!_update)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                InstantiateWaterTube(hit.point);
            }
        }
    }

    public void InstantiateWaterTube(Vector3 hitPoint)
    {
        Vector3 direction = (hitPoint - _CreationPoint.position);
        direction.y = 0;
        direction = direction.normalized;
        GameObject waterTube = Instantiate(_WaterTubePrefab, _CreationPoint.transform.position, Quaternion.identity);
        waterTube.transform.forward = direction;
    }
}

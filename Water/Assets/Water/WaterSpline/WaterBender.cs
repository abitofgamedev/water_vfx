using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBender : MonoBehaviour
{
    [SerializeField] bool _update;
    [SerializeField] WaterBendingControll _WaterPrefab;

    // Update is called once per frame
    void Update()
    {
        if (!_update)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Attack(hit.point);
            }
        }
    }

    public void Attack(Vector3 target)
    {
        WaterBendingControll water = Instantiate(_WaterPrefab, transform.position, Quaternion.identity);
        water.WaterBend(target);
    }
}

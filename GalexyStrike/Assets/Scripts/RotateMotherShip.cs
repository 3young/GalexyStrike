using UnityEngine;

public class RotateMotherShip : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(3, 3, 3) * Time.deltaTime);
    }
}

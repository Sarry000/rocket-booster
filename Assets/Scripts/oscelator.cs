using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class oscelator : MonoBehaviour
{
  Vector3 startposition;
  Vector3 endposition;
  [SerializeField]float speed;
  float movementfactor;
  [SerializeField] Vector3 movementvector;

    void Start()
    {
        startposition=transform.position;
        endposition=startposition + movementvector;
    }
    void Update()
    {
        movementfactor=Mathf.PingPong(Time.time *speed,1f);
        transform.position=Vector3.Lerp(startposition,endposition,movementfactor);
    }

}

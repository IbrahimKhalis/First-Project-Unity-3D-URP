using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CarManager : MonoBehaviour
{
    public ReticleBehaviour Recticle;
    public GameObject CarPrefab;
    public DrivingSurfaceManager DrivingSurfaceManager;
    public CarBehaviour Car;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Car == null && WasTapped() && Recticle.CurrentPlane != null)
        {
            var obj = GameObject.Instantiate(CarPrefab);
            Car = obj.GetComponent<CarBehaviour>();
            Car.Recticle = Recticle;
            Car.transform.position = Recticle.transform.position;
            DrivingSurfaceManager.LockPlane(Recticle.CurrentPlane);
        }
    }
    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }
        return true;
                
            
    }
}

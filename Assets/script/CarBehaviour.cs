using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    public ReticleBehaviour Recticle;
    public float Speed = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var trackingPosition = Recticle.transform.position;
        if (Vector3.Distance(trackingPosition, transform.position) < 0.1)
        {
            return;
        }
        var lookRotation = Quaternion.LookRotation(trackingPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.position = Vector3.MoveTowards(transform.position, trackingPosition, Speed * Time.deltaTime);
    }

    //private void onTriggerEnter(Collider other)
    //{
    //    var Package = other.GetComponent<PackageBehaviour>();
    //    if (Package != null)
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public Quaternion currentStartRotation;
    
    public BallPreFab ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentStartRotation = Camera.main.transform.rotation;
        }
        
        else if (Input.GetMouseButtonUp(0))
        {
            // Note this is still not the true effect - could add timing for another layer of simulation. This 
            // will suffice for now 
            float stength = Mathf.Abs(currentStartRotation[0] - Camera.main.transform.rotation[0]); 
            stength += Mathf.Abs(currentStartRotation[1] - Camera.main.transform.rotation[1]); 
            stength += Mathf.Abs(currentStartRotation[2] - Camera.main.transform.rotation[2]);
            // stength = .8F;
			BallPreFab ball = Instantiate<BallPreFab>(ballPrefab);
            ball.transform.localPosition = transform.position;
            float entry1 = Camera.main.transform.forward[0] * stength * 1000 + 0;
            float entry2 = Camera.main.transform.forward[1] * stength * 1000 + 0;
            float entry3 = Camera.main.transform.forward[2] * stength * 1000 + 0;
            ball.GetComponent<Rigidbody>().AddForce(new Vector3(entry1, entry2, entry3));
        }
        
    }
}

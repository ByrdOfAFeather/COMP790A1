using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnImpact : MonoBehaviour
{

    public TargetPreFab targetPreFab;
	public TextMesh scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (targetPreFab.countScore) {
int max_distance = 10;
        Vector3 lower = Camera.main.transform.position - new Vector3(max_distance, max_distance, max_distance);
        Vector3 upper = Camera.main.transform.position + new Vector3(max_distance, max_distance, max_distance);
//        Vector3 randomPosition = new Vector3(Random.Range(lower[0], upper[0]), Random.Range(lower[1], upper[1]), Random.Range(lower[2], upper[2]));
        Vector3 randomPosition = new Vector3(Random.Range(lower[0], upper[0]), 10, Random.Range(lower[2], upper[2]));
        targetPreFab.transform.position = randomPosition;
        targetPreFab.transform.LookAt(Camera.main.transform.position);
        targetPreFab.transform.eulerAngles += new Vector3((-targetPreFab.transform.eulerAngles[0]) + -90, 180, 0);
		int currentScore = int.Parse(scoreKeeper.text.Split(':')[1]);
		currentScore += 1;
		scoreKeeper.text = "Score: " + currentScore.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60;
	public TargetPreFab target;
	bool isCounting = true;

    public TextMesh txt;
	public TextMesh scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCounting) {
       		if (timeRemaining > 0)
        	{
            	timeRemaining -= Time.deltaTime;
            	txt.text = "Time Left: " + timeRemaining.ToString().Substring(0,4);
        	}
		else {
				isCounting = false;
				target.countScore = false;
				var finalText = scoreText.text; 
				scoreText.text = "Final Score:" + finalText.Split(':')[1];
			}
		}
    }
}

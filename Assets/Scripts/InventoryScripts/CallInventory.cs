using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class CallInventory : MonoBehaviour
{
	[SerializeField] Animator scaleCanvas;
	[SerializeField] Animator jumpingCoin;

	private Canvas canvas;
	[SerializeField] Canvas bar;
	bool state;

	void Start()
	{
		canvas = GetComponent<Canvas>(); 
		canvas.enabled = false;
		bar.enabled = true;

		InventoryControl.CoinAnim += JumpAction;

		scaleCanvas.SetBool("EnableInventory", canvas.enabled);
		jumpingCoin.SetBool("Jump", false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			canvas.enabled = !canvas.enabled;

			scaleCanvas.SetBool("EnableInventory", canvas.enabled);

			bar.enabled = !bar.enabled;
		}

	}

	private void JumpAction(bool stateTransition)
    {

		StartCoroutine(JumpRoutine(stateTransition));
		
	}
	
	IEnumerator JumpRoutine(bool stateTransition)
    {
		jumpingCoin.SetBool("Jump", stateTransition);

		yield return new WaitForSeconds(1.2f);

		jumpingCoin.SetBool("Jump", !stateTransition);
	}
}

﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CreditMenuManager : MonoBehaviour 
{
	public Canvas creditsMenuCanvas;
	
	public void EnableOverlay(bool enabled)
	{
		creditsMenuCanvas.enabled = enabled;
	}
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class takePhoto : MonoBehaviour {

	WebCamTexture webCamTexture;

	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		foreach (WebCamDevice cam in devices) {
			if (!cam.isFrontFacing) continue;
			webCamTexture = new WebCamTexture {deviceName = cam.name};
			webCamTexture.Play ();
		}
		
		Debug.Log("Hello");
		Debug.Log(GameObject.Find("NavigationManager"));
	}

	public void snapshot()
	{
		Texture2D photo = new Texture2D (webCamTexture.width, webCamTexture.height);
		photo.SetPixels (webCamTexture.GetPixels ());
		photo.Apply ();

		byte[] bytes = photo.EncodeToPNG ();
		File.WriteAllBytes (Application.persistentDataPath + "photo.png", bytes);
		Debug.Log (Application.persistentDataPath);
	}
}

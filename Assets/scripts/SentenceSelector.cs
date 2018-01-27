using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SentenceSelector : MonoBehaviour {
	private static String textDirectory = "D:\\Unity\\Projectz\\Chinese Dinosaur Whispers Comic\\Assets\\dinosaurText\\";
	private static int maxWordCount = 100;
	private XmlDocument dinosaurComicsXML;

	void Start () {
		dinosaurComicsXML = new XmlDocument ();
		dinosaurComicsXML.Load (textDirectory + "everywordindinosaurcomicsOHGOD.xml");

		String firstLine = GetRandomLine ();
		SetString (firstLine);

		ParseAndCreateFiles ();
	}

	private String GetFirstLine () {
		XmlNodeList lines = dinosaurComicsXML.GetElementsByTagName ("line");
		return lines[0].InnerText;
	}

	private String GetRandomLine () {
		XmlNodeList lines = dinosaurComicsXML.GetElementsByTagName ("line");
		int index = GetRandomIndex (lines.Count);
		return lines [index].InnerText;
	}

	private int GetRandomIndex (int max) {
		System.Random random = new System.Random ();
		double index = (random.NextDouble () * (double) max);
		return (int) Math.Floor (index);
	}

	private void SetString (String target) {
		Text textt = GetComponent<Text> ();
		textt.text = target;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SetString (GetRandomLine ());
		}
	}
}

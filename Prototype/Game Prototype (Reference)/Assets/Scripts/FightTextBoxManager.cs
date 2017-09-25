using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FightTextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine = 0;
	public int endAtLine;

	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
	}

	// Update is called once per frame
	void Update () {
		theText.text = textLines [currentLine];

			
	}
}
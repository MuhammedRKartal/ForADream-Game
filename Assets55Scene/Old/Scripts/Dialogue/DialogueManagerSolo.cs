using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerSolo : MonoBehaviour {

	public Dialogue dialogue;
	public Text nameText;
	public Text dialogueText;

	public int counter = 0;
	public int counterLimit;

	private float timer = 0;
    private float timerMax = 0;
    //private bool waiting = false;

	public Animator animator;

	private Queue<string> sentences;
	public string sname;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		FindObjectOfType<DialogueManagerSolo>().StartDialogue(dialogue);
	}

	public void StartDialogue (Dialogue dialogue)
	{
		
		//nameText.text = dialogue.name;
		sentences.Clear();
		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			SceneManager.LoadScene(sceneName: sname);
			return;
		}
		animator.SetBool("isOpen", true);
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		counter+=1;
	}


	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.06f);
		}
	}

	void EndDialogue()
	{
		animator.SetBool("isOpen", false);
	}

	private bool Waited(float seconds)
    {
        timerMax = seconds;
        timer += Time.deltaTime;
        if (timer >= timerMax) {return true;}
        return false;
    }


}
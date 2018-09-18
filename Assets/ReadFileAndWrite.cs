using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

public class ReadFileAndWrite : MonoBehaviour {

	public TextAsset InfoAssets;//文本资源类 .txt
	List<string> strTmp;
	
	// Use this for initialization
	
	void Start () 
	{
		string tt = InfoAssets.text;
		string[] allWords = tt.Split ('I');
		strTmp = new List<string> ();


		//Debug.Log (allWords.Length+allWords[1400]);

		for (int i = 1; i < allWords.Length; i++) 
		{
			DealString(allWords[i]);
		}
		CreateFile(Application.dataPath,"FileName.txt",strTmp);

	



		
	}
	void DealString(string str)	
	{
		string tmpStr = str.Replace (","," ");
		string tmpStr1 = str.Replace ("."," ");
		string tmpStr2 = tmpStr1.Replace ("\n", " ");
		Debug.Log (tmpStr2);
		string a = "T";
		//string a = "I";
		string b = "W";
		int indexA = tmpStr2.IndexOf (a);
		int indexB = tmpStr2.IndexOf (b);
		string dd = tmpStr2.Substring (0,indexA);
		//Debug.Log ((tmpStr2.Length-indexB-indexA+1)+"___");
		string ee = "";
		//Debug.Log (indexB+"_______");
		if ((tmpStr2.Length-indexB+1)>0) 
		{
			ee = tmpStr2.Substring (indexB+1,tmpStr2.Length-indexB-1);
			//Debug.Log(ee);
		}




 
		//Debug.Log (str1);
		strTmp.Add (ee);


	}
	void CreateFile(string path,string name,List<string> info)
	{
		StreamWriter sw;
		FileInfo t = new FileInfo (path+"//"+name);
		if (t.Exists) {
			sw = t.CreateText ();
		} else 
		{
			sw = t.AppendText();

		}
		for (int i = 0; i < info.Count; i++) 
		{
			sw.WriteLine (info[i]);
		}
		sw.Close ();
	}
}

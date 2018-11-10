using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using UnityEngine;
[Serializable]

public class GameData : ScriptableObject {
	public const string resourceName = "GameData";
	public const string resourcePath = "Assets/Resources/";
#if UNITY_EDITOR
	[MenuItem ("Assets/Create/GameData")]
	public static void CreateAsset () {
		AssetDatabase.CreateAsset (CreateInstance<GameData> (), resourcePath + resourceName + ".asset");
	}
#endif


	static GameData _instance;
	public static GameData Instance {
		get {
			if (_instance == null) {
				_instance = Resources.Load<GameData> (resourceName);
				if (_instance == null)
					throw new System.NullReferenceException ("Level ExpSetting Not Exist. Please Create Asset using : Assets > Create > Level Exp Setting : to Create instance");
			}
			return _instance;
		}
	}
	


	public float moveXOffect = 15f;
	public float generateStartZ = 300;
	public float playerSpeed = 10;

	
}
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EditorTools {

    // Materials

	public static void createMatsField(SerializedProperty matsArr, SerializedProperty incArr) {
		Object tMat;
		float tInt;

		if (incArr.arraySize != matsArr.arraySize) {
			incArr.arraySize = matsArr.arraySize;
		}

		if (GUILayout.Button("Add new")) {
			matsArr.InsertArrayElementAtIndex(matsArr.arraySize);
			incArr.InsertArrayElementAtIndex(incArr.arraySize);
		}

		for (int i = 0; i < matsArr.arraySize; i++) {
			EditorGUILayout.BeginHorizontal();
			tMat = matsArr.GetArrayElementAtIndex(i).objectReferenceValue;
			tInt = incArr.GetArrayElementAtIndex(i).floatValue;
			matsArr.GetArrayElementAtIndex(i).objectReferenceValue = EditorGUILayout.ObjectField(tMat, typeof(Material));
			incArr.GetArrayElementAtIndex(i).floatValue = EditorGUILayout.FloatField(tInt);
			if (GUILayout.Button("Delete")) {
				matsArr.DeleteArrayElementAtIndex(i);
				incArr.DeleteArrayElementAtIndex(i);
			}
			EditorGUILayout.EndHorizontal();
		}
	}

	public static void createMatsField2(SerializedProperty matsArr, SerializedProperty incArr, SerializedProperty objArr) {
		Object tMat;
		float tInt;
		Object tObj;

		if (incArr.arraySize != matsArr.arraySize) {
			incArr.arraySize = matsArr.arraySize;
		}

		if (objArr.arraySize != matsArr.arraySize) {
			objArr.arraySize = matsArr.arraySize;
		}

		if (GUILayout.Button("Add new")) {
			matsArr.InsertArrayElementAtIndex(matsArr.arraySize);
			incArr.InsertArrayElementAtIndex(incArr.arraySize);
			objArr.InsertArrayElementAtIndex(objArr.arraySize);
		}

		for (int i = 0; i < matsArr.arraySize; i++) {
			EditorGUILayout.BeginHorizontal();
			tMat = matsArr.GetArrayElementAtIndex(i).objectReferenceValue;
			tInt = incArr.GetArrayElementAtIndex(i).floatValue;
			tObj = objArr.GetArrayElementAtIndex(i).objectReferenceValue;
			matsArr.GetArrayElementAtIndex(i).objectReferenceValue = EditorGUILayout.ObjectField(tMat, typeof(Material));
			incArr.GetArrayElementAtIndex(i).floatValue = EditorGUILayout.FloatField(tInt);
			objArr.GetArrayElementAtIndex(i).objectReferenceValue = EditorGUILayout.ObjectField(tObj, typeof(GameObject));
			if (GUILayout.Button("Delete")) {
				matsArr.DeleteArrayElementAtIndex(i);
				incArr.DeleteArrayElementAtIndex(i);
				objArr.DeleteArrayElementAtIndex(i);
			}
			EditorGUILayout.EndHorizontal();
		}
	}

    // Tags

	public static void createTagsField(SerializedProperty tagsArr, SerializedProperty incArr) {
		string tTag;
		float tInt;

		if (incArr.arraySize != tagsArr.arraySize) {
			incArr.arraySize = tagsArr.arraySize;
		}

		if (GUILayout.Button("Add new")) {
            tagsArr.InsertArrayElementAtIndex(tagsArr.arraySize);
			incArr.InsertArrayElementAtIndex(incArr.arraySize);
		}

		for (int i = 0; i < tagsArr.arraySize; i++) {
			EditorGUILayout.BeginHorizontal();
            tTag = tagsArr.GetArrayElementAtIndex(i).stringValue;
			tInt = incArr.GetArrayElementAtIndex(i).floatValue;
            tagsArr.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField(tTag);
			incArr.GetArrayElementAtIndex(i).floatValue = EditorGUILayout.FloatField(tInt);
			if (GUILayout.Button("Delete")) {
                tagsArr.DeleteArrayElementAtIndex(i);
				incArr.DeleteArrayElementAtIndex(i);
			}
			EditorGUILayout.EndHorizontal();
		}
	}

	public static void createTagsField2(SerializedProperty tagsArr, SerializedProperty incArr, SerializedProperty objArr) {
        string tTag;
        float tInt;
		Object tObj;

		if (incArr.arraySize != tagsArr.arraySize) {
			incArr.arraySize = tagsArr.arraySize;
		}

		if (objArr.arraySize != tagsArr.arraySize) {
			objArr.arraySize = tagsArr.arraySize;
		}

		if (GUILayout.Button("Add new")) {
            tagsArr.InsertArrayElementAtIndex(tagsArr.arraySize);
			incArr.InsertArrayElementAtIndex(incArr.arraySize);
			objArr.InsertArrayElementAtIndex(objArr.arraySize);
		}

		for (int i = 0; i < tagsArr.arraySize; i++) {
			EditorGUILayout.BeginHorizontal();
            tTag = tagsArr.GetArrayElementAtIndex(i).stringValue;
            tInt = incArr.GetArrayElementAtIndex(i).floatValue;
			tObj = objArr.GetArrayElementAtIndex(i).objectReferenceValue;
            tagsArr.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField(tTag);
            incArr.GetArrayElementAtIndex(i).floatValue = EditorGUILayout.FloatField(tInt);
			objArr.GetArrayElementAtIndex(i).objectReferenceValue = EditorGUILayout.ObjectField(tObj, typeof(GameObject));
			if (GUILayout.Button("Delete")) {
                tagsArr.DeleteArrayElementAtIndex(i);
				incArr.DeleteArrayElementAtIndex(i);
				objArr.DeleteArrayElementAtIndex(i);
			}
			EditorGUILayout.EndHorizontal();
		}
	}
}
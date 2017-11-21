using UnityEngine;
using System.Collections;
using UnityEditor;
using eageramoeba.Lasers;

namespace eageramoeba.Lasers {

	[CustomEditor(typeof(laser))]
	public class laserEditor : Editor {
		SerializedObject m_object;
		SerializedProperty global;
		SerializedProperty length;
		SerializedProperty intersect;
		SerializedProperty reflect;
		SerializedProperty hit;
		SerializedProperty hitReflect;
		SerializedProperty reflectionLen;
		SerializedProperty hitMask;
		SerializedProperty hitMat;
		SerializedProperty hitMats;
		SerializedProperty hitMatsInc;
		SerializedProperty hitMatObjs;
		SerializedProperty passMat;
		SerializedProperty passMats;
		SerializedProperty passMatsInc;
		SerializedProperty lineRenP;
		SerializedProperty powerSt;
		SerializedProperty reflPInc;
		SerializedProperty chargePInc;
		SerializedProperty powerCap;
		SerializedProperty reflInc;
		SerializedProperty chargeInc;
		SerializedProperty lrWidth;
		SerializedProperty blockType;
		SerializedProperty blockThreshold;
		SerializedProperty chargeType;

		SerializedProperty intPos;
		SerializedProperty intSctGo;
		SerializedProperty hitGO;
		SerializedProperty hitDist;
		SerializedProperty intSctA;
		SerializedProperty parent1;
		SerializedProperty parent2;
		SerializedProperty origin1;
		SerializedProperty origin2;
		SerializedProperty curPower;

		SerializedProperty onM;

		SerializedProperty localLength;
		SerializedProperty localIntersect;
		SerializedProperty localIntersectReflect;
		SerializedProperty localIntersectRemain;
		SerializedProperty localHit;
		SerializedProperty localHitMask;
		SerializedProperty localHitReflect;
		SerializedProperty localHitReflectMat;
		SerializedProperty localPassthroughMat;
		SerializedProperty localLineRenderer;
		SerializedProperty localLineRendererWidth;
		SerializedProperty localStartPower;
		SerializedProperty localPowerCap;
		SerializedProperty localReflectionPowerInc;
		SerializedProperty localChargePowerInc;

		SerializedProperty localLaserObj;
		SerializedProperty localIntSctObj;
		SerializedProperty localHitObj;
		SerializedProperty localStartCapObj;
		SerializedProperty localEndCapObj;

		SerializedProperty laserObj;
		SerializedProperty intSctObj;
		SerializedProperty hitObj;
		SerializedProperty startCapObj;
		SerializedProperty endCapObj;

		SerializedProperty isChild;
		SerializedProperty groupId;

		Material[] matTemp;

		float localWidth = 10f;

        SerializedProperty reflTag;
        SerializedProperty reflTagInc;
        SerializedProperty pasTag;
        SerializedProperty pasTagInc;
        SerializedProperty hitScanMode;
        SerializedProperty allowedTagObj;
        private string[] hitRPOptions = new string[] { "Tag", "Material" };

        SerializedProperty localreflMatObj;
        SerializedProperty localreflTag;
        SerializedProperty localreflTagInc;
        SerializedProperty localpasTag;
        SerializedProperty localpasTagInc;
        SerializedProperty localallowedTagObj;
        SerializedProperty localhitScanMode;

        SerializedProperty directChild;


        // Use this for initialization
        void OnEnable() {
			m_object = new SerializedObject(target);
			global = m_object.FindProperty("useGlobal");
			length = m_object.FindProperty("length");
			intersect = m_object.FindProperty("intersectE");
			reflect = m_object.FindProperty("reflectE");
			hit = m_object.FindProperty("hitE");
			hitReflect = m_object.FindProperty("hitReflectE");
			hitMatObjs = m_object.FindProperty("reflMatObj");
			reflectionLen = m_object.FindProperty("reflLenRemE");
			hitMat = m_object.FindProperty("hitRefMatE");
			passMat = m_object.FindProperty("passRefMatE");
			hitMats = m_object.FindProperty("reflMatsE");
			hitMatsInc = m_object.FindProperty("reflMatInc");
			hitMatsInc = m_object.FindProperty("reflMatInc");
			passMats = m_object.FindProperty("passedMatsE");
			passMatsInc = m_object.FindProperty("pasMatInc");
			hitMask = m_object.FindProperty("hitLayerM");
			lineRenP = m_object.FindProperty("lasLineREff");
			powerSt = m_object.FindProperty("powerStart");
			reflInc = m_object.FindProperty("reflInc");
			chargeInc = m_object.FindProperty("chargeInc");
			powerCap = m_object.FindProperty("powerCap");
			lrWidth = m_object.FindProperty("lrWidth");
			blockType = m_object.FindProperty("blockType");
			blockThreshold = m_object.FindProperty("blockThreshold");
			chargeType = m_object.FindProperty("chargeType");

			intPos = m_object.FindProperty("intPos");
			intSctGo = m_object.FindProperty("intSctGo");
			hitGO = m_object.FindProperty("hitGO");
			hitDist = m_object.FindProperty("hitDist");
			intSctA = m_object.FindProperty("intSctA");
			parent1 = m_object.FindProperty("parent1");
			parent2 = m_object.FindProperty("parent2");
			origin1 = m_object.FindProperty("origin1");
			origin2 = m_object.FindProperty("origin2");
			curPower = m_object.FindProperty("curPower");

			localLength = m_object.FindProperty("localLength");
			localIntersect = m_object.FindProperty("localIntersect");
			localIntersectReflect = m_object.FindProperty("localIntersectReflect");
			localIntersectRemain = m_object.FindProperty("localIntersectRemain");
			localHit = m_object.FindProperty("localHit");
			localHitMask = m_object.FindProperty("localHitMask");
			localHitReflect = m_object.FindProperty("localHitReflect");
			localHitReflectMat = m_object.FindProperty("localHitReflectMat");
			localPassthroughMat = m_object.FindProperty("localPassthroughMat");
			localLineRenderer = m_object.FindProperty("localLineRenderer");
			localLineRendererWidth = m_object.FindProperty("localLineRendererWidth");
			localStartPower = m_object.FindProperty("localStartPower");
			localPowerCap = m_object.FindProperty("localPowerCap");
			localReflectionPowerInc = m_object.FindProperty("localReflectionPowerInc");
			localChargePowerInc = m_object.FindProperty("localChargePowerInc");

			localLaserObj = m_object.FindProperty("localLaserObj");
			localIntSctObj = m_object.FindProperty("localIntSctObj");
			localHitObj = m_object.FindProperty("localHitObj");
			localStartCapObj = m_object.FindProperty("localStartCapObj");
			localEndCapObj = m_object.FindProperty("localEndCapObj");

			laserObj = m_object.FindProperty("laserObj");
			intSctObj = m_object.FindProperty("intSctObj");
			hitObj = m_object.FindProperty("hitObj");
			startCapObj = m_object.FindProperty("startCapObj");
			endCapObj = m_object.FindProperty("endCapObj");

			onM = m_object.FindProperty("onM");
			isChild = m_object.FindProperty("isChild");
            groupId = m_object.FindProperty("groupId");

            reflTag = m_object.FindProperty("reflTag");
            reflTagInc = m_object.FindProperty("reflTagInc");
            pasTag = m_object.FindProperty("pasTag");
            pasTagInc = m_object.FindProperty("pasTagInc");
            hitScanMode = m_object.FindProperty("hitScanMode");
            allowedTagObj = m_object.FindProperty("allowedTagObj");

            localreflMatObj = m_object.FindProperty("localreflMatObj");
            localreflTag = m_object.FindProperty("localreflTag");
            localreflTagInc = m_object.FindProperty("localreflTagInc");
            localpasTag = m_object.FindProperty("localpasTag");
            localpasTagInc = m_object.FindProperty("localpasTagInc");
            localallowedTagObj = m_object.FindProperty("localallowedTagObj");
            localhitScanMode = m_object.FindProperty("localhitScanMode");

            directChild = m_object.FindProperty("directChild");
        }

		// Update is called once per frame
		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			m_object.Update();

			laser script = (laser)target;

			onM.boolValue = EditorGUILayout.Toggle(new GUIContent("On?", "Turn this laser on or off (enabled = on)"), onM.boolValue);

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			global.boolValue = EditorGUILayout.Toggle(new GUIContent("Use Global", "Use global values?"), global.boolValue);

			EditorGUILayout.Space();

			blockType.boolValue = EditorGUILayout.Toggle(new GUIContent("Enable Block", "Allow this laser to act as a block to other lasers, can only intersect with other block lasers (local)"), blockType.boolValue);

			//blockThreshold.floatValue = EditorGUILayout.FloatField(new GUIContent("Line renderer base width?", "This determines the base width of the line renderer, the final result will be the width times by power(local)"), blockThreshold.floatValue);
			chargeType.boolValue = EditorGUILayout.Toggle(new GUIContent("Enable Charge", "Allow htis laser to charge lasers it intersects with (local)"), chargeType.boolValue);

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			EditorGUI.BeginDisabledGroup(global.boolValue == true);

			EditorGUILayout.LabelField(new GUIContent("Local Options", "Options to use when not using global values"), EditorStyles.boldLabel);

			EditorGUILayout.Space();

			EditorGUILayout.BeginVertical();

			EditorGUILayout.BeginHorizontal();

				EditorGUILayout.BeginVertical(GUILayout.Width(localWidth));

					localLaserObj.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localLaserObj.boolValue, GUILayout.MaxWidth(localWidth));

					EditorGUILayout.Space();

					localLength.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localLength.boolValue, GUILayout.MaxWidth(localWidth));

					EditorGUILayout.Space();

					localIntersect.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localIntersect.boolValue, GUILayout.MaxWidth(localWidth));
					localIntersectReflect.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localIntersectReflect.boolValue, GUILayout.MaxWidth(localWidth));
					localIntersectRemain.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localIntersectRemain.boolValue, GUILayout.MaxWidth(localWidth));

					EditorGUILayout.Space();

					localHit.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localHit.boolValue, GUILayout.MaxWidth(localWidth));
					localHitMask.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localHitMask.boolValue, GUILayout.MaxWidth(localWidth));

                    EditorGUILayout.Space();
                    localhitScanMode.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localhitScanMode.boolValue, GUILayout.MaxWidth(localWidth));
                    EditorGUILayout.Space();

                    localHitReflect.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localHitReflect.boolValue, GUILayout.MaxWidth(localWidth));

					localHitReflectMat.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localHitReflectMat.boolValue, GUILayout.MaxWidth(localWidth));

				EditorGUILayout.EndVertical();

				EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));

					laserObj.objectReferenceValue = EditorGUILayout.ObjectField("Laser GameObject", laserObj.objectReferenceValue, typeof(GameObject));

					EditorGUILayout.Space();

					length.floatValue = EditorGUILayout.FloatField(new GUIContent("Length", "The local length of the laser "), length.floatValue);

					EditorGUILayout.Space();

					intersect.boolValue = EditorGUILayout.Toggle(new GUIContent("Intersect", "Collide intersecting lasers"), intersect.boolValue);

					reflect.boolValue = EditorGUILayout.Toggle(new GUIContent("Intersect Reflect", "Whether intersecting lasers should reflect"), reflect.boolValue);

					reflectionLen.boolValue = EditorGUILayout.Toggle(new GUIContent("Reflect Remaining Length", "Upon intersect or reflect, use remaining length of original to determine reflection length. Also effects hits (local)"), reflectionLen.boolValue);

					EditorGUILayout.Space();

					hit.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit", "Should this laser (local) hit colliders?"), hit.boolValue);

					EditorGUI.BeginDisabledGroup(hit.boolValue == false);

					EditorGUILayout.PropertyField(hitMask);

                    EditorGUILayout.Space();
                    hitScanMode.intValue = EditorGUILayout.Popup("Hit Scan Mode", hitScanMode.intValue, hitRPOptions);
                    EditorGUILayout.Space();

                    hitReflect.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Reflect", "Should hitting colliders (local) cause a reflection?"), hitReflect.boolValue);

					EditorGUI.BeginDisabledGroup(hitReflect.boolValue == false);
                    if (hitScanMode.intValue == 1) {
                        hitMat.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Reflection Materials", "Enable reflection materials? (local)"), hitMat.boolValue);
                    } else {
                        hitMat.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Reflection Tags", "Enable reflection tags? (local)"), hitMat.boolValue);
                    }
					EditorGUI.EndDisabledGroup();
					EditorGUI.EndDisabledGroup();

				EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();


			EditorGUI.BeginDisabledGroup(hit.boolValue == false);
			EditorGUI.BeginDisabledGroup(hitMat.boolValue == false);
			EditorGUI.BeginDisabledGroup(hitReflect.boolValue == false);
            if (hitScanMode.intValue == 1) {
                EditorTools.createMatsField2(hitMats, hitMatsInc, hitMatObjs);
            } else {
                EditorTools.createTagsField2(reflTag, reflTagInc, allowedTagObj);
            }
			EditorGUI.EndDisabledGroup();
			EditorGUI.EndDisabledGroup();
			EditorGUI.EndDisabledGroup();

			EditorGUILayout.Space();

            if (hitScanMode.intValue == 1) {
                EditorGUILayout.BeginHorizontal();

                EditorGUILayout.BeginVertical(GUILayout.Width(localWidth));
                localPassthroughMat.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localPassthroughMat.boolValue, GUILayout.MaxWidth(localWidth));
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
                passMat.boolValue = EditorGUILayout.Toggle(new GUIContent(" Passthrough Materials", "Enable pass-through materials? (local)"), passMat.boolValue);
                EditorGUILayout.EndVertical();

                EditorGUILayout.EndHorizontal();

			    EditorGUI.BeginDisabledGroup(hit.boolValue == false);
			    EditorGUI.BeginDisabledGroup(passMat.boolValue == false);
			    EditorGUI.BeginDisabledGroup(localPassthroughMat.boolValue == false);
			    EditorTools.createMatsField(passMats, passMatsInc);
			    EditorGUI.EndDisabledGroup();
			    EditorGUI.EndDisabledGroup();
			    EditorGUI.EndDisabledGroup();
            }

            EditorGUILayout.Space();
			EditorGUILayout.Space();



			EditorGUILayout.BeginHorizontal();

				EditorGUILayout.BeginVertical(GUILayout.Width(localWidth));
					localLineRenderer.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localLineRenderer.boolValue, GUILayout.MaxWidth(localWidth));
					localLineRendererWidth.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localLineRendererWidth.boolValue, GUILayout.MaxWidth(localWidth));

					EditorGUILayout.Space();

					localStartPower.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localStartPower.boolValue, GUILayout.MaxWidth(localWidth));
					localPowerCap.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localPowerCap.boolValue, GUILayout.MaxWidth(localWidth));
					localReflectionPowerInc.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localReflectionPowerInc.boolValue, GUILayout.MaxWidth(localWidth));
					localChargePowerInc.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localChargePowerInc.boolValue, GUILayout.MaxWidth(localWidth));

					EditorGUILayout.Space();

					localStartCapObj.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localStartCapObj.boolValue, GUILayout.MaxWidth(localWidth));
					localEndCapObj.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localEndCapObj.boolValue, GUILayout.MaxWidth(localWidth));
					localHitObj.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localHitObj.boolValue, GUILayout.MaxWidth(localWidth));
					localIntSctObj.boolValue = EditorGUILayout.Toggle(new GUIContent("", "If enabled, use this local value"), localIntSctObj.boolValue, GUILayout.MaxWidth(localWidth));

				EditorGUILayout.EndVertical();

				EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
					lineRenP.boolValue = EditorGUILayout.Toggle(new GUIContent("Set Line Renderer Width", "Set line renderer width via script? This will use the value below times by power level (local)"), lineRenP.boolValue);
					EditorGUI.BeginDisabledGroup(lineRenP.boolValue == false);
					lrWidth.floatValue = EditorGUILayout.FloatField(new GUIContent("Line Renderer Base Width", "This determines the base width of the line renderer, the final result will be the width times by power(local)"), lrWidth.floatValue);
					EditorGUI.EndDisabledGroup();

					EditorGUILayout.Space();

					powerSt.floatValue = EditorGUILayout.FloatField(new GUIContent("Starting Power", "The starting power of this laser (local)"), powerSt.floatValue);
					powerCap.floatValue = EditorGUILayout.FloatField(new GUIContent("Power Cap", "The maximum power of this laser (local)"), powerCap.floatValue);
					reflInc.floatValue = EditorGUILayout.FloatField(new GUIContent("Reflection Power Increase", "Multiply the reflected laser by this number, a reflected laser starting at 2 with this value at 3 will finish at 6 (local)"), reflInc.floatValue);
					chargeInc.floatValue = EditorGUILayout.FloatField(new GUIContent("Charge Power Increase", "Multiply the charged laser by this number, a charged laser starting at 2 with this value at 3 will finish at 6 (local)"), chargeInc.floatValue);

					EditorGUILayout.Space();

					startCapObj.objectReferenceValue = EditorGUILayout.ObjectField("Start Cap", startCapObj.objectReferenceValue, typeof(GameObject));
					endCapObj.objectReferenceValue = EditorGUILayout.ObjectField("End Cap", endCapObj.objectReferenceValue, typeof(GameObject));
					hitObj.objectReferenceValue = EditorGUILayout.ObjectField("Hit FX", hitObj.objectReferenceValue, typeof(GameObject));
					intSctObj.objectReferenceValue = EditorGUILayout.ObjectField("Intersection FX", intSctObj.objectReferenceValue, typeof(GameObject));
			
				EditorGUILayout.EndVertical();

			EditorGUILayout.EndHorizontal();

			EditorGUI.EndDisabledGroup();

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			EditorGUILayout.LabelField(new GUIContent("Passed Values", "Values and variables accessible from this script, worked out by the laser system"), EditorStyles.boldLabel);

			string objectName = "null";

			if (intSctGo.objectReferenceValue) {
				objectName = intSctGo.objectReferenceValue.name.ToString();
			}

			EditorGUILayout.LabelField("End Postion", intPos.vector3Value.ToString());
			//EditorGUI.BeginDisabledGroup(false == false);
			EditorGUILayout.LabelField("Is Child?", isChild.boolValue.ToString());
			EditorGUILayout.LabelField("Group", groupId.stringValue);
			EditorGUILayout.ObjectField("Intersection Laser", intSctGo.objectReferenceValue, typeof(GameObject));
			EditorGUILayout.ObjectField("Hit GameObject", hitGO.objectReferenceValue, typeof(GameObject));
			//EditorGUI.EndDisabledGroup();
			EditorGUILayout.LabelField("Hit Distance", hitDist.floatValue.ToString());
            //EditorGUI.BeginDisabledGroup(false == false);
            EditorGUILayout.ObjectField("Child", directChild.objectReferenceValue, typeof(GameObject));
            EditorGUILayout.ObjectField("Parent 1", parent1.objectReferenceValue, typeof(GameObject));
			EditorGUILayout.ObjectField("Parent 2", parent2.objectReferenceValue, typeof(GameObject));
			EditorGUILayout.ObjectField("Origin 1", origin1.objectReferenceValue, typeof(GameObject));
			EditorGUILayout.ObjectField("Origin 2", origin2.objectReferenceValue, typeof(GameObject));
			//EditorGUI.EndDisabledGroup();
			EditorGUILayout.LabelField("Current Power Level", curPower.floatValue.ToString());

			EditorGUILayout.EndVertical();

			m_object.ApplyModifiedProperties();
		}
	}

}
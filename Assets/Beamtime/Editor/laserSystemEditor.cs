using UnityEngine;
using System.Collections;
using UnityEditor;
using eageramoeba.Lasers;

namespace eageramoeba.Lasers {

	[CustomEditor(typeof(laserSystem))]
	public class laserSystemEditor : Editor {

		SerializedObject m_object;

		SerializedProperty infLM;
		SerializedProperty infLI;
		SerializedProperty infProt;
		private string[] infOptions = new string[] { "Flicker", "Specify", "Last", "Ignore"};

        SerializedProperty reflTag;
        SerializedProperty reflTagInc;
        SerializedProperty pasTag;
        SerializedProperty pasTagInc;
        SerializedProperty hitScanMode;
        SerializedProperty allowedTagObj;
        private string[] hitRPOptions = new string[] { "Tag", "Material"};

        SerializedProperty controlSwitch;
		SerializedProperty onSys;
		SerializedProperty minIntDist;

		SerializedProperty length;
		SerializedProperty intersect;
		SerializedProperty reflect;
		SerializedProperty reflectLRemainder;

		SerializedProperty upd8lrpos;
		SerializedProperty lasLineREff;
		SerializedProperty lrWidth;

		SerializedProperty endCapB;
		SerializedProperty startCapB;
		SerializedProperty hitObjB;
		SerializedProperty reflectStCap;

		SerializedProperty hitRefl;
		SerializedProperty canHit;
		SerializedProperty hitMask;
		SerializedProperty hitReflMat;
		SerializedProperty passReflMat;
		SerializedProperty allowedMat;
		SerializedProperty allowedMatObj;
		SerializedProperty passMat;
		SerializedProperty reflMatInc;
		SerializedProperty pasMatInc;

		SerializedProperty laserGO;
		SerializedProperty intSctGO;
		SerializedProperty hitGO;
		SerializedProperty startCapGO;
		SerializedProperty endCapGO;
		SerializedProperty desSpObj;
		SerializedProperty disalbePartObj;

		SerializedProperty powerStart;
		SerializedProperty reflInc;
		SerializedProperty chargeInc;
		SerializedProperty powerCap;

		SerializedProperty mode2D;
		SerializedProperty hit2DDistance;

		SerializedProperty enablePool;

		SerializedProperty nextSc;

		void OnEnable() {
			m_object = new SerializedObject(target);

			onSys = m_object.FindProperty("onSys");

			minIntDist = m_object.FindProperty("minIntDist");

			length = m_object.FindProperty("rayL");
			intersect = m_object.FindProperty("intersect");
			reflect = m_object.FindProperty("reflect");
			reflectLRemainder = m_object.FindProperty("reflectLRemainder");

			upd8lrpos = m_object.FindProperty("updateLrPos");
			lasLineREff = m_object.FindProperty("lasLineREff");
			lrWidth = m_object.FindProperty("lrWidth");

			endCapB = m_object.FindProperty("endCapB");
			startCapB = m_object.FindProperty("startCapB");
			hitObjB = m_object.FindProperty("hitObjB");
			reflectStCap = m_object.FindProperty("reflectStCap");

			hitRefl = m_object.FindProperty("hitRefl");
			canHit = m_object.FindProperty("canHit");
			hitMask = m_object.FindProperty("hitLayerM");
			hitReflMat = m_object.FindProperty("hitReflMat");
			passReflMat = m_object.FindProperty("passReflMat");
			allowedMat = m_object.FindProperty("allowedMat");
			allowedMatObj = m_object.FindProperty("allowedMatObj");
			passMat = m_object.FindProperty("passMat");
			reflMatInc = m_object.FindProperty("reflMatInc");
			pasMatInc = m_object.FindProperty("pasMatInc");

			laserGO = m_object.FindProperty("laserObj");
			intSctGO = m_object.FindProperty("intSctObj");
			hitGO = m_object.FindProperty("hitObj");
			startCapGO = m_object.FindProperty("startCapObj");
			endCapGO = m_object.FindProperty("endCapObj");
			desSpObj = m_object.FindProperty("desSpObj");
			disalbePartObj = m_object.FindProperty("disalbePartObj");

			powerStart = m_object.FindProperty("powerStart");
			reflInc = m_object.FindProperty("reflInc");
			chargeInc = m_object.FindProperty("chargeInc");
			powerCap = m_object.FindProperty("powerCap");

			mode2D = m_object.FindProperty("mode2D");
			hit2DDistance = m_object.FindProperty("hit2DDistance");
			controlSwitch = m_object.FindProperty("controlSwitch");
			infProt = m_object.FindProperty("infProt");
			infLM = m_object.FindProperty("infLM");
			infLI = m_object.FindProperty("infLI");
			enablePool = m_object.FindProperty("enablePool");
			nextSc = m_object.FindProperty("nextSc");

            reflTag = m_object.FindProperty("reflTag");
            reflTagInc = m_object.FindProperty("reflTagInc");
            pasTag = m_object.FindProperty("pasTag");
            pasTagInc = m_object.FindProperty("pasTagInc");
            hitScanMode = m_object.FindProperty("hitScanMode");
            allowedTagObj = m_object.FindProperty("allowedTagObj");
        }

		public override void OnInspectorGUI() {
			DrawDefaultInspector();
			m_object.Update();

			laserSystem script = (laserSystem)target;

			EditorGUILayout.LabelField(new GUIContent("Global Options", "Options all lasers us when not in local mode"), EditorStyles.boldLabel);

			onSys.boolValue = EditorGUILayout.Toggle(new GUIContent("System On?", "If checked, this activates the laser system."), onSys.boolValue);

			EditorGUILayout.Space();

			enablePool.boolValue = EditorGUILayout.Toggle(new GUIContent("Enable Object Pooling?", "Enable basic pooling, increases performance"), enablePool.boolValue);

			EditorGUILayout.Space();

			nextSc.floatValue = EditorGUILayout.FloatField(new GUIContent("Cleanup Interval", "(Seconds) Interval the cleanup script runs, useful to remove orphaned FX that happen due to large amounts of switching. The larger the value, the less GC overhead."), nextSc.floatValue);

			EditorGUILayout.Space();

			infLM.intValue = EditorGUILayout.Popup("Infinite Loop Protection Mode", infLM.intValue, infOptions);
			EditorGUI.BeginDisabledGroup(infLM.intValue != 1);
			infLI.intValue = EditorGUILayout.IntField(new GUIContent("Specify Position", "Set the maximum position of the infinite loop protection (max position referring to the furthest intersect from origin)"), infLI.intValue);
			EditorGUI.EndDisabledGroup();
			infProt.boolValue = EditorGUILayout.Toggle(new GUIContent("Self Infinite Loop Protection", "If checked, this protects the system from self infinite loops. When a laser intersects with one of it’s origin lasers, the system ignores it. Recommended on unless levels are specifically designed to avoid this."), infProt.boolValue);

			EditorGUILayout.Space();

			controlSwitch.boolValue = EditorGUILayout.Toggle(new GUIContent("Control Laser On/Off", "If checked, allows the system to control the lasers on/off values. Helps when lasers are created and they are intiially facing the wrong direction."), controlSwitch.boolValue);

			EditorGUILayout.Space();

			EditorGUI.BeginDisabledGroup(onSys.boolValue == false);

			mode2D.boolValue = EditorGUILayout.Toggle(new GUIContent("2D Mode?", "If checked, system will execute code for 2D games. If unchecked, system will execute code for 3D games."), mode2D.boolValue);
			EditorGUI.BeginDisabledGroup(mode2D.boolValue == false);
			hit2DDistance.floatValue = EditorGUILayout.FloatField(new GUIContent("2D Hit Dist Spawn", "Spawn spacing of new lasers reflecting from a 2D hit, required to be over 0 or bugs will occur."), hit2DDistance.floatValue);
			EditorGUI.EndDisabledGroup();

			EditorGUILayout.Space();

			laserGO.objectReferenceValue = EditorGUILayout.ObjectField("Laser GameObject", laserGO.objectReferenceValue, typeof(GameObject));

			EditorGUILayout.Space();

			minIntDist.floatValue = EditorGUILayout.FloatField(new GUIContent("Intersect Distance", "Distance between closest points on each laser before an intersection is created"), minIntDist.floatValue);

			EditorGUILayout.Space();

			upd8lrpos.boolValue = EditorGUILayout.Toggle(new GUIContent("Update Line Renderers", "Enable updating of the line renderer component for each laser"), upd8lrpos.boolValue);
			EditorGUI.BeginDisabledGroup(upd8lrpos.boolValue == false);
			lasLineREff.boolValue = EditorGUILayout.Toggle(new GUIContent("Set Line Renderer Width", "Set line renderer width via script? This will use the value below times by power level"), lasLineREff.boolValue);
			lrWidth.floatValue = EditorGUILayout.FloatField(new GUIContent("Line Renderer Base Width", "This determines the base width of the line renderer, the final result will be the width times by power"), lrWidth.floatValue);
			EditorGUI.EndDisabledGroup();

			EditorGUILayout.Space();

			length.floatValue = EditorGUILayout.FloatField(new GUIContent("Length", "The length of each laser"), length.floatValue);
			intersect.boolValue = EditorGUILayout.Toggle(new GUIContent("Intersect", "Enable lasers that intersect to have an effect"), intersect.boolValue);
			reflect.boolValue = EditorGUILayout.Toggle(new GUIContent("Reflect", "When lasers intersect, create a reflection"), reflect.boolValue);
			reflectLRemainder.boolValue = EditorGUILayout.Toggle(new GUIContent("Reflect Remaining Length", "When reflecting, reflecting laser has a length equal to the remainder of both parents combined at the point of intersection or hit"), reflectLRemainder.boolValue);

			EditorGUILayout.Space();

			canHit.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit", "Allow lasers to collide with colliders"), canHit.boolValue);

			EditorGUI.BeginDisabledGroup(canHit.boolValue == false);
			EditorGUILayout.PropertyField(hitMask);

			EditorGUILayout.Space();
            hitScanMode.intValue = EditorGUILayout.Popup("Hit Scan Mode", hitScanMode.intValue, hitRPOptions);
            EditorGUILayout.Space();

            hitRefl.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Reflect", "Enable hit reflection"), hitRefl.boolValue);
			EditorGUI.BeginDisabledGroup(hitRefl.boolValue == false);
            if (hitScanMode.intValue == 1) {
                hitReflMat.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Reflect Materials", "Enable hit reflection by material (see array for list of materials this applies to)"), hitReflMat.boolValue);
                EditorGUI.BeginDisabledGroup(hitReflMat.boolValue == false);
                EditorTools.createMatsField2(allowedMat, reflMatInc, allowedMatObj);
                EditorGUI.EndDisabledGroup();
            } else {
                hitReflMat.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Reflect Tags", "Enable hit reflection by tag (see array for list of tags this applies to)"), hitReflMat.boolValue);
                EditorGUI.BeginDisabledGroup(hitReflMat.boolValue == false);
                EditorTools.createTagsField2(reflTag, reflTagInc, allowedTagObj);
                EditorGUI.EndDisabledGroup();
            }
            EditorGUI.EndDisabledGroup();

			EditorGUILayout.Space();
            
			if (hitScanMode.intValue == 1) {
                EditorGUI.BeginDisabledGroup(mode2D.boolValue == true);
                passReflMat.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Passthrough Materials", "Enable hit passthrough by material (see array for list of materials this applies to)"), passReflMat.boolValue);
                EditorGUI.BeginDisabledGroup(passReflMat.boolValue == false);
                EditorTools.createMatsField(passMat, pasMatInc);
                EditorGUI.EndDisabledGroup();
                EditorGUI.EndDisabledGroup();
            } //else {
              //passReflMat.boolValue = EditorGUILayout.Toggle(new GUIContent("Hit Passthrough Tags", "Enable hit passthrough by tag (see array for list of tags this applies to)"), passReflMat.boolValue);
              //EditorGUI.BeginDisabledGroup(passReflMat.boolValue == false);
              //EditorTools.createTagsField(pasTag, pasTagInc);
              //EditorGUI.EndDisabledGroup();
              //}
            EditorGUI.EndDisabledGroup();

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			powerStart.floatValue = EditorGUILayout.FloatField(new GUIContent("Starting Power", "The starting power of this laser"), powerStart.floatValue);
			powerCap.floatValue = EditorGUILayout.FloatField(new GUIContent("Power Cap", "The maximum power of this laser"), powerCap.floatValue);
			reflInc.floatValue = EditorGUILayout.FloatField(new GUIContent("Reflection Power Increase", "Multiply the reflected laser by this number, a reflected laser starting at 2 with this value at 3 will finish at 6"), reflInc.floatValue);
			chargeInc.floatValue = EditorGUILayout.FloatField(new GUIContent("Charge Power Increase", "Multiply the charged laser by this number, a charged laser starting at 2 with this value at 3 will finish at 6"), chargeInc.floatValue);

			EditorGUILayout.Space();

			EditorGUILayout.LabelField(new GUIContent("Cap Objects", "Set the cap objects that are created when conditions are met"), EditorStyles.boldLabel);

			desSpObj.floatValue = EditorGUILayout.FloatField(new GUIContent("Destroy Delay", "Delay when destroying spawned caps"), desSpObj.floatValue);
			disalbePartObj.boolValue = EditorGUILayout.Toggle(new GUIContent("Enhance deletion of FX", "Disable all particle systems in the children objects and the original object"), disalbePartObj.boolValue);

			EditorGUILayout.BeginHorizontal();
			startCapB.boolValue = EditorGUILayout.Toggle(new GUIContent("Enable Start-Caps", "Use DestroyFX to enhance deletion of FX objects."), startCapB.boolValue);
			EditorGUI.BeginDisabledGroup(startCapB.boolValue == false);
			startCapGO.objectReferenceValue = EditorGUILayout.ObjectField(startCapGO.objectReferenceValue, typeof(GameObject));
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			endCapB.boolValue = EditorGUILayout.Toggle(new GUIContent("Enable End-Caps", "Enable the creation of end caps, gameobjects that appear at and follow the end of a laser"), endCapB.boolValue);
			EditorGUI.BeginDisabledGroup(endCapB.boolValue == false);
			endCapGO.objectReferenceValue = EditorGUILayout.ObjectField(endCapGO.objectReferenceValue, typeof(GameObject));
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			hitObjB.boolValue = EditorGUILayout.Toggle(new GUIContent("Enable Hit FX", "Enable the creation of hit fx, gameobjects that appear at and follow hit locations"), hitObjB.boolValue);
			EditorGUI.BeginDisabledGroup(hitObjB.boolValue == false);
			hitGO.objectReferenceValue = EditorGUILayout.ObjectField(hitGO.objectReferenceValue, typeof(GameObject));
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			reflectStCap.boolValue = EditorGUILayout.Toggle(new GUIContent("Enable Intersection FX", "Enable the creation of intersection fx, gameobjects that appear at and follow intersection locations"), reflectStCap.boolValue);
			EditorGUI.BeginDisabledGroup(reflectStCap.boolValue == false);
			intSctGO.objectReferenceValue = EditorGUILayout.ObjectField(intSctGO.objectReferenceValue, typeof(GameObject));
			EditorGUI.EndDisabledGroup();
			EditorGUILayout.EndHorizontal();

			EditorGUI.EndDisabledGroup();

			EditorGUILayout.Space();

			m_object.ApplyModifiedProperties();
		}

	}

}
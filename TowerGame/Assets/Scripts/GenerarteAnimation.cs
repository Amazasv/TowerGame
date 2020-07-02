using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GenerarteAnimation : MonoBehaviour
{
    [SerializeField]
    private int cnt = 16;
    [SerializeField]
    private AnimatorOverrideController animOVR = null;
    [SerializeField]
    private string resourcesFolderPath = "";
    [SerializeField]
    private string animationFolderPath = "";
    [SerializeField]
    private string unitName = "";
    [SerializeField]
    private string fileName = "";

    private string[] types = new string[] { "w", "i", "a", "d", "c" };
    private string[] folderName = new string[] { "Walk", "Idle", "Attack", "Death", "Decay" };


    private void Awake()
    {
        for (int i = 0; i < types.Length; i++)
        {
            AssetDatabase.CreateFolder(animationFolderPath + "/" + unitName, folderName[i]);
            Sprite[] sprites = Resources.LoadAll<Sprite>(resourcesFolderPath + "/" + unitName + "/" + types[i] + "_" + fileName);
            for (int j = 0; j < cnt; j++)
                CreateAnim(sprites, j, i);
        }
    }


    private void CreateAnim(Sprite[] sprites, int dir, int index)
    {
        Debug.Log(sprites.Length);
        int startIndex = dir * sprites.Length / cnt;
        AnimationClip animClip = new AnimationClip();
        animClip.frameRate = 60;   // FPS
        EditorCurveBinding spriteBinding = new EditorCurveBinding();
        spriteBinding.type = typeof(SpriteRenderer);
        spriteBinding.path = "";
        spriteBinding.propertyName = "m_Sprite";
        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[sprites.Length / cnt];
        for (int i = 0; i < (sprites.Length) / cnt; i++)
        {
            spriteKeyFrames[i] = new ObjectReferenceKeyframe();
            spriteKeyFrames[i].time = i * (1.0f / animClip.frameRate);
            spriteKeyFrames[i].value = sprites[startIndex + i];
        }
        AnimationUtility.SetObjectReferenceCurve(animClip, spriteBinding, spriteKeyFrames);
        AnimationClipSettings animClipSett = new AnimationClipSettings();
        animClipSett.loopTime = true;
        animClipSett.stopTime = (1.0f / animClip.frameRate) * sprites.Length / cnt;
        AnimationUtility.SetAnimationClipSettings(animClip, animClipSett);

        AssetDatabase.CreateAsset(animClip, animationFolderPath + "/" + unitName + "/" + folderName[index] + "/" + (dir / 10).ToString() + (dir % 10).ToString() + "_" + types[index] + "_" + fileName + ".anim");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        animOVR[(dir / 10).ToString() + (dir % 10).ToString() + "_" + types[index] + "_" + "sample"] = animClip;
    }
}

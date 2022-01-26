using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class WeaponEditor : EditorWindow
{
    private int viewIndex;

    public WeaponList inventoryItemList { get; private set; }

    [MenuItem ("Window/Weapon Editor")]
    static void Init()
        {
        EditorWindow.GetWindow (typeof(WeaponEditor));
        }
    private void OnEnable()
    {
        if(EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = "Assets/Resources/WeaponList.asset";
            inventoryItemList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(WeaponList)) as WeaponList;
        }
        if (inventoryItemList == null)
        {
            viewIndex = 1;

            WeaponList asset = ScriptableObject.CreateInstance<WeaponList>();
            AssetDatabase.CreateAsset(asset, "Assets/WeaponList.asset");
            AssetDatabase.SaveAssets();

            inventoryItemList = asset;

            if (inventoryItemList)
            {
                inventoryItemList.weaponList = new List<WeaponInfo>();
                string relPath = AssetDatabase.GetAssetPath(inventoryItemList);
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("Weapon Editor", EditorStyles.boldLabel);
        GUILayout.Space(10);
        if (inventoryItemList != null)
        {
            PrintTopMenu();
        }
        else
        {
            GUILayout.Space(10);
            GUILayout.Label("Can't load weapon list.");
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(inventoryItemList);
        }
    }

    private void PrintTopMenu()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(10);
        if (GUILayout.Button("<- Prev", GUILayout.ExpandWidth(false)))
        {
            if (viewIndex > 1)
                viewIndex--;
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Next ->", GUILayout.ExpandWidth(false)))
        { 
            if (viewIndex < inventoryItemList.weaponList.Count)
            {
                viewIndex++;
            }
        }
        GUILayout.Space(60);
        if (GUILayout.Button("+ Add Weapon", GUILayout.ExpandWidth(false)))
        {
            AddItem();
        }
        GUILayout.Space(5);
        if (GUILayout.Button("- Delete Weapon", GUILayout.ExpandWidth(false)))
        {
            DeleteItem(viewIndex - 1);
        }
        GUILayout.EndHorizontal();
        if (inventoryItemList.weaponList.Count > 0)
        {
            WeaponListMenu();
        }
        else
        {
            GUILayout.Space(10);
            GUILayout.Label("This Weapon list is Empty");
        }
    }

    private void DeleteItem(int index)
    {
        inventoryItemList.weaponList.RemoveAt(index);
    }

    private void WeaponListMenu()
    {
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Weapon", viewIndex, GUILayout.ExpandWidth(false)), 1, inventoryItemList.weaponList.Count);
        EditorGUILayout.LabelField("of " + inventoryItemList.weaponList.Count.ToString() + " weapon", "", GUILayout.ExpandWidth(false));
        GUILayout.EndHorizontal();
        string[] _choices = new string[inventoryItemList.weaponList.Count];
        for (int i = 0; i < inventoryItemList.weaponList.Count; i++)
        {
            _choices[i] = inventoryItemList.weaponList[i].m_name;
        }
        int _choiceIndex = viewIndex - 1;
        viewIndex = EditorGUILayout.Popup(_choiceIndex, _choices) + 1;

        //EditorUtility.SetDirty(someClass)
        GUILayout.Space(10);
        inventoryItemList.weaponList[viewIndex - 1].m_name = EditorGUILayout.TextField("Name", inventoryItemList.weaponList[viewIndex - 1].m_name as string);
        inventoryItemList.weaponList[viewIndex - 1].m_damage = EditorGUILayout.FloatField("Damage", inventoryItemList.weaponList[viewIndex - 1].m_damage);

        GUILayout.Label("Icon");
        inventoryItemList.weaponList[viewIndex - 1].m_isAShotgun = (bool)EditorGUILayout.Toggle("Body", inventoryItemList.weaponList[viewIndex - 1].m_isAShotgun, GUILayout.ExpandWidth(false));
    }

    private void AddItem()
    {
        WeaponInfo newItem = new WeaponInfo();
        newItem.m_name = "New Weapon";
        inventoryItemList.weaponList.Add(newItem);
        viewIndex = inventoryItemList.weaponList.Count - 1;
    }

}

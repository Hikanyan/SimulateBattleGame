using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HikanyanLaboratory.UI.InGameScene
{
    public class SelectCharacter : MonoBehaviour
    {
        private List<GameObject> _characterList = new List<GameObject>();
        private void Awake()
        {
            // 自分の階層の以下のオブジェクトを全て取得
            foreach (Transform child in transform)
            {
                _characterList.Add(child.gameObject);
            }
        }

        public void OnSubmit()
        {
            // 選択されているオブジェクトを取得
            GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
            
            // 選択されているオブジェクトが自分の階層のオブジェクトであるか確認
            if (_characterList.Contains(selectedObject))
            {
                Debug.Log("選択されたキャラクター: " + selectedObject.name);
            }
        }
    }
}
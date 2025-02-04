using System;
using System.Collections.Generic;
using HikanyanLaboratory.Player;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace HikanyanLaboratory.UI
{
    public class CardListView : MonoBehaviour
    {
        [SerializeField] private List<CharacterCard> _characterCards = new List<CharacterCard>();

        public void Awake()
        {
            foreach (var characterCard in _characterCards)
            {
                Debug.Log(characterCard);
            }
        }
    }
}
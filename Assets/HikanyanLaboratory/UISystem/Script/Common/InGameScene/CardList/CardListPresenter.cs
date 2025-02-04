using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HikanyanLaboratory.UI
{
    public class CardListPresenter : ListPresenterBase<CardListView, CardListItemModel>
    {
        [SerializeField] private CardListView _view;
        [SerializeField] private CardListItemModel _model;

        public Action OnCellClickedCallback;

        public override async UniTask InitializeAsync(CancellationToken ct)
        {
            SetEvent();
            Debug.Log("<color=green> CardListPresenter Initialized</color>");
        }

        private void SetEvent()
        {
            OnCellClickedCallback += () => Debug.Log("Cell Clicked");
        }
    }
}
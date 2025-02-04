using HikanyanLaboratory.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HikanyanLaboratory.Player
{
    public class CharacterCard : ScreenNode
    {
        [SerializeField] private CharacterStatus _characterStatus = null;
        [SerializeField] private TMP_Text _nameText = null;
        [SerializeField] private Slider _hpSlider = null;
        [SerializeField] private Image _characterImage = null; // 追加: キャラクター画像表示用

        public override void OnInitialize()
        {
            
            Initialize(_characterStatus);
        }
        
        public void Initialize(CharacterStatus status)
        {
            _characterStatus = status;
            _nameText.text = _characterStatus.Name;
            _hpSlider.maxValue = _characterStatus.MaxHp;
            _hpSlider.value = _characterStatus.Hp;

            // Addressableから非同期でSpriteを読み込む
            LoadCharacterSprite(_characterStatus.SpritePath);
        }

        private void LoadCharacterSprite(string spritePath)
        {
            Addressables.LoadAssetAsync<Sprite>(spritePath).Completed += OnSpriteLoaded;
        }

        private void OnSpriteLoaded(AsyncOperationHandle<Sprite> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _characterImage.sprite = handle.Result;
            }
            else
            {
                Debug.LogError($"Failed to load sprite from path: {_characterStatus.SpritePath}");
            }
        }

        // HPの更新
        public void UpdateHp(int newHp)
        {
            _characterStatus.Hp = Mathf.Clamp(newHp, 0, _characterStatus.MaxHp);
            _hpSlider.value = _characterStatus.Hp;

            if (!_characterStatus.IsAlive)
            {
                HandleDeath();
            }
        }

        // キャラクターが死亡した際の処理
        private void HandleDeath()
        {
            Debug.Log($"{_characterStatus.Name} has been defeated.");
            _characterImage.color = Color.gray; // 死亡時はグレースケール表示
        }
    }
}
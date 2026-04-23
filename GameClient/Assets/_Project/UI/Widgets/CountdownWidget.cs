using TMPro;
using UnityEngine;

namespace BikeSuperRacing.UI.Widgets
{
    public sealed class CountdownWidget : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private GameObject _root;

        public void ShowValue(int value)
        {
            var target = _root != null ? _root : gameObject;
            target.SetActive(true);

            if (_valueText != null)
            {
                _valueText.text = value > 0 ? value.ToString() : string.Empty;
            }
        }

        public void Hide()
        {
            var target = _root != null ? _root : gameObject;
            target.SetActive(false);

            if (_valueText != null)
            {
                _valueText.text = string.Empty;
            }
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InputFieldsReader : MonoBehaviour
    {
        public Action<int, int, Vector3> FieldsChangeEvent;

        [SerializeField] private InputField _speedField;
        [SerializeField] private InputField _xDistanceField;
        [SerializeField] private InputField _zDistanceField;
        [SerializeField] private InputField _spawnTimeField;
        [SerializeField] private Button _applyButton;

        private void Start()
        {
            if(_applyButton != null)
                _applyButton.onClick.AddListener(ReadFields);

        }

        private void ReadFields()
        {
            var speed = IsFieldEmpty(_speedField) ? 0 : int.Parse(_speedField.text);
            var spawnTime = IsFieldEmpty(_spawnTimeField) ? 0 : int.Parse(_spawnTimeField.text);
            
            var xPos = IsFieldEmpty(_xDistanceField) ? 0 : int.Parse(_xDistanceField.text);
            var zPos = IsFieldEmpty(_zDistanceField) ? 0 : int.Parse(_zDistanceField.text);
            var distance = new Vector3(xPos, 0, zPos);

            FieldsChangeEvent?.Invoke(speed, spawnTime, distance);

            _speedField.text = "";
            _spawnTimeField.text = "";
            _xDistanceField.text = "";
            _zDistanceField.text = "";
        }

        private bool IsFieldEmpty(InputField inputField)
        {
            if (string.IsNullOrEmpty(inputField.text))
                return true;

            return false;
        }
    }
}
using UnityEngine;

namespace ScriptablePlayerStats
{
    [CreateAssetMenu(fileName = "ScriptablePlayerStats", menuName = "Variables/ScriptablePlayerStats", order = 50)]

    public class SavePlayerStats : ScriptableObject
    {
        public delegate void OnVariableChangeEvent(string value);

        private event OnVariableChangeEvent _listeners;

        public event OnVariableChangeEvent Listeners
        {
            add
            {
                _listeners -= value;
                _listeners += value;
            }
            remove => _listeners -= value;
        }

        [SerializeField] private string _value;

        public string GetValue()
        {
            return _value;
        }        
        
        public void SetValue(string value)
        {
            _value = value;
            Raise();
        }



        private void Raise()
        {
            _listeners?.Invoke(_value);
        }
    }
}

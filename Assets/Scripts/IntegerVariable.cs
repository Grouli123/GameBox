using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "IntegerVariable", menuName = "Variables/IntegerVariable", order = 50)]
    public class IntegerVariable : ScriptableObject
    {
        public delegate void OnVariableChangeEvent(int value);

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

        [SerializeField] private int _value;

        public int GetValue()
        {
            return _value;
        }        
        
        public void SetValue(int value)
        {
            _value = value;
            Raise();
        }

        public void ApplyChange(int value)
        {
            _value += value;
            Raise();
        }

        private void Raise()
        {
            _listeners?.Invoke(_value);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Inventory;

namespace Game
{
    public class Attribute
    {
        public Action<Pawn, int> OnValueChange;
        public Action<Pawn, int> OnMaxValueChange;

        public Pawn Pawn { get; protected set; }

        public AttributeType Type { get; protected set; }

        protected int m_maxValue;
        public int MaxValue
        {
            get
            {
                return m_maxValue;
            }
            set
            {
                m_maxValue = value;
                if (OnMaxValueChange != null)
                {
                    OnMaxValueChange(Pawn, m_maxValue);
                }
            }
        }

        protected int m_value;
        public int Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;
                if (OnValueChange != null)
                {
                    OnValueChange(Pawn, m_value);
                }
            }
        }

        public Attribute(int _value, int _maxValue, Pawn _pawn, AttributeType _type)
        {
            Value = _value;
            MaxValue = _maxValue;
            Pawn = _pawn;
            Type = _type;
        }

        public void Set(int _value)
        {
            Value = _value;
        }

        public void SetMaxValue(int _value)
        {
            MaxValue = _value;
        }


    }
}
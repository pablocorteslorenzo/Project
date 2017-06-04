using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skill
{
    public abstract class BaseSkill
    {
        public SkillData Data;

        public bool SelectingTarget;

        private float m_cooldownControlTime;

        virtual public void Initialize(SkillData _data)
        {
            Data = _data;
        }

        public abstract void Process(SkillProcessData _data);
        public abstract void Cancel();
    }
}

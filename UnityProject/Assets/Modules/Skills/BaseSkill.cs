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

        public abstract void Execute();
        public abstract void Cancel();
    }

    public class SkillData
    {
        public string ID;
        public string Name;
        public string Description;

        public string ImagePath;
        public bool AllowMultipleTargets;
        public int TargetCountLimit;

        public bool NeedTileTarget;
        public bool NeedPawnTarget;
        public bool NeedLootTarget;
        public bool NeedGatherTarget;

        public float CooldownTime;
    }
}

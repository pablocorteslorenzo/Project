
namespace Skill
{
    public class SkillData
    {
        public string ID;
        public string Name;
        public string Description;

        public string ImagePath;

        public bool AllowMultipleTargets;
        public int TargetCountLimit;

        public SkillTarget Target;

        public float CooldownTime;
    }
}

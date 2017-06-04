
namespace Skill
{
    public class BasicAttackSkill : BaseSkill
    {
        override public void Initialize(SkillData _data)
        {
            base.Initialize(_data);
        }

        public override void Process(SkillProcessData _data)
        {
            if (_data.Step == "Select")
            {
                SelectTarget();
            }
        }

        private void SelectTarget()
        {

        }

        private void ExecuteSkill()
        {

        }

        public override void Cancel()
        {

        }
    }
}

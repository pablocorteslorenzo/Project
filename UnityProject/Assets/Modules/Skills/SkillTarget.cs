
namespace Skill
{
    public enum SkillTarget
    {
        None = 0,
        Passive = 1 << 0,
        Self = 1 << 1,
        AnyPawn = 1 << 2,
        EnemyPawn = 1 << 3,
        AllyPawn = 1 << 4,
        Tile = 1 << 5,
        Loot = 1 << 6,
        Gather = 1 << 7,
        Direction = 1 << 8,
        Area = 1 << 9,
    }
}
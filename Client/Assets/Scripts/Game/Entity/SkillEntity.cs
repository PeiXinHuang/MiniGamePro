
public enum SkillType
{
    Explose = 1,
}
public class SkillEntity : Entity
{
    public Entity activater;
    public List<Entity> accepters;
    public SkillEntity(Entity entity)
    {
        activater = entity;
    }
    public virtual bool isTrigger()
    {
        return true;
    }
    public virtual void UpdateAccepters()
    {

    }
    public virtual void Apply(float time)
    {
        
    }
}
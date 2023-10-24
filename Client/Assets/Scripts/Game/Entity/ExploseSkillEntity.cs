public class ExploseSkillEntity : SkillEntity
{
    private float lastTime = 1;
    private float distance = 2.0f;
    public ExploseSkillEntity(Entity entity) : base(entity)
    {
        
    }
    public override bool isTrigger()
    {
        return true;
    }
    public override void UpdateAccepters()
    {
        accepters = new List<Entity>();
        foreach(Entity monster in EntityManager.Instance.GetEntityWithTypeComp<MonsterEntity, TransformComponent>())
        {
            Vector3 monPos = monster.GetComponent<TransformComponent>().position;
            if(Vector3.Distance(this.GetComponent<TransformComponent>().position, monPos) < distance)
            {
                accepters.Add(monster);
            }
        }
    }
    public override void Apply(float time)
    {
        lastTime -= time;
        if(lastTime <= 0)
        {
            this.AddComponent<DisposeComponent>();
            return;
        }   
        if(isTrigger())
        {
            this.UpdateAccepters();
            ShowAnim;
            foreach(var accept in accepters)
            {
                if(!accept.HasComponent<DisposeComponent>())
                {
                    accept.AddComponent<DisposeComponent>();
                    if(!LevelManager.Instance.isEnd)
                    {
                        activater.GetComponent<DataComponent>().killCount ++;
                        UIManager.Instance.SetScore(activater.GetComponent<DataComponent>().killCount);
                    }
                }
            }
        }
    }
    public bool hasShowAnim = false;
    public void ShowAnim()
    {
        if(!hasShowAnim)
        {
            //todo anim proxy
            RenderComponent render = this.GetComponent<RenderComponent>();
            Animator anim = render.gameObject.GetComponent<Animator>();
            anim.SetBool("isPlay", true);
            hasShowAnim = true;
        }
    }
}
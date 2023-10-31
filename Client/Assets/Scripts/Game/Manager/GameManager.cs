using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    protected void Awake()
    {

    }
    private void Start()
    {
        StartGmae();
    }
    private void Update()
    {
       
    }
    private void OnDestroy()
    {
        DisposeGame();
    }
    private void InitGame()
    {
        DataManager.Instance.Init();
        EntityManager.Instance.Init();
        SystemManager.Instance.Init();
        LevelManager.Instance.Init();
        EventManager.Instance.Init();
        UIManager.Instance.Init();
        PlayerInputManager.Instance.Init();
    }
    private void StartGame()
    {
        EntityManager.Instance.CreatePlayer();
        LevelManager.Instance.InitLevel();

        SystemManager.Instance.AddSystem<MoveSystem>();
        SystemManager.Instance.AddSystem<SpawnGoodsSystem>();
        SystemManager.Instance.AddSystem<CollisionSystem>();
     
        SystemManager.Instance.AddSystem<CombatSystem>();
        SystemManager.Instance.AddSystem<DisposeSystem>();
        SystemManager.Instance.AddSystem<RenderSystem>();
    }


    private void InitData()
    {

    }

    private void DisposeGame()
    {

    }

    private void OnDestroy()
    {
        
    }
}

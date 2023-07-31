using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteManager : Manager<SpriteManager>
{
    public Dictionary<string, SpriteAtlas> altasDir = null;
    public override void Initialize()
    {
        base.Initialize();
        altasDir = new Dictionary<string, SpriteAtlas>();
    }
    public void SetSprite(Image image, string altasName, string spriteId)
    {
        if (!altasDir.ContainsKey(altasName))
        {
            SpriteAtlas altas = ResourcesManager.Instance.LoadAltas(altasName);
            altasDir[altasName] = altas;
        }
        Sprite sprite = altasDir[altasName].GetSprite(spriteId);
        image.sprite = sprite;
    }
    public void SetSprite(SpriteRenderer spriteRenderer, string altasName, string spriteId)
    {
        if (!altasDir.ContainsKey(altasName))
        {
            SpriteAtlas altas = ResourcesManager.Instance.LoadAltas(altasName);
            altasDir[altasName] = altas;
        }

        Sprite sprite = altasDir[altasName].GetSprite(spriteId);
        if(sprite == null)
        {
            UDebug.LogWarning(spriteId.ToString() + "ЮЊПе");
        }
        spriteRenderer.sprite = sprite;
    }
}

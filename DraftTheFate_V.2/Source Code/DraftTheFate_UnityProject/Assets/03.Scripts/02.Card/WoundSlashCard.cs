using System.Collections;
using UnityEngine;

public class WoundSlashCard : Card
{
    protected override void Update()
    {
        base.Update();
        explanationText.text = "적에게 데미지" + (damage + Player.instance.woundSlashCount) + "을 줍니다. 상처 찌르기 카드의 데미지를 1 증가시킵니다.";
    }

    public override bool UseSkill()
    {
        if (Player.instance.cost >= cost)
        {
            GameDirector.instance.monster.TakeDamage(damage + Player.instance.woundSlashCount);
            AudioManager.instance.PlayEffect("SwordSound01");
            Player.instance.woundSlashCount++;
            Player.instance.UseCost(cost);
            return true;
        }
        return false;
    }
}
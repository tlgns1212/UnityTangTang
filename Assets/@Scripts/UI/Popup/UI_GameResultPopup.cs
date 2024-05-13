using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameResultPopup : UI_Base
{
    #region UI ��� ����Ʈ
    // ���� ����
    // ResultStageValueText : �ش� �������� ��
    // ResultSurvivalTimeValueText : �������� Ŭ���� ���� �ɸ� �ð� ( mm:ss �� ǥ��)
    // ResultGoldValueText : �ױ��� ���� ���� ���
    // ResultKillValueText : �ױ��� ���� ų ��
    // ResultRewardScrollContentObject : : �������� ��Ե� �������� �� �θ� ��ü
    // (���, ����ġ, ������, ĳ���� ��ȭ�� ���� ��������)

    // ���ö���¡ �ؽ�Ʈ
    // GameResultPopupTitleText
    // ResultSurvivalTimeText
    // ConfirmButtonText
    #endregion

    enum GameObjects
    {
        ContentObject,
        ResultRewardScrollContentObject,
        ResultGoldObject,
        ResultKillObject,
    }

    enum Texts
    {
        GameResultPopupTitleText,
        ResultStageValueText,
        ResultSurvivalTimeText,
        ResultSurvivalTimeValueText,
        ResultGoldValueText,
        ResultKillValueText,
        ConfirmButtonText,
    }

    enum Buttons
    {
        StatisticsButton,
        ConfirmButton,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.StatisticsButton).gameObject.BindEvent(OnClickStatisticsButton);
        GetButton((int)Buttons.ConfirmButton).gameObject.BindEvent(OnClickConfirmButton);

        RefreshUI();
        return true;
    }

    public void SetInfo()
    {
        RefreshUI();
    }

    void RefreshUI()
    {
        if (_init == false)
            return;

        // ���� ����
        GetText((int)Texts.GameResultPopupTitleText).text = "Game Result";
        GetText((int)Texts.ResultStageValueText).text = "4 STAGE";
        GetText((int)Texts.ResultSurvivalTimeText).text = "Survival Time";
        GetText((int)Texts.ResultSurvivalTimeValueText).text = "14:23";
        GetText((int)Texts.ResultGoldValueText).text = "200";
        GetText((int)Texts.ResultKillValueText).text = "100";
        GetText((int)Texts.ConfirmButtonText).text = "OK";
    }

    void OnClickStatisticsButton()
    {
        Debug.Log("OnClickStatisticsButton");
    }

    void OnClickConfirmButton()
    {
		Debug.Log("OnClickConfirmButton");
	}
}

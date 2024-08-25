using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [Header("Initial Buttons")]
    [SerializeField]
    private Button UndoBet_Button;
    [SerializeField]
    private Button Deal_Button;
    [SerializeField]
    private Button ClearBet_Button;
    [SerializeField]
    private Button DoubleBet_Button;
    [SerializeField]
    private Button MainBet_Button;
    [SerializeField]
    private Button MultiplierBet_Button;
    [SerializeField]
    private Button Quit_Button;

    [Header("Middle Buttons")]
    [SerializeField]
    private Button Hit_Button;
    [SerializeField]
    private Button Stand_button;
    [SerializeField]
    private Button DoubleShow_Button;
    [SerializeField]
    private Button Split_Button;

    [Header("Rebet Buttons")]
    [SerializeField]
    private Button Rebet_Button;
    [SerializeField]
    private Button RebetDeal_Button;
    [SerializeField]
    private Button RebetDouble_Button;

    [Header("List & Arrays")]
    [SerializeField]
    private Button[] Chips_Button;
    [SerializeField]
    private GameObject[] Chips_Object;

    [Header("Betting Buttons")]
    [SerializeField]
    private Button LeftArr_Button;
    [SerializeField]
    private Button RightArr_Button;

    [Header("GameObjets")]
    [SerializeField]
    private GameObject InitialButtons_object;
    [SerializeField]
    private GameObject MiddleButtons_object;
    [SerializeField]
    private GameObject RebetButtons_object;
    [SerializeField]
    private GameObject MainBet_object;
    [SerializeField]
    private GameObject Player_Object;
    [SerializeField]
    private GameObject Dealer_Object;
    [SerializeField]
    private GameObject ChipBets_Object;
    [SerializeField]
    private GameObject Split_object;
    [SerializeField]
    private GameObject MiddleDouble_object;
    [SerializeField]
    private GameObject BetButton_Object;
    [SerializeField]
    private GameObject ChipContainer_Object;
    [SerializeField]
    private GameObject MultiplyBetButton_Object;
    [SerializeField]
    private GameObject ArrPointer_Object;
    [SerializeField]
    private GameObject FirstArrPointer_Object;
    [SerializeField]
    private GameObject SecondArrPointer_Object;


    [Header("Managers")]
    [SerializeField]
    private BJController BJmanager;

    [Header("Transforms")]
    [SerializeField]
    private Transform ScrollParent_Transform;
    [SerializeField]
    private Transform Selected_Transform;

    [Header("Dragon Animation Routine")]
    [SerializeField]
    private GameObject DragonNormal_Object;
    [SerializeField]
    private GameObject DragonFire_Object;
    [SerializeField]
    private GameObject Fire_Object;
    [SerializeField]
    private Transform X2_Transform;
    [SerializeField]
    private GameObject X2_Object;
    [SerializeField]
    private ImageAnimation Box_Animation;
    [SerializeField]
    private Transform LeftBox_Transform;
    [SerializeField]
    private Sprite X2_Sprite;
    [SerializeField]
    private Sprite Empty_Sprite;


    [SerializeField]
    private ScrollRect ChipScroller;

    int chipCounter = 0;

    private void Start()
    {
        if (MainBet_object) MainBet_object.SetActive(true);
        if (ChipBets_Object) ChipBets_Object.SetActive(true);
        if (Player_Object) Player_Object.SetActive(false);
        if (Dealer_Object) Dealer_Object.SetActive(false);

        if (MainBet_Button) MainBet_Button.onClick.RemoveAllListeners();
        if (MainBet_Button) MainBet_Button.onClick.AddListener(delegate { OnBet(true); });

        if (MultiplierBet_Button) MultiplierBet_Button.onClick.RemoveAllListeners();
        if (MultiplierBet_Button) MultiplierBet_Button.onClick.AddListener(delegate { OnBet(false); });

        if (Deal_Button) Deal_Button.onClick.RemoveAllListeners();
        if (Deal_Button) Deal_Button.onClick.AddListener(OnDeal);

        if (Hit_Button) Hit_Button.onClick.RemoveAllListeners();
        if (Hit_Button) Hit_Button.onClick.AddListener(delegate { OnHit(); });

        if (Stand_button) Stand_button.onClick.RemoveAllListeners();
        if (Stand_button) Stand_button.onClick.AddListener(OnStand);

        if (ClearBet_Button) ClearBet_Button.onClick.RemoveAllListeners();
        if (ClearBet_Button) ClearBet_Button.onClick.AddListener(OnClear);

        if (UndoBet_Button) UndoBet_Button.onClick.RemoveAllListeners();
        if (UndoBet_Button) UndoBet_Button.onClick.AddListener(OnUndo);

        if (Rebet_Button) Rebet_Button.onClick.RemoveAllListeners();
        if (Rebet_Button) Rebet_Button.onClick.AddListener(OnRebet);

        if (DoubleBet_Button) DoubleBet_Button.onClick.RemoveAllListeners();
        if (DoubleBet_Button) DoubleBet_Button.onClick.AddListener(OnInitialDouble);

        if (DoubleShow_Button) DoubleShow_Button.onClick.RemoveAllListeners();
        if (DoubleShow_Button) DoubleShow_Button.onClick.AddListener(OnDoubleAndStand);

        if (RebetDeal_Button) RebetDeal_Button.onClick.RemoveAllListeners();
        if (RebetDeal_Button) RebetDeal_Button.onClick.AddListener(OnRebetDeal);

        if (RebetDouble_Button) RebetDouble_Button.onClick.RemoveAllListeners();
        if (RebetDouble_Button) RebetDouble_Button.onClick.AddListener(OnRebetDouble);

        if (Split_Button) Split_Button.onClick.RemoveAllListeners();
        if (Split_Button) Split_Button.onClick.AddListener(OnSplit);

        if (Quit_Button) Quit_Button.onClick.RemoveAllListeners();
        if (Quit_Button) Quit_Button.onClick.AddListener(CallOnExitFunction);

        if (Split_object) Split_object.SetActive(false);
        if (MiddleDouble_object) MiddleDouble_object.SetActive(true);

        if (LeftArr_Button) LeftArr_Button.onClick.RemoveAllListeners();
        if (LeftArr_Button) LeftArr_Button.onClick.AddListener(delegate { OnChipScroll(true); });

        if (RightArr_Button) RightArr_Button.onClick.RemoveAllListeners();
        if (RightArr_Button) RightArr_Button.onClick.AddListener(delegate { OnChipScroll(false); });

        if (Chips_Object[0]) Chips_Object[0].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        if (Chips_Object[0]) Chips_Object[0].transform.SetParent(Selected_Transform);

        chipCounter = 0;
        if (RightArr_Button) RightArr_Button.interactable = false;
        if (ArrPointer_Object) ArrPointer_Object.SetActive(false);
        if (FirstArrPointer_Object) FirstArrPointer_Object.SetActive(false);
        if (SecondArrPointer_Object) SecondArrPointer_Object.SetActive(false);

    }

    private void OnChipScroll(bool direction)
    {
        if (direction)
        {
            if (RightArr_Button) RightArr_Button.interactable = true;
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.SetParent(ScrollParent_Transform);
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.localScale = Vector3.one;
            chipCounter++;
            if (ChipScroller) ChipScroller.horizontalNormalizedPosition += 0.2f;
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.SetParent(Selected_Transform);
            if (chipCounter == Chips_Object.Length - 1)
            {
                if (LeftArr_Button) LeftArr_Button.interactable = false;
            }
            OnSelectBet(chipCounter);
        }
        else
        {
            if (LeftArr_Button) LeftArr_Button.interactable = true;
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.SetParent(ScrollParent_Transform);
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.localScale = Vector3.one;
            chipCounter--;
            if (ChipScroller) ChipScroller.horizontalNormalizedPosition -= 0.2f;
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            if (Chips_Object[chipCounter]) Chips_Object[chipCounter].transform.SetParent(Selected_Transform);
            if (chipCounter == 0)
            {
                if (RightArr_Button) RightArr_Button.interactable = false;
            }
            OnSelectBet(chipCounter);
        }
    }

    private void CallOnExitFunction()
    {
        Application.ExternalCall("window.parent.postMessage", "onExit", "*");
    }

    private void OnBet(bool isnotMultiply)
    {
        if (InitialButtons_object) InitialButtons_object.SetActive(true);
        if(isnotMultiply)
        {
            BJmanager.BetOnButton();
        }
        else
        {
            BJmanager.MultiplyBetOnButton();
        }
    }

    private void OnSelectBet(int betCounter)
    {
        BJmanager.SelectCoin(betCounter);
    }

    private void OnDeal()
    {
        if (BetButton_Object) BetButton_Object.SetActive(false);
        if (ChipContainer_Object) ChipContainer_Object.SetActive(false);
        if (MultiplyBetButton_Object) MultiplyBetButton_Object.SetActive(false);
        StartCoroutine(OnStartDeal());
    }

    private void OnClear()
    {
        if (InitialButtons_object) InitialButtons_object.SetActive(false);
        BJmanager.ClearBetButton();
    }

    private void OnUndo()
    {
        BJmanager.UndoBetButton();
    }

    private void OnInitialDouble()
    {
        BJmanager.DoubleBetButton();
    }

    private void OnHit(bool isDouble = false)
    {
        if (Split_object) Split_object.SetActive(false);
        if (ArrPointer_Object) ArrPointer_Object.SetActive(false);
        StartCoroutine(HitDealButton(isDouble));
    }

    private void OnStand()
    {
        if (ArrPointer_Object) ArrPointer_Object.SetActive(false);
        StartCoroutine(DealerFinalButton());
    }

    private void OnDoubleAndStand()
    {
        if (ArrPointer_Object) ArrPointer_Object.SetActive(false);
        BJmanager.DoubleBetButton();
        OnHit(true);
    }

    private void OnRebet()
    {
        if (BetButton_Object) BetButton_Object.SetActive(true);
        if (ChipContainer_Object) ChipContainer_Object.SetActive(true);
        if (MultiplyBetButton_Object) MultiplyBetButton_Object.SetActive(true);
        if (MiddleDouble_object) MiddleDouble_object.SetActive(true);
        if (RebetButtons_object) RebetButtons_object.SetActive(false);
        BJmanager.RebetButton();
        if (MainBet_object) MainBet_object.SetActive(true);
        if (ChipBets_Object) ChipBets_Object.SetActive(true);
        if (Player_Object) Player_Object.SetActive(false);
        if (Dealer_Object) Dealer_Object.SetActive(false);
        if (InitialButtons_object) InitialButtons_object.SetActive(true);
    }

    private void OnRebetDeal()
    {
        if (BetButton_Object) BetButton_Object.SetActive(false);
        if (ChipContainer_Object) ChipContainer_Object.SetActive(false);
        if (MultiplyBetButton_Object) MultiplyBetButton_Object.SetActive(false);
        if (MiddleDouble_object) MiddleDouble_object.SetActive(true);
        if (RebetButtons_object) RebetButtons_object.SetActive(false);
        BJmanager.RebetDealButton();
        OnDeal();
    }

    private void OnRebetDouble()
    {
        if (BetButton_Object) BetButton_Object.SetActive(false);
        if (ChipContainer_Object) ChipContainer_Object.SetActive(false);
        if (MultiplyBetButton_Object) MultiplyBetButton_Object.SetActive(false);
        if (MiddleDouble_object) MiddleDouble_object.SetActive(true);
        BJmanager.DoubleBetButton();
        if (RebetButtons_object) RebetButtons_object.SetActive(false);
        BJmanager.RebetDealButton();
        OnDeal();
    }

    private void OnSplit()
    {
        if (MiddleButtons_object) MiddleButtons_object.SetActive(false);
        StartCoroutine(OnSplitDeal());
    }

    private IEnumerator OnSplitDeal()
    {
        if (MiddleDouble_object) MiddleDouble_object.SetActive(false);
        if (Split_object) Split_object.SetActive(false);
        BJmanager.SplitButton();
        yield return new WaitUntil(() => BJmanager.isSplit);
        if (MiddleButtons_object) MiddleButtons_object.SetActive(true);
    }

    private IEnumerator OnStartDeal()
    {
        if (MainBet_object) MainBet_object.SetActive(false);
        if (ChipBets_Object) ChipBets_Object.SetActive(false);
        if (Player_Object) Player_Object.SetActive(true);
        if (Dealer_Object) Dealer_Object.SetActive(true);
        if (InitialButtons_object) InitialButtons_object.SetActive(false);
        BJmanager.isFlippin = true;
        BJmanager.OnPlayerDealButton();
        yield return new WaitUntil(() => !BJmanager.isFlippin);
        BJmanager.isFlippin = true;
        BJmanager.OnDealerButton();
        yield return new WaitUntil(() => !BJmanager.isFlippin);
        BJmanager.isFlippin = true;
        BJmanager.OnPlayerDealButton();
        yield return new WaitUntil(() => !BJmanager.isFlippin);
        BJmanager.isFlippin = true;
        BJmanager.OnDealerButtonClosedCard();
        if(BJmanager.CheckMultiplier())
        {
            yield return DragonRoutine();
            if (LeftBox_Transform) LeftBox_Transform.GetChild(LeftBox_Transform.childCount - 1).SetAsFirstSibling();
            if (LeftBox_Transform) LeftBox_Transform.GetChild(0).GetComponent<Image>().sprite = X2_Sprite;
        }
        else
        {
            if (LeftBox_Transform) LeftBox_Transform.GetChild(LeftBox_Transform.childCount - 1).SetAsFirstSibling();
            if (LeftBox_Transform) LeftBox_Transform.GetChild(0).GetComponent<Image>().sprite = Empty_Sprite;
        }
        if (ArrPointer_Object) ArrPointer_Object.SetActive(true);
        if (MiddleButtons_object) MiddleButtons_object.SetActive(true);
        if (BJmanager.playerData[0] == BJmanager.playerData[1])
        {
            if (Split_object) Split_object.SetActive(true);
        }

    }

    private IEnumerator DragonRoutine()
    {
        if (DragonFire_Object) DragonFire_Object.SetActive(true);
        if (Fire_Object) Fire_Object.SetActive(true);
        if (DragonNormal_Object) DragonNormal_Object.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        if (X2_Transform) X2_Transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        if (X2_Transform) X2_Transform.localPosition = new Vector2(200, -90);
        if (X2_Object) X2_Object.SetActive(true);
        if (X2_Transform) X2_Transform.DOLocalMove(new Vector2(400, 225), 1f);
        if (X2_Transform) X2_Transform.DOScale(Vector3.one, 1f);
        if (Box_Animation) Box_Animation.StartAnimation();
        yield return new WaitForSeconds(0.5f);
        if (DragonFire_Object) DragonFire_Object.SetActive(false);
        if (Fire_Object) Fire_Object.SetActive(false);
        if (DragonNormal_Object) DragonNormal_Object.SetActive(true);
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator HitDealButton(bool isDouble)
    {
        if (!BJmanager.isSplit)
        {
            if (MiddleButtons_object) MiddleButtons_object.SetActive(false);
            BJmanager.isFlippin = true;
            BJmanager.OnPlayerDealButton();
            yield return new WaitUntil(() => !BJmanager.isFlippin);
            if (isDouble)
            {
                OnStand();
            }
            else
            {
                if (ArrPointer_Object) ArrPointer_Object.SetActive(true);
                if (MiddleButtons_object) MiddleButtons_object.SetActive(true);
            }
        }
        else
        {
            if (MiddleButtons_object) MiddleButtons_object.SetActive(false);
            BJmanager.isFlippin = true;
            BJmanager.OnSplitDealButton();
            yield return new WaitUntil(() => !BJmanager.isFlippin);
            if (MiddleButtons_object) MiddleButtons_object.SetActive(true);
        }
    }

    private IEnumerator DealerFinalButton()
    {
        if (!BJmanager.isSplit)
        {
            if (MiddleButtons_object) MiddleButtons_object.SetActive(false);
            BJmanager.isFlippin = true;
            BJmanager.OnDealerButtonOpen();
            yield return new WaitUntil(() => !BJmanager.isFlippin);
            for (int i = 0; i < BJmanager.dealerData.Count - 2; i++)
            {
                BJmanager.isFlippin = true;
                BJmanager.OnDealerButton();
                yield return new WaitUntil(() => !BJmanager.isFlippin);
            }
            if (RebetButtons_object) RebetButtons_object.SetActive(true);
        }
        else if(BJmanager.isFirstSplit)
        {
            if (MiddleButtons_object) MiddleButtons_object.SetActive(false);
            BJmanager.SplitStandButton();
            yield return new WaitUntil(() => !BJmanager.isFirstSplit);
            if (MiddleButtons_object) MiddleButtons_object.SetActive(true);
        }
        else
        {
            if (MiddleButtons_object) MiddleButtons_object.SetActive(false);
            BJmanager.isFlippin = true;
            BJmanager.OnDealerButtonOpen();
            yield return new WaitUntil(() => !BJmanager.isFlippin);
            for (int i = 0; i < BJmanager.dealerData.Count - 2; i++)
            {
                BJmanager.isFlippin = true;
                BJmanager.OnDealerButton();
                yield return new WaitUntil(() => !BJmanager.isFlippin);
            }
            if (RebetButtons_object) RebetButtons_object.SetActive(true);
        }
    }
}

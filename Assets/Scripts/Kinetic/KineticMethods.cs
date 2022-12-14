using System;
using Kinetic.Sdk;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Rpc.Types;
using TMPro;
using UnityEngine;

public class KineticMethods : MonoBehaviour
{

    // public GameObject T
    // private void OnEnable()
    // {
    //     // if (GameController.Keypair != null)
    //     // {
    //     //     txtPublicKey.text = GameController.Keypair.PublicKey;
    //     // }
    //     CreateKeypair();
    //     // UpdateBalance();
    //     // GetTokenAccounts();
    // }

    public void CreateKeypair()
    {
        System.Diagnostics.Debug.WriteLine("Create Keypair!!!!!!!!!");
        Keypair Keypair = Keypair.Random();
        System.Diagnostics.Debug.WriteLine(Keypair);
        // UnityEngine.Logger.Log(Keypair);
        // Debug.Log("Keypair", Keypair.PublicKey);
        // Debug.Log(Platformer.Mechanics.GameController.Keypair.PublicKey);
        // Platformer.Mechanics.GameController.Keypair.set(keypair);
    }
    // public async void CreateAccount()
    // {
    //     Keypair = GameController.Keypair
    //     Transaction = await KineticSdk.CreateAccount(Keypair, commitment: Commitment.Finalized);

    // }

    // public async void UpdateBalance()
    // {
    //     if (GameController.Keypair == null) return;
    //     var balance = await GameController.KineticSdk.GetBalance(account: GameController.Keypair.PublicKey);
    //     txtBalance.gameObject.transform.parent.gameObject.SetActive(true);
    //     txtBalance.text = (balance.Balance ?? "0.00") + " KIN";
    // }

    // public async void GetTokenAccounts()
    // {
    //     if (GameController.Keypair == null) return;
    //     var accounts = await GameController.KineticSdk.GetTokenAccounts(account: GameController.Keypair.PublicKey);
    //     if (accounts.Count == 0) return;
    //     tokenAccountsDropDown.gameObject.SetActive(true);
    //     txtTokenAccountDesc.gameObject.SetActive(true);
    //     tokenAccountsDropDown.options.Clear();
    //     foreach (var acc in accounts)
    //     {
    //         tokenAccountsDropDown.options.Add(new TMP_Dropdown.OptionData(acc));
    //     }
    // }

    // public async void GetHistory()
    // {
    //     if (GameController.Keypair == null) return;
    //     var history = await GameController.KineticSdk.GetHistory(account: GameController.Keypair.PublicKey);
    //     txtHistory.text = "";
    //     foreach (var h in history)
    //     {
    //         txtHistory.text += h.ToJson();
    //     }
    // }

    // public async void RequestAirdrop()
    // {
    //     if (GameController.Keypair == null) return;
    //     loading.SetActive(true);
    //     try
    //     {
    //         await GameController.KineticSdk.RequestAirdrop(
    //             account: GameController.Keypair.PublicKey,
    //             amount: "1000"
    //         );
    //         UpdateBalance();
    //     }
    //     catch (Exception e)
    //     {

    //         Debug.LogException(e);
    //     }

    //     loading.SetActive(false);
    // }

    // public async void MakeTransfer()
    // {
    //     if (GameController.Keypair == null) return;
    //     loading.SetActive(true);
    //     try
    //     {
    //         await GameController.KineticSdk.MakeTransfer(
    //             amount: txtAmount.text,
    //             destination: txtDestination.text,
    //             owner: GameController.Keypair,
    //             commitment: Commitment.Finalized,
    //             senderCreate: true
    //         );
    //         txtDestination.transform.parent.parent.gameObject.SetActive(false);
    //         UpdateBalance();
    //     }
    //     catch (Exception e)
    //     {

    //         txtDestination.text = " - Invalid destination - ";
    //         Debug.LogException(e);
    //     }
    //     loading.SetActive(false);

    // }

}

using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Kinetic.Sdk;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Rpc.Types;
using TMPro;


namespace Platformer.Mechanics
{
    public class MakeTransferZone : MonoBehaviour
    {
        public TextMeshPro TxtMakeTransfer;

        void OnTriggerEnter2D(Collider2D collider)
        {
            MakeTransfer();
        }

        public async void MakeTransfer()
        {
            Debug.Log("MakeTransfer!!!!!!!!!!!");
            TxtMakeTransfer.text = "Please wait! Sending your Kin...";

            Keypair UserKeypair = Platformer.Mechanics.GameController.UserKeypair;
            KineticSdk Kinetic = Platformer.Mechanics.GameController.Kinetic;

            var balance = await Kinetic.GetBalance(account: UserKeypair.PublicKey);

            var transaction = await Kinetic.MakeTransfer(
                owner: UserKeypair,
                amount: balance.Balance,
                destination: "BfnSoyTz5kaL9besXC85RUWqhnFg7pRpBa4haNiG8K1n",
                type: TransactionType.Spend,
                commitment: Commitment.Finalized
            );
            Debug.Log("Signature!");
            Debug.Log(transaction.Signature);
            Debug.Log(transaction);

            TxtMakeTransfer.text = "Done! Now lets send your Kin to an outside address...";
            var explorerUrl = $"https://explorer.solana.com/tx/{transaction.Signature}?cluster=devnet";
            Application.OpenURL(explorerUrl);

        }
    }
}
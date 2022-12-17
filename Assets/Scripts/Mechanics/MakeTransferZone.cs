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

            Keypair Keypair = Platformer.Mechanics.GameController.Keypair;
            KineticSdk KineticSdk = Platformer.Mechanics.GameController.KineticSdk;

            var balance = await KineticSdk.GetBalance(account: Keypair.PublicKey);

            var transaction = await KineticSdk.MakeTransfer(
                owner: Keypair,
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
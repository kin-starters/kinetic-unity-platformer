using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using Kinetic.Sdk;
using Kinetic.Sdk.Interfaces;
using Solana.Unity.Rpc.Types;

namespace Platformer.Mechanics
{
    public class MakeTransferZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            MakeTransfer();
        }

        public async void MakeTransfer()
        {
            Debug.Log("MakeTransfer!!!!!!!!!!!");
            Keypair Keypair = Platformer.Mechanics.GameController.Keypair;
            KineticSdk KineticSdk = Platformer.Mechanics.GameController.KineticSdk;

            var balance = await KineticSdk.GetBalance(account: Keypair.PublicKey);

            var transaction = await KineticSdk.MakeTransfer(
                owner: Keypair,
                amount: balance.Balance,
                destination: "BfnSoyTz5kaL9besXC85RUWqhnFg7pRpBa4haNiG8K1n",
                type: TransactionType.Spend,
                commitment: Commitment.Confirmed
            );
            Debug.Log("Signature!");
            Debug.Log(transaction.Signature);
            Debug.Log(transaction);
        }
    }
}
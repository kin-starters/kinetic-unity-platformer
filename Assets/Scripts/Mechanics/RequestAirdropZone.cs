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
    public class RequestAirdropZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            RequestAirdrop();
        }

        public async void RequestAirdrop()
        {
            Debug.Log("RequestAirdrop!!!!!!!!!!!");
            Keypair Keypair = Platformer.Mechanics.GameController.Keypair;
            KineticSdk KineticSdk = Platformer.Mechanics.GameController.KineticSdk;
            var transaction = await KineticSdk.RequestAirdrop(account: Keypair.PublicKey, amount: "1000", commitment: Commitment.Confirmed);
            Debug.Log("Signature!");
            Debug.Log(transaction.Signature);
            Debug.Log(transaction);
        }
    }
}
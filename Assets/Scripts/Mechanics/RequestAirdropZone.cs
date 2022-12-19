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
    public class RequestAirdropZone : MonoBehaviour
    {
        public TextMeshPro TxtRequestAirdrop;

        void OnTriggerEnter2D(Collider2D collider)
        {
            RequestAirdrop();
        }

        public async void RequestAirdrop()
        {
            Debug.Log("RequestAirdrop!!!!!!!!!!!");
            TxtRequestAirdrop.text = "Please wait! Airdropping you some Kin...";

            Keypair UserKeypair = Platformer.Mechanics.GameController.UserKeypair;
            KineticSdk Kinetic = Platformer.Mechanics.GameController.Kinetic;
            var transaction = await Kinetic.RequestAirdrop(account: UserKeypair.PublicKey, amount: "1000", commitment: Commitment.Finalized);
            Debug.Log("Signature!");
            Debug.Log(transaction.Signature);
            Debug.Log(transaction);

            TxtRequestAirdrop.text = "Done! Why not check your balance again...";
            var explorerUrl = $"https://explorer.solana.com/tx/{transaction.Signature}?cluster=devnet";
            Application.OpenURL(explorerUrl);
        }
    }
}
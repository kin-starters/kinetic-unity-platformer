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
    public class CreateAccountZone : MonoBehaviour
    {

        public TextMeshPro TxtAccountSignature;

        void OnTriggerEnter2D(Collider2D collider)
        {
            CreateAccount();
        }

        public async void CreateAccount()
        {
            Debug.Log("CreateAccount!!!!!!!!!!!");

            TxtAccountSignature.text = "Please wait! Creating your account on the blockchain...";
            Keypair UserKeypair = Platformer.Mechanics.GameController.UserKeypair;
            KineticSdk Kinetic = Platformer.Mechanics.GameController.Kinetic;

            if (Kinetic == null) Debug.Log("No Kinetic SDK!!!!");

            var transaction = await Kinetic.CreateAccount(owner: UserKeypair, commitment: Commitment.Finalized);
            Debug.Log("Signature!");
            Debug.Log(transaction.Signature);
            Debug.Log(transaction);
            TxtAccountSignature.text = "Done! Your account is now ready on the Solana blockchain! Now let's get some Kin...";
            var explorerUrl = $"https://explorer.solana.com/tx/{transaction.Signature}?cluster=devnet";
            Application.OpenURL(explorerUrl);

        }
    }
}
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
    public class CreateAccountZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            CreateAccount();
        }

        public async void CreateAccount()
        {
            Debug.Log("CreateAccount!!!!!!!!!!!");
            Keypair Keypair = Platformer.Mechanics.GameController.Keypair;
            KineticSdk KineticSdk = Platformer.Mechanics.GameController.KineticSdk;
            var transaction = await KineticSdk.CreateAccount(Keypair, commitment: Commitment.Confirmed);
            Debug.Log("Signature!");
            Debug.Log(transaction.Signature);
            Debug.Log(transaction);
        }
    }
}
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
    public class CloseAccountZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            CloseAccount();
        }

        public async void CloseAccount()
        {
            Debug.Log("CloseAccount!!!!!!!!!!!");
            Keypair Keypair = Platformer.Mechanics.GameController.Keypair;
            KineticSdk KineticSdk = Platformer.Mechanics.GameController.KineticSdk;
            // var transaction = await KineticSdk.CloseAccount(Keypair.PublicKey);
            // Debug.Log("Signature!");
            // Debug.Log(transaction.Signature);
            // Debug.Log(transaction);
        }
    }
}
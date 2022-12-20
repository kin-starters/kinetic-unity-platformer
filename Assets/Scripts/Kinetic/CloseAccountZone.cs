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


namespace Platformer.Kinetic
{
    public class CloseAccountZone : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            CloseAccount();
        }

        public void CloseAccount()
        {
            Debug.Log("CloseAccount!!!!!!!!!!!");
            Keypair UserKeypair = Platformer.Mechanics.GameController.UserKeypair;
            Debug.Log(UserKeypair.ToString());
            KineticSdk Kinetic = Platformer.Mechanics.GameController.Kinetic;
            Debug.Log(Kinetic.ToString());
            // var transaction = await KineticSdk.CloseAccount(Keypair.PublicKey);
            // Debug.Log("Signature!");
            // Debug.Log(transaction.Signature);
            // Debug.Log(transaction);
        }
    }
}
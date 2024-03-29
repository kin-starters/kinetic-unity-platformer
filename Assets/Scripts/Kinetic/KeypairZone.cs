﻿using System;
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
    public class KeypairZone : MonoBehaviour
    {
        public TextMeshPro TxtPublicKey;

        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("Create Keypair!!!!!!!!!!!");
            Keypair UserKeypair = Keypair.Random();
            Debug.Log(UserKeypair.PublicKey);
            Debug.Log(UserKeypair.Mnemonic);
            Platformer.Mechanics.GameController.UserKeypair = UserKeypair;
            TxtPublicKey.text = UserKeypair.PublicKey;
        }
    }
}
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
    public class CreateAccountZone : MonoBehaviour
    {

        public TextMeshPro TxtKinetic;
        public TextMeshPro TxtAccountSignature;

        void OnTriggerEnter2D(Collider2D collider)
        {
            CreateAccount();
        }

        public async void CreateAccount()
        {
            Debug.Log("CreateAccount!!!!!!!!!!!");

            Keypair UserKeypair = Platformer.Mechanics.GameController.UserKeypair;
            KineticSdk Kinetic = Platformer.Mechanics.GameController.Kinetic;
            // KineticSdk Kinetic = Kinetic = await KineticSdk.Setup(
            //         new KineticSdkConfig(
            //             // index: 407,
            //             index: 1,
            //             // endpoint: "https://sandbox.kinetic.host",
            //             endpoint: "https://my-kinetic.onrender.com",
            //             environment: "devnet",
            //             logger: new Logger(Debug.unityLogger.logHandler)
            //         )
            //     );

            // TxtKinetic.text = "Connected to Kinetic!";
            // Platformer.Mechanics.GameController.Kinetic = Kinetic;

            if (Kinetic == null)
            {
                TxtKinetic.text = "Can't connect to Kinetic!";
                Debug.Log("No Kinetic SDK!!!!");
            }

            if (Kinetic != null)
            {
                TxtAccountSignature.text = "Please wait! Creating your account on the blockchain...";
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
}
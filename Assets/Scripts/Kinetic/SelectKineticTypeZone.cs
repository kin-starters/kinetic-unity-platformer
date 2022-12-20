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
using UnityEngine.Networking;

namespace Platformer.Kinetic
{
    public class SelectKineticTypeZone : MonoBehaviour
    {

        public TextMeshPro TxtKineticType;

        void Awake()
        {
            TxtKineticType.text = Platformer.Mechanics.GameController.KineticType;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            SelectKineticType();
        }

        public void SelectKineticType()
        {
            Debug.Log("SelectKineticType!!!!!!!!!!!!!!");


            if (Platformer.Mechanics.GameController.KineticType == "client")
            {
                Platformer.Mechanics.GameController.KineticType = "server";
                ConnecToKineticServer();
            }
            else
            {
                Platformer.Mechanics.GameController.KineticType = "client";
            }

            TxtKineticType.text = Platformer.Mechanics.GameController.KineticType;
        }

        async void ConnecToKineticServer()
        {
            Debug.Log(Platformer.Mechanics.GameController.index);

            string URL = "https://richardmandskin.loca.lt/status";


            void GenerateRequest()
            {
                StartCoroutine(ProcessRequest(URL));
            }

            IEnumerator ProcessRequest(string uri)
            {
                using (UnityWebRequest request = UnityWebRequest.Get(uri))
                {
                    yield return request.SendWebRequest();

                    if (request.isNetworkError)
                    {
                        Debug.Log(request.error);
                    }
                    else
                    {
                        Debug.Log(request.downloadHandler.text);
                        TxtKineticType.text = request.downloadHandler.text;
                    }
                }
            }

            GenerateRequest();
        }
    }
}
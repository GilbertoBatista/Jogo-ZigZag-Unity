﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CriaChao : MonoBehaviour {

	[SerializeField]
	private GameObject chao,moeda;
	[SerializeField]
	private float tamanhoXZ;
	[SerializeField]
	private Vector3 posUltima;

	[SerializeField]
	private int limiteChao;
	public static int chaoNumCena;


	void Start()
	{
		posUltima = chao.transform.position;
		tamanhoXZ = chao.transform.localScale.x;
		chaoNumCena = 0;
		StartCoroutine ("CriaChaoInGame");
	}
	
	// Update is called once per frame
	void Update () {


	}

	void CriaX()
	{
		Vector3 tempPos = posUltima;
		tempPos.x += tamanhoXZ;
		posUltima = tempPos;

		Instantiate (chao,tempPos,Quaternion.identity);

		int rand = Random.Range (0,5);

		if(rand <= 1)
		{
			Instantiate (moeda, new Vector3 (tempPos.x, tempPos.y + 0.2f, tempPos.z), moeda.transform.rotation);
		}

	}

	void CriaZ()
	{
		Vector3 tempPos = posUltima;
		tempPos.z += tamanhoXZ;
		posUltima = tempPos;
		Instantiate (chao,tempPos,Quaternion.identity);

		int rand = Random.Range (0,5);

		if(rand <= 1)
		{
			Instantiate (moeda, new Vector3 (tempPos.x, tempPos.y + 0.2f, tempPos.z), moeda.transform.rotation);
		}
	}

	void CriaChaoXZ()
	{
		int temp = Random.Range (0, 10);

		if(chaoNumCena < limiteChao)
		{
			if(temp < 5)
			{
				CriaX ();
				chaoNumCena++;
				
			}
			else if(temp >= 5)
			{
				CriaZ ();
				chaoNumCena++;
			}
		}



	}

	IEnumerator CriaChaoInGame()
	{
		
			while (BolaControlador.gameOver != true) {
				yield return new WaitForSeconds (0.2f);
				CriaChaoXZ ();
			}

	}




}

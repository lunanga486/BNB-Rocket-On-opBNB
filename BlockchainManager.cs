using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using MetaMask.SocketIOClient;

public class BlockchainManager : MonoBehaviour
{
    public string Address { get; private set; }

    public Button playBtn;
    public Text PlayBtnText;
    public Button nftBtn;
    public Text NFTBtnText;
    public Button rocketBtn;
    public Text rocketBtnText;


    private void Start()
    {
        playBtn.gameObject.SetActive(false);
        nftBtn.gameObject.SetActive(false);
        rocketBtn.gameObject.SetActive(false);
        rocketImage.sprite = sprite1;
    }

    public async void HaveGamePass()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        //For Testing
        Address = "0x4C6F5f4e21840f1e103fF8791AC70b4Ff1AD59f9";
        var contract = ThirdwebManager.Instance.SDK.GetContract(
            "0xafbB19d38e76548BaDb2a8D3b3a2560D56e30341",
            //ABI from Thirdweb
            "[{\"type\":\"event\",\"name\":\"gamePassGiven\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"goldClaimed\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"claimGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"getGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"giveGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"
            );
        //Function in smart contract Thirdweb
        bool ishavePass = await contract.Read<bool>("hasGamePass", Address);

        if (ishavePass == true)
        {
            playBtn.gameObject.SetActive(true);
            rocketBtn.gameObject.SetActive(true);
            nftBtn.gameObject.SetActive(false);
        }
        else
        {
            playBtn.gameObject.SetActive(false);
            rocketBtn.gameObject.SetActive(false);
            nftBtn.gameObject.SetActive(true);
        }
    }

    public async void ClaimGamePass()
    {
        Debug.Log("ClaimGamePass");
        nftBtn.interactable = false;
        NFTBtnText.text = "Getting Key!";

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
             "0xafbB19d38e76548BaDb2a8D3b3a2560D56e30341",
            //ABI from Thirdweb
            "[{\"type\":\"event\",\"name\":\"gamePassGiven\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"goldClaimed\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"claimGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"getGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"giveGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"
            );

        await contract.Write("claimGamePass", Address);
        nftBtn.interactable = true;
        NFTBtnText.text = "Claim Key";
        playBtn.gameObject.SetActive(true);
        rocketBtn.gameObject.SetActive(true);
        nftBtn.gameObject.SetActive(false);
    }

    public async void PlayGame()
    {
        Debug.Log("PlayGame");
        playBtn.interactable = false;
        rocketBtn.interactable = false;
        PlayBtnText.text = "Get Ready!";

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
             "0xafbB19d38e76548BaDb2a8D3b3a2560D56e30341",
            //ABI from Thirdweb
            "[{\"type\":\"event\",\"name\":\"gamePassGiven\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"goldClaimed\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"claimGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"getGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"giveGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"
            );

        await contract.Write("giveGold", Address);

        playBtn.interactable = true;
        rocketBtn.interactable = true;
        PlayBtnText.text = "Play";

        SceneManager.LoadScene("GameScene");
    }

    public async void ChooseRocket()
    {
        Debug.Log("ChooseRocket");
        playBtn.interactable = false;
        rocketBtn.interactable = false;
        rocketBtnText.text = "Choosing!";

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
             "0xafbB19d38e76548BaDb2a8D3b3a2560D56e30341",
            //ABI from Thirdweb
            "[{\"type\":\"event\",\"name\":\"gamePassGiven\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"event\",\"name\":\"goldClaimed\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"indexed\":true,\"internalType\":\"address\"},{\"type\":\"uint256\",\"name\":\"newCount\",\"indexed\":false,\"internalType\":\"uint256\"}],\"outputs\":[],\"anonymous\":false},{\"type\":\"function\",\"name\":\"claimGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"getGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"uint256\",\"name\":\"\",\"internalType\":\"uint256\"}],\"stateMutability\":\"view\"},{\"type\":\"function\",\"name\":\"giveGold\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[],\"stateMutability\":\"nonpayable\"},{\"type\":\"function\",\"name\":\"hasGamePass\",\"inputs\":[{\"type\":\"address\",\"name\":\"player\",\"internalType\":\"address\"}],\"outputs\":[{\"type\":\"bool\",\"name\":\"\",\"internalType\":\"bool\"}],\"stateMutability\":\"view\"}]"
            );

        await contract.Write("giveGold", Address);

        StartCoroutine(Countdown());        
    }
    public SpriteRenderer rocketImage;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    IEnumerator Countdown()
    {
        // Countdown from 3 to 1
        for (int i = 3; i > 0; i--)
        {
            rocketBtnText.text = i.ToString(); // Update the Text UI
            yield return new WaitForSeconds(1f); // Wait for 1 second before continuing the countdown
        }

        int randomNumber = Random.Range(1, 4);
        switch (randomNumber)
        {
            case 1:
                Debug.Log("1");
                RocketChosen.Instance.SetChosenRocket(1);
                rocketBtnText.text = "BNB Wolf";
                rocketImage.sprite = sprite1;
                break;
            case 2:
                RocketChosen.Instance.SetChosenRocket(2);
                rocketBtnText.text = "BNB Lion";
                rocketImage.sprite = sprite2;
                break;
            case 3:
                RocketChosen.Instance.SetChosenRocket(3);
                rocketBtnText.text = "BNB Dragon";
                rocketImage.sprite = sprite3;
                break;
        }
        playBtn.interactable = true;
    }
}

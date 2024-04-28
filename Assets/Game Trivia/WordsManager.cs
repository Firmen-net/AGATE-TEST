using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    public TextAsset kbbiWordList; // File teks yang berisi daftar kata-kata KBBI

    //private List<string> wordList = new List<string>(); // List untuk menyimpan kata-kata KBBI
    private string[] wordList = new string[112651]; // List untuk menyimpan kata-kata KBBI

    public int JumlahHuruf;
    public char HurufAwal;
    public int TotalKata;

    private void Start()
    {
        LoadKBBIWords();
        foreach (var x in SelectWords(JumlahHuruf + 1, HurufAwal, TotalKata))
        {
            Debug.Log(x.ToString());
        }
    }

    // Fungsi untuk memuat kata-kata dari file teks ke dalam list
    private void LoadKBBIWords()
    {
        if (kbbiWordList != null)
        {
            string[] words = kbbiWordList.text.Split('\n');

            for (int i = 0; i < wordList.Length; i++)
            {
                wordList[i] = words[i];
            }
        }
    }

    // Fungsi untuk memilih kata-kata sesuai aturan level
    private List<string> SelectWords(int length, char startsWith, int count)
    {
        List<string> selectedWords = new List<string>();
        foreach (string word in wordList)
        {
            if (word.Length == length && word[0] == startsWith)
            {
                selectedWords.Add(word);
            }
        }
        return selectedWords.GetRange(0, count);
    }
}
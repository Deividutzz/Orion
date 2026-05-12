using Orion.main.domain.service;
using System;

namespace Orion.main.domain.service;

public class ErrorsChecker
{
    private string result = "";

    public bool Verify(string message, string key1, string key2, string encryptedMessage, long[]  converted)
    {
        bool error = false;
        int errorType = 0;
        
        if (Empty(message) || Empty(key1) || Empty(key2))
        {
            error = true;
            errorType = 1;
        }

        if (InvalidChars(message, key1, key2))
        {
            error = true;
            errorType = 2;
        }
        
        if (InvalidEncryption(message, encryptedMessage,converted))
        {
            error = true;
            errorType = 3;
        }
        
        SetOutput(errorType);
        return error;
    }

    public string GetOutput()
    {
        return result;
    }

    private void SetOutput(int errorType)
    {
        switch (errorType)
        {
            case 0:
                result = "Succesfully encrypted your message: ";
                break;
            case 1:
                result = "Enter the required details.";
                break;
            case 2:
                result = "Please use only alphanumeric characters.";
                break;
            case 3:
                result = "The encrypted message is invalid. Please try a different key.";
                break;
        }
    }
    
    private static bool Empty(string message)
    {
        return message == "";
        
        /// returneaza true daca mesajul este gol
        /// false daca nu este gol
    }

    private static bool InvalidChars(string mes, string key1, string key2)
    {
        string key = key1 + key2;
        
        char[] prop = mes.ToCharArray();
        char[] cheie = key.ToCharArray();
        
        for (int i = 0; i < prop.Length; i++)
        {
            if( (prop[i] < 'a' || prop[i] > 'z') 
                &&  (prop[i] < 'A' || prop[i] > 'Z') && prop[i] != ' ')
            {
                //invalid
                return true;
            }
        }

        for (int i = 0; i < cheie.Length; i++)
        {
            if(cheie[i] < '0' || cheie[i] > '9')
                return true;
            //invalid
        }
        
        return false;
    }

    private static bool InvalidEncryption(string mes, string encryptedMessage, long []  converted)
    {
        for (int i = 0; i < encryptedMessage.Length - 1; i++)
        {
            if(mes[i] != mes[i + 1] &&  encryptedMessage[i] == encryptedMessage[i + 1])
                return true;
        }

        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                if(converted[i] == converted[j] && i != j && converted[j] != 0)
                    return true;
            }
        }

        return false;
    }
}
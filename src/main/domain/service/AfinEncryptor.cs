using Orion.main.domain.model;

namespace Orion.main.domain.service;

public class AfinEncryptor
{
    private EncryptData data;
    //private const long MAX_LENGTH = 1073741824;

    public AfinEncryptor(EncryptData data)
    {
        this.data = data;
    }
    public string Encryption()
    {
        return Encrypt();
    }

    private string Encrypt()
    {
        long[] converted = new long[100];
        for (int i = 0; i < 100; i++)
            converted[i] = 0;
    
        string mes = data.getMessage();
        long firstKey = data.getKey1();
        long secndKey = data.getKey2();
        
        char [] prop = mes.ToCharArray();
        string result = "";
        for (int i = 0; i < prop.Length; i++)
        {
            int code = -1;
            if(Lowercase(prop[i]))
                code = prop[i] - 'a';
            else if(Uppercase(prop[i]))
                code = prop[i] - 'A';

            long encr = code * firstKey + secndKey;
            encr %= 26;
            char ch = ' ';
            if (Lowercase(prop[i]))
                ch = (char) (encr + 'a');
            else if (Uppercase(prop[i]))
                ch = (char) (encr + 'A');
            result += ch;
            if (code != -1)
                converted[code] = encr;
        }
        data.setConverted(converted);
        return result;
    }

    private static bool Lowercase(char ch)
    {
        if (ch >= 'a' && ch <= 'z')
            return true;
        return false;
    }

    private static bool Uppercase(char ch)
    {
        if (ch >= 'A' && ch <= 'Z')
            return true;
        return false;
    }
}
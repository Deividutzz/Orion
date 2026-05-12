namespace Orion.main.domain.model;
public class EncryptData
{
    private string message;
    private long key1;
    private long key2;
    private long[] converted;
    public EncryptData(string mes,long key1,long key2)
    {
        message = mes;
        this.key1 = key1;
        this.key2 = key2;
    }
    public string getMessage()
    {
        return message;
    }

    public long getKey1()
    {
        return key1;
    }

    public long getKey2()
    {
        return key2;
    }
    
    public void setConverted(long[] data)
    {
        converted = data;
    }

    public long[] getConverted()
    {
        return converted;
    }
}
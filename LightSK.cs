using System;

class LightSK
{
    private string key;

    // 构造函数，接受密钥作为参数
    public LightSK(string key)
    {
        this.key = key;
    }

    // 加密函数
    public string Encrypt(string message)
    {
        var encryptedBlocks = "";
        var key = this.key;

        // 将消息分割成固定长度的块
        for (int i = 0; i < message.Length; i += 8)
        {
            var block = message.Substring(i, Math.Min(8, message.Length - i));

            // 对每个块进行加密，使用轻量级异或运算
            var encryptedBlock = "";
            for (int j = 0; j < block.Length; j++)
            {
                encryptedBlock += (char)(block[j] ^ key[j % key.Length]);
            }
            encryptedBlocks += encryptedBlock;

            // 更新密钥
            key = UpdateKey(key, block);
        }

        // 返回加密后的结果
        return encryptedBlocks;
    }

    // 解密函数
    public string Decrypt(string encryptedMessage)
    {
        var decryptedBlocks = "";
        var key = this.key;

        // 将密文分割成固定长度的块
        for (int i = 0; i < encryptedMessage.Length; i += 8)
        {
            var block = encryptedMessage.Substring(i, Math.Min(8, encryptedMessage.Length - i));

            // 对每个块进行解密，使用相同的轻量级异或运算
            var decryptedBlock = "";
            for (int j = 0; j < block.Length; j++)
            {
                decryptedBlock += (char)(block[j] ^ key[j % key.Length]);
            }
            decryptedBlocks += decryptedBlock;

            // 更新密钥
            key = UpdateKey(key, decryptedBlock);
        }

        // 返回解密后的结果
        return decryptedBlocks;
    }

    // 密钥更新函数
    private string UpdateKey(string key, string block)
    {
        // 这里可以根据具体需求设计密钥更新逻辑，这里简单地将密钥与块进行异或运算
        var updatedKey = "";
        for (int i = 0; i < key.Length; i++)
        {
            updatedKey += (char)(key[i] ^ block[i % block.Length]);
        }
        return updatedKey;
    }
}
/*
// 调用示例
LightSK sk = new LightSK("secretKey");
string encryptedMessage = sk.Encrypt("Hello World");
Console.WriteLine("Encrypted Message: " + encryptedMessage);
string decryptedMessage = sk.Decrypt(encryptedMessage);
Console.WriteLine("Decrypted Message: " + decryptedMessage);
*/

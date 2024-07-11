class LightSK:
    def __init__(self, key):
        self.key = key

    def encrypt(self, message):
        encrypted_blocks = []
        key = self.key

        blocks = [message[i:i+8] for i in range(0, len(message), 8)]

        for block in blocks:
            encrypted_block = ''
            for i in range(len(block)):
                encrypted_block += chr(ord(block[i]) ^ ord(key[i % len(key)])
            encrypted_blocks.append(encrypted_block)

            key = self.update_key(key, block)

        return ''.join(encrypted_blocks)

    def decrypt(self, encrypted_message):
        decrypted_blocks = []
        key = self.key

        blocks = [encrypted_message[i:i+8] for i in range(0, len(encrypted_message), 8)]

        for block in blocks:
            decrypted_block = ''
            for i in range(len(block)):
                decrypted_block += chr(ord(block[i]) ^ ord(key[i % len(key)])
            decrypted_blocks.append(decrypted_block)

            key = self.update_key(key, decrypted_block)

        return ''.join(decrypted_blocks)

    def update_key(self, key, block):
        updated_key = ''
        for i in range(len(key)):
            updated_key += chr(ord(key[i]) ^ ord(block[i % len(block)])
        return updated_key
          """
          # 创建一个LightSK实例
          sk = LightSK('secretkey')

          # 加密消息
          encrypted_message = sk.encrypt('hello world')

          # 解密消息
          decrypted_message = sk.decrypt(encrypted_message)

          print(encrypted_message)
          print(decrypted_message)
          """

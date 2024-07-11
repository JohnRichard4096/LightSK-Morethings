class LightSK {
    constructor(key) {
        this.key = key;
    }

    encrypt(message) {
        let encryptedBlocks = [];
        let key = this.key;

        let blocks = message.match(/.{1,8}/g);

        blocks.forEach(block => {
            let encryptedBlock = '';
            for (let i = 0; i < block.length; i++) {
                encryptedBlock += String.fromCharCode(block.charCodeAt(i) ^ key.charCodeAt(i % key.length));
            }
            encryptedBlocks.push(encryptedBlock);

            key = this.updateKey(key, block);
        });

        return encryptedBlocks.join('');
    }

    decrypt(encryptedMessage) {
        let decryptedBlocks = [];
        let key = this.key;

        let blocks = encryptedMessage.match(/.{1,8}/g);

        blocks.forEach(block => {
            let decryptedBlock = '';
            for (let i = 0; i < block.length; i++) {
                decryptedBlock += String.fromCharCode(block.charCodeAt(i) ^ key.charCodeAt(i % key.length));
            }
            decryptedBlocks.push(decryptedBlock);

            key = this.updateKey(key, decryptedBlock);
        });

        return decryptedBlocks.join('');
    }

    updateKey(key, block) {
        let updatedKey = '';
        for (let i = 0; i < key.length; i++) {
            updatedKey += String.fromCharCode(key.charCodeAt(i) ^ block.charCodeAt(i % block.length));
        }
        return updatedKey;
    }
} 

const sk = new LightSK('secretkey');
const encrypted = sk.encrypt('hello world');
console.log(encrypted);

const decrypted = sk.decrypt(encrypted);
console.log(decrypted);
/*
如何调用？
加密&解密
const sk = new LightSK('secretkey');
const encrypted = sk.encrypt('hello world');
console.log(encrypted);

const decrypted = sk.decrypt(encrypted);
console.log(decrypted);
*/

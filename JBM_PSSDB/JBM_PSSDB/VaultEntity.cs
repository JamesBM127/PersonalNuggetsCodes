using JBMDatabase;

namespace JBM_PSSDB
{
    public class VaultEntity : BaseHistoryEntity
    {
        /// <summary>
        /// Indica a versão do formato de dados criptográficos do cofre.
        /// Caso mude o formato dos dados ou os parâmetros de criptografia.
        /// A Version ajuda a library a identificar como interpretar os registros antigos.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Sequência de bytes aleatórios utilizada pelo PBKDF2 durante a derivação da KEK.
        /// Se dois usuários escolherem a mesma Master Password, salts diferentes farão com que as KEKs derivadas sejam diferentes.
        /// </summary>
        public byte[] Salt { get; set; } = [];

        /// <summary>
        /// Indica quantas iterações o PBKDF2 utiliza para derivar a KEK.
        /// Se mudar o número de iterações em uma versão futura, os cofres antigos ainda precisarão usar o parâmetro com o qual foram criados.
        /// </summary>
        public int Pbkdf2Iterations { get; set; }

        /// <summary>
        /// O nonce é um valor utilizado pelo AES-GCM durante a criptografia.
        /// Quando a KEK criptografa a Vault Key, o AES-GCM precisa de um nonce.
        /// Esse nonce deve ser armazenado junto aos dados criptografados para que a descriptografia seja possível.
        /// </summary>
        public byte[] EncryptedVaultKeyNonce { get; set; } = [];

        /// <summary>
        /// Essa propriedade contém a própria Vault Key criptografada pela KEK.
        /// A Vault Key original possui 32 bytes. Como o AES-GCM não aumenta o tamanho do conteúdo criptografado, o ciphertext também terá 32 bytes nesse caso.
        /// Essa propriedade é uma das mais importantes da entidade: sem a Vault Key recuperada, não conseguimos descriptografar as senhas das contas.
        /// </summary>
        public byte[] EncryptedVaultKeyCiphertext { get; set; } = [];

        /// <summary>
        /// A tag é uma etiqueta de autenticação gerada pelo AES-GCM durante a criptografia.
        /// Sua função é permitir que o AES-GCM verifique se os dados protegidos são autênticos e não foram modificados.
        /// Se alguém alterar o ciphertext, o nonce ou a tag, a descriptografia deverá falhar na verificação de autenticidade.
        /// A tag não é uma senha nem uma chave. Ela é parte dos dados necessários para validar e descriptografar o conteúdo.
        /// </summary>
        public byte[] EncryptedVaultKeyTag { get; set; } = [];
    }
}

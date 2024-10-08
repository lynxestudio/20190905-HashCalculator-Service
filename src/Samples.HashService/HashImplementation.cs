using System.Text;
using System.Security.Cryptography;

namespace Samples.HashService{
    public sealed class HashImplementation : IHashService 
    {
        public HashRs GetHash(HashRq rq)
        {
        	HashRs response = new HashRs();
            if(string.IsNullOrWhiteSpace(rq.Text))
                    response.Error = "Empty message";
                else
                {
                    try
                    {
                        response.Code = 200;
                        response.HashCode = GetHashCode(rq.Text, rq.HashType);
                    }
                    catch (System.Exception ex)
                    {
                        response.Code = 500;
                        response.Error = "Exception: " + ex.Message;
                    }
                }
            return response;
        }
        /// <summary>
        /// Get the HashCode for text using the hashtype algorithm.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="hashType"></param>
        /// <returns></returns>
        string GetHashCode(string text,string hashType)
        {
            //create a byte array for string
            byte[] bytes = Encoding.Default.GetBytes(text);
            //create an instance of the hashing algorithm
            HashAlgorithm hash = HashAlgorithm.Create(hashType);
            //obtain the hash code from HashAlgorithm by
            //using the compute hash method
            byte[] hashcode = hash.ComputeHash(bytes);
            StringBuilder buffer = new StringBuilder();
            foreach (var element in hashcode)
            {
                buffer.AppendFormat("{0:X2}", element);
            }
            return buffer.ToString();
        }
    }
}

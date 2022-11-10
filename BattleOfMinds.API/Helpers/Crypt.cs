

namespace BattleOfMinds.API.Helpers
{
    public static class Crypt
    {
        public static string base64Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch(Exception ex)
            {
                throw new Exception("Error in Crypt" + ex.Message);
            }
        }
        public static string base64Decode(string sData)
        {
            try
            {

                
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] toDecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(toDecodeByte, 0, toDecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(toDecodeByte, 0, toDecodeByte.Length, decodedChar, 0);
                string result = new string(decodedChar);
                return result;
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Crypt" + ex.Message);
            }
        }

    }
}

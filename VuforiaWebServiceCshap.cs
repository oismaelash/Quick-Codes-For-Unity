using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

public class VuforiaWebServiceCshap
{
    private static string VufuriaProcess(string requestPath, string JsonObject, string httpVerb)
    {
        string secret_key = "server_secret_key";
        string access_key = "server_access_key";
        ASCIIEncoding Encoding = new ASCIIEncoding();
        MD5 md5 = MD5.Create();
        string serviceURI = "https://vws.vuforia.com" + requestPath;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceURI);
        request.Method = httpVerb;

        byte[] contentbytes = null;
        byte[] contentMD5bytes = md5.ComputeHash(Encoding.GetBytes(""));
        string contentMD5 = BitConverter.ToString(contentMD5bytes).Replace("-", "").ToLower();// "d41d8cd98f00b204e9800998ecf8427e";
        string contentType = "";

        if (JsonObject != null && JsonObject != "") //if body request is not null
        {
            contentbytes = Encoding.GetBytes(JsonObject);
            contentMD5bytes = md5.ComputeHash(contentbytes);
            contentMD5 = BitConverter.ToString(contentMD5bytes).Replace("-", "").ToLower();
            contentType = "application/json";
            request.ContentLength = contentbytes.Length;
        }

        #region Signature

        HMACSHA1 sha1 = new HMACSHA1(System.Text.Encoding.ASCII.GetBytes(secret_key));
        request.ContentType = contentType;
        string date = string.Format("{0:r}", DateTime.Now.ToUniversalTime());
        string StringToSign = String.Format("{0}\n{1}\n{2}\n{3}\n{4}", httpVerb, contentMD5, contentType, date, requestPath); // HTTP-Verb, Content-MD5, Content-Type, Date, Request-Path;
        byte[] sha1Bytes = Encoding.GetBytes(StringToSign);
        MemoryStream stream = new MemoryStream(sha1Bytes);
        byte[] sha1Hash = sha1.ComputeHash(stream);
        string signature = System.Convert.ToBase64String(sha1Hash);

        #endregion Signature

        request.Headers.Add("Authorization", string.Format("VWS {0}:{1}", access_key, signature));

        try
        {
            string strResponse;
            request.Date = DateTime.Now.ToUniversalTime();

            if (JsonObject != null && JsonObject != "")
            {
                var newStream = request.GetRequestStream();
                newStream.Write(contentbytes, 0, contentbytes.Length);
                newStream.Close();
            }

            var response = request.GetResponse();
            using (Stream Varstream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(Varstream))
                {
                    strResponse = reader.ReadToEnd();
                }
            }

            return strResponse;
        }
        catch (WebException ex)
        {
            return ex.Message;
        }
    }

    public static string AddTarget(byte[] bTarget, string TargetName, float width)
    {
        string image = Convert.ToBase64String(bTarget);
        string json = "{\"name\":\"" + TargetName + "\", \"width\": " + width + ", \"image\":\"" + image + "\", \"active_flag\":true}";
        return VufuriaProcess("/targets", json, "POST");
    }

    public static string UpdateTarget(byte[] bTarget, string TargetName, float width, string TargetId)
    {
        string image = Convert.ToBase64String(bTarget);
        string json = "{\"name\":\"" + TargetName + "\", \"width\": " + width + ", \"image\": \"" + image + "\", \"active_flag\": true}";
        return VufuriaProcess("/targets/" + TargetId, json.ToString(), "PUT");
    }

    public static string DeleteTarget(string TargetId)
    {
        return VufuriaProcess("/targets/" + TargetId, null, "DELETE");
    }

    public static string RetrieveTargetRecord(string TargetId)
    {
        return VufuriaProcess("/targets/" + TargetId, null, "GET");
    }

    public static string CheckDuplicateTargets(string TargetId)
    {
        return VufuriaProcess("/duplicates/" + TargetId, null, "GET");
    }

    public static string GetTargetList()
    {
        return VufuriaProcess("/targets", null, "GET");
    }

    public static string TargetSummaryReport(string TargetId)
    {
        return VufuriaProcess("/summary/" + TargetId, null, "GET");
    }

    public static string DatabaseSummaryReport()
    {
        return VufuriaProcess("/summary", null, "GET");
    }
}
